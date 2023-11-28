using G1ANT.Addon.Selenium.Api.Interfaces;
using G1ANT.Addon.Selenium.Api.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using G1ANT.Language;

namespace G1ANT.Addon.Selenium.Api
{
    public class SeleniumDrivers
    {
        private List<ISeleniumDriverInstaller> drivers;

        private string UnpackFolder { get => AbstractSettingsContainer.Instance.UserDocsAddonFolder.FullName; }

        public SeleniumDrivers()
        {
            drivers = new List<ISeleniumDriverInstaller>()
            {
                new SeleniumChromeDriverInstaller(BrowserType.Chrome),
                new SeleniumIEDriverInstaller(BrowserType.InternetExplorer),
                new SeleniumEdgeDriverInstaller(BrowserType.Edge),
                new SeleniumGeckoDriverInstaller(BrowserType.Firefox),
            };
        }

        public void Install(BrowserType type)
        {
            var driver = drivers.FirstOrDefault(x => x.BrowserType == type);
            if (driver == null)
                throw new DllNotFoundException($"Driver {type.ToString()} does not exist.");
            driver.Install(UnpackFolder);
        }

        public void InstallAll()
        {
            var exceptions = new List<Exception>();
            foreach (var driver in drivers)
            {
                try
                {
                    driver.Install(UnpackFolder);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Count > 0)
                throw new AggregateException(string.Join("\r\n", exceptions.Select(x => x.Message)), exceptions);
        }
    }
}
