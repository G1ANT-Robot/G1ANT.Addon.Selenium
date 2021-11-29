using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Reflection;
using G1ANT.Language;

namespace G1ANT.Addon.Selenium.Api
{
    public class SeleniumDriverResourceDescription
    {
        private string driverName;
        private string resourceName32;
        private string resourceName64;
        private const int killingProcessTimeout = 10000;
        private const int createFileTimeout = 10000;

        public SeleniumDriverResourceDescription(string driverName, string resourceName)
        {
            Init(driverName, resourceName, resourceName);
        }

        public SeleniumDriverResourceDescription(string driverName, string resourceName32, string resourceName64) 
            => Init(driverName, resourceName32, resourceName64);

        public void UnpackIfNeeded(Assembly assembly, string unpackFolder)
        {
            var resourceName = Environment.Is64BitOperatingSystem ? resourceName64 : resourceName32;
            var resourceBinary = assembly.GetResourceBytes(resourceName);

            if (resourceBinary == null)
                throw new ApplicationException($"Driver '{resourceName}' is not embedded in the Addon.Selenium.");

            if (DriverNeedsUpdate(driverName, resourceBinary, unpackFolder))
                UpdateDriverFromResource(driverName, resourceBinary, unpackFolder);
        }

        private void Init(string driverName, string resourceName32, string resourceName64)
        {
            this.driverName = driverName;
            this.resourceName32 = resourceName32;
            this.resourceName64 = resourceName64;
        }

        private bool DriverNeedsUpdate(string filename, byte[] resourceData, string unpackFolder) 
            => !DoesFileExist(unpackFolder, filename) || !AreFilesOfTheSameLength(resourceData.Length, unpackFolder, filename);

        private void UpdateDriverFromResource(string filename, byte[] resourceData, string unpackFolder)
        {
            KillWorkingProcess(Path.GetFileNameWithoutExtension(filename), unpackFolder);
            var startTickCount = Environment.TickCount;
            while (!CreateDriverFileFromResoure(filename, resourceData, unpackFolder)
                && !TimeoutOccured(startTickCount, createFileTimeout))
                ;

            if (TimeoutOccured(startTickCount, createFileTimeout))
                throw new Exception($"Unable to unpack driver {filename}. Driver is being used by another process.");
        }

        private bool TimeoutOccured(int startTime, int timeout) 
            => Environment.TickCount - startTime > timeout;

        private bool CreateDriverFileFromResoure(string filename, byte[] resourceData, string unpackFolder)
        {
            try
            {
                using (FileStream stream = File.Create(Path.Combine(unpackFolder, filename)))
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
            foreach (Process proc in Process.GetProcessesByName(processName))
                if (proc.MainModule.FileName.Contains(unpackFolder))
                    KillProcessAndChildren(proc.Id);
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
    }
}
