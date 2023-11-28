using Microsoft.Win32;
using System;
using System.Diagnostics;
using WebDriverManager.DriverConfigs;
using WebDriverManager.DriverConfigs.Impl;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public class SeleniumChromeDriverInstaller : SeleniumDriverInstaller
    {
        public SeleniumChromeDriverInstaller(BrowserType type) : base(type)
        {
        }

        protected override IDriverConfig GetDriverConfig() => new ChromeConfig();
    }
}
