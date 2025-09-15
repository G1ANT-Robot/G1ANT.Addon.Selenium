using Microsoft.Win32;
using System;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.DriverConfigs;
using System.Runtime.InteropServices;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public class G1EdgeConfig : EdgeConfig
    {
        private const string BaseVersionPatternUrl = "https://msedgedriver.microsoft.com/<version>/";
        private const string LatestStableReleaseVersionUrl = "https://msedgedriver.microsoft.com/LATEST_STABLE";
        private const string LatestBetaReleaseVersionUrl = "https://msedgedriver.microsoft.com/LATEST_BETA";

        public override string GetUrl32()
        {
            return $"{BaseVersionPatternUrl}edgedriver_win32.zip";
        }

        public override string GetUrl64()
        {
            return $"{BaseVersionPatternUrl}edgedriver_win64.zip";
        }

        public override string GetLatestVersion()
        {
            var url = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? LatestStableReleaseVersionUrl
                : LatestBetaReleaseVersionUrl;
            return GetLatestVersion(url);
        }
    }


    public class SeleniumEdgeDriverInstaller : SeleniumDriverInstaller
    {
        public SeleniumEdgeDriverInstaller(BrowserType type) : base(type)
        {
        }

        protected override IDriverConfig GetDriverConfig() => new G1EdgeConfig();
    }
}
