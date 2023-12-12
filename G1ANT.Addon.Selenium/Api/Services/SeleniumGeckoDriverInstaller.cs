using Microsoft.Win32;
using System;
using System.Diagnostics;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.DriverConfigs;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public class SeleniumGeckoDriverInstaller : SeleniumDriverInstaller
    {
        public SeleniumGeckoDriverInstaller(BrowserType type) : base(type)
        {
        }

        protected override IDriverConfig GetDriverConfig() => new FirefoxConfig();
    }
}
