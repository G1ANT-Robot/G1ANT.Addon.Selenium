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
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using WebDriverManager.DriverConfigs;
using System.Net;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public abstract class SeleniumDriverInstaller : ISeleniumDriverInstaller
    {
        private const int killingProcessTimeout = 10000;
        private const int createFileTimeout = 10000;
        private const string driverSubfolder = "SeleniumDrivers";

        public BrowserType BrowserType { get; }


        public SeleniumDriverInstaller(BrowserType type)
        {
            BrowserType = type;
        }

        protected abstract IDriverConfig GetDriverConfig();

        public void Install(string destinationFolder)
        {
            var driversRepositoryFolder = GetDriverRepositoryFolder(destinationFolder);

            var driverManager = new DriverManager(driversRepositoryFolder);
            var defProxy = WebRequest.GetSystemWebProxy();
            if (defProxy != null)
                driverManager = driverManager.WithProxy(defProxy);
            var config = GetDriverConfig();
            var driverPath = driverManager.SetUpDriver(config);

            InstallDriverFromRepositoryFolder(driverPath, destinationFolder, config.GetBinaryName());
        }

        private string GetDriverRepositoryFolder(string rootFolder)
        {
            var path = Path.Combine(rootFolder, driverSubfolder);
            Directory.CreateDirectory(path);
            return path;
        }

        private void InstallDriverFromRepositoryFolder(string driverFile, string unpackFolder, string driverName)
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
