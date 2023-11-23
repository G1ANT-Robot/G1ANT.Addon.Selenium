using System;
using System.Reflection;

namespace G1ANT.Addon.Selenium.Api.Interfaces
{
    public interface ISeleniumDriverInstaller
    {
        BrowserType BrowserType { get; }
        void Install(string destinationFolder);
    }
}
