using Microsoft.Win32;
using System;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.DriverConfigs;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public class SeleniumEdgeDriverInstaller : SeleniumDriverInstaller
    {
        public SeleniumEdgeDriverInstaller(BrowserType type) : base(type)
        {
        }

        protected override IDriverConfig GetDriverConfig() => new EdgeConfig();
    }
}
