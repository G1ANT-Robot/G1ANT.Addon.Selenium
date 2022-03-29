using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public class SeleniumChromeDriverInstaller : SeleniumDriverInstaller
    {
        public SeleniumChromeDriverInstaller(BrowserType type, string driverName, string resourceName) : base(type, driverName, resourceName)
        {
        }

        public override Version GetInstalledBrowserVersion()
        {
            var path = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);
            if (path == null)
                path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\App Paths\chrome.exe", "", null);
            if (path != null)
                return new Version(FileVersionInfo.GetVersionInfo(path.ToString()).FileVersion);

            return null;
        }
    }
}
