using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.DriverConfigs;

namespace G1ANT.Addon.Selenium.Api.Services
{
    public class SeleniumIEDriverInstaller : SeleniumDriverInstaller
    {
        public SeleniumIEDriverInstaller(BrowserType type) : base(type)
        {
        }

        protected override IDriverConfig GetDriverConfig() => new InternetExplorerConfig();

    }
}
