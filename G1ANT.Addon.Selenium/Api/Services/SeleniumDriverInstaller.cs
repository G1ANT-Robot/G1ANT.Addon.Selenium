using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using G1ANT.Language;
using System.Linq;
using System.Collections.Generic;
using G1ANT.Addon.Selenium.Api.Interfaces;
using G1ANT.Addon.Selenium.Api.Models;
using System.Net;
using System.IO.Compression;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public class SeleniumDriverInstaller : ISeleniumDriverInstaller
    {
        private string driverName;
        private string resourceName;
        private const int killingProcessTimeout = 10000;
        private const int createFileTimeout = 10000;
        private const string driverSubfolder = "SeleniumDrivers";
        private const string driverResourceNamePrefix = "G1ANT.Addon.Selenium.drivers.";

        public BrowserType BrowserType { get; }


        public SeleniumDriverInstaller(BrowserType type, string driverName, string resourceName)
        {
            BrowserType = type;
            Init(driverName, resourceName);
        }

        public void Unpack(Assembly assembly, string destinationFolder)
        {
            var diverNames = new List<string>();
            var driversRepositoryFolder = GetDriverRepositoryFolder(destinationFolder);

            if (!string.IsNullOrEmpty(resourceName))
                diverNames.AddRange(GetResourceNames(assembly));

            foreach (var name in diverNames)
            {
                var resourceBinary = assembly.GetManifestResourceBytes(name.Remove(0, assembly.GetName().Name.Length+1));
                CreateDriverFileFromResoure(name.Remove(0, driverResourceNamePrefix.Length), resourceBinary, driversRepositoryFolder);
            }
        }

        public virtual Version GetInstalledBrowserVersion() => null;

        public void Install(string destinationFolder)
        {
            var driversRepositoryFolder = GetDriverRepositoryFolder(destinationFolder);
            var currentBrowserVersion = GetInstalledBrowserVersion();
            var repositoryDrivers = FindDriversInRepository(driversRepositoryFolder);
            SeleniumDriverModel driverToInstall;

            if (currentBrowserVersion == null)
            {
                driverToInstall = repositoryDrivers
                    .OrderByDescending(s => s.Version)
                    .FirstOrDefault();
            }
            else
            {
                driverToInstall = repositoryDrivers
                    .Where(x => new Version(x.Version.Major, x.Version.Minor) <= currentBrowserVersion)
                    .OrderByDescending(s => s.Version)
                    .FirstOrDefault();
            }
            if (driverToInstall == null)
                throw new FileNotFoundException($"Cannot find {driverName} driver for browser version {currentBrowserVersion}.");

            if (driverToInstall.Version.Major < currentBrowserVersion.Major && this.BrowserType == BrowserType.Chrome)
            {
                var newDriverPath = DownloadChromedriver(currentBrowserVersion.Major.ToString(), destinationFolder);
                InstallDriverFromRepositoryFolder(newDriverPath, destinationFolder);
            }
            else
                InstallDriverFromRepositoryFolder(driverToInstall.FilePath, destinationFolder);
        }

        private SeleniumDriverModel[] FindDriversInRepository(string repositoryFolder)
        {
            return Directory
                .GetFiles(repositoryFolder, $"{resourceName}*")
                .Select(x => new SeleniumDriverModel(x))
                .ToArray();
        }

        private IEnumerable<string> GetResourceNames(Assembly assembly)
        {
            var resourcePrefix = $"{driverResourceNamePrefix}{resourceName}";
            return assembly.GetManifestResourceNames().Where(x => x.StartsWith(resourcePrefix));
        }

        private string GetDriverRepositoryFolder(string rootFolder)
        {
            var path = Path.Combine(rootFolder, driverSubfolder);
            Directory.CreateDirectory(path);
            return path;
        }


        private void Init(string driverName, string resourceName)
        {
            this.driverName = driverName;
            this.resourceName = resourceName;
        }

        private bool DriverNeedsUpdate(string filename, byte[] resourceData, string unpackFolder) 
            => !DoesFileExist(unpackFolder, filename) || !AreFilesOfTheSameLength(resourceData.Length, unpackFolder, filename);

        private void InstallDriverFromRepositoryFolder(string driverFile, string unpackFolder)
        {
            KillWorkingProcess(Path.GetFileNameWithoutExtension(driverName), unpackFolder);
            var startTickCount = Environment.TickCount;
            bool timeoutOccured = false;
            var destinationFilename = Path.Combine(unpackFolder, driverName);

            while (!timeoutOccured)
            {
                try
                {
                    File.Copy(driverFile, destinationFilename, true);
                    return;
                }
                catch { }
                timeoutOccured = TimeoutOccured(startTickCount, createFileTimeout);
            }

            if (timeoutOccured)
                throw new Exception($"Unable to install driver {driverName}. Driver is being used by another process.");
        }

        private bool TimeoutOccured(int startTime, int timeout) 
            => Environment.TickCount - startTime > timeout;

        private bool CreateDriverFileFromResoure(string filename, byte[] resourceData, string unpackFolder)
        {
            try
            {
                var filePath = Path.Combine(unpackFolder, filename);
                if (File.Exists(filePath))
                    return true;
                using (FileStream stream = File.Create(filePath))
                    stream.Write(resourceData, 0, resourceData.Length);

                return true;
            }
            catch
            {

                return false;
            }
        }

        private void KillWorkingProcess(string processName, string unpackFolder)
        {
            foreach (Process process in Process.GetProcessesByName(processName))
                try
                {
                    if (process.MainModule.FileName.ToLower().Contains(unpackFolder.ToLower()))
                        KillProcessAndChildren(process.Id);
                }
                catch 
                {
                }

        }

        private bool DoesFileExist(string folder, string fileName)
            => File.Exists(Path.Combine(folder, fileName));


        private bool AreFilesOfTheSameLength(int length, string folder, string fileName)
            => length == new FileInfo(Path.Combine(folder, fileName)).Length;


        private static void KillProcessAndChildren(int pid)
        {
            if (pid == 0)
                return;

            ManagementObjectSearcher searcher = new ManagementObjectSearcher
                ("Select * From Win32_Process Where ParentProcessID=" + pid);

            foreach (ManagementObject item in searcher.Get())
                KillProcessAndChildren(Convert.ToInt32(item["ProcessID"]));

            try
            {
                Process process = Process.GetProcessById(pid);
                process.Kill();
                if (!process.HasExited)
                    process.WaitForExit(killingProcessTimeout);
            }
            catch
            {

            }
        }

        static string DownloadChromedriver(string chromeVersion, string destinationFolder)
        {
            string driverPath = string.Empty;

            string driverDir = Path.Combine(Path.GetTempPath(), "chromedriver");
            if (Directory.Exists(driverDir))
            {
                Directory.Delete(driverDir, true);
            }

            string webDriverUrl = "https://chromedriver.storage.googleapis.com/LATEST_RELEASE_" + chromeVersion;
            string driverVersion = new WebClient().DownloadString(webDriverUrl);

            if (!string.IsNullOrEmpty(driverVersion))
            {
                string driverUrl = $"https://chromedriver.storage.googleapis.com/{driverVersion}/chromedriver_win32.zip";

                string zipFilePath = Path.Combine(Path.GetTempPath(), "chromedriver_win32.zip");
                WebClient webClient = new WebClient();
                webClient.DownloadFile(driverUrl, zipFilePath);

                Directory.CreateDirectory(driverDir);
                ZipFile.ExtractToDirectory(zipFilePath, driverDir);

                string driverFileName = $"chromedriver_{driverVersion}.exe";
                driverPath = Path.Combine($"{destinationFolder}\\SeleniumDrivers", driverFileName);

                File.Move(Path.Combine(driverDir, "chromedriver.exe"), driverPath);
            }

            return driverPath;
        }
    }
}
