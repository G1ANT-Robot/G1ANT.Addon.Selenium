using Microsoft.Win32;
using System;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public class SeleniumEdgeDriverInstaller : SeleniumDriverInstaller
    {
        public SeleniumEdgeDriverInstaller(BrowserType type, string driverName, string resourceName) : base(type, driverName, resourceName)
        {
        }

        public override Version GetInstalledBrowserVersion()
        {
            var version = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Edge\BLBeacon", "version", null);
            if (version != null)
                return new Version(version.ToString());

            return null;
        }
    }
}
