using G1ANT.Addon.Selenium.Api.Interfaces;
using G1ANT.Addon.Selenium.Api.Services;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace G1ANT.Addon.Selenium.Api
{
    public class SeleniumDrivers
    {
        private List<ISeleniumDriverInstaller> drivers;

        public SeleniumDrivers()
        {
            drivers = new List<ISeleniumDriverInstaller>()
            {
                new SeleniumChromeDriverInstaller(BrowserType.Chrome, "chromedriver.exe", "chromedriver"),
                new SeleniumDriverInstaller(BrowserType.InternetExplorer, "IEDriverServer.exe", "IEDriverServer"),
            };
            if (Environment.Is64BitOperatingSystem)
                drivers.AddRange(new[]
                {
                    (ISeleniumDriverInstaller)new SeleniumEdgeDriverInstaller(BrowserType.Edge, "msedgedriver.exe", "msedgedriver_64"),
                    new SeleniumGeckoDriverInstaller(BrowserType.Firefox, "geckodriver.exe", "geckodriver_64"),
                });
            else
                drivers.AddRange(new[]
                {
                    (ISeleniumDriverInstaller)new SeleniumEdgeDriverInstaller(BrowserType.Edge, "msedgedriver.exe", "msedgedriver_32"),
                    new SeleniumGeckoDriverInstaller(BrowserType.Firefox, "geckodriver.exe", "geckodriver_32"),
                });
        }

        public void Unpack(Assembly assembly, string destinationFolder)
        {
            var exceptions = new List<Exception>();
            foreach (var driver in drivers)
            {
                try
                {
                    driver.Unpack(assembly, destinationFolder);
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Count > 0)
                throw new AggregateException(string.Join("\r\n", exceptions.Select(x => x.Message)), exceptions);
        }

        public void Install(BrowserType type, string destinationFolder)
        {
            var driver = drivers.FirstOrDefault(x => x.BrowserType == type);
            if (driver == null)
                throw new DllNotFoundException($"Driver {type.ToString()} does not exist.");
            driver.Install(destinationFolder);
        }

        public void InstallAll(string destinationFolder)
        {
            var exceptions = new List<Exception>();
            foreach (var driver in drivers)
            {
                try
                {
                    driver.Install(destinationFolder);
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
