/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/

using G1ANT.Addon.Selenium;
using System.Diagnostics;
using System.Linq;

namespace G1ANT.Addon.Selenium.Tests
{
    public static class SeleniumTests
    {
        public const int TestTimeout = 1200000;

        public static void KillAllBrowserProcesses()
        {
            FirefoxKillAllProcesses();
            ChromeKillAllProcesses();
            EdgeKillAllProcesses();
            IeKillAllProcesses();
            SeleniumManager.DisposeAllOpenedDrivers();
        }
        public static void FirefoxKillAllProcesses()
        {
            foreach (var ie in Process.GetProcessesByName("firefox"))
            {
                try
                {
                    ie.Kill();
                }
                catch { }                
            }
        }
        public static void ChromeKillAllProcesses()
        {
            foreach (var ie in Process.GetProcessesByName("chrome"))
            {
                try
                {
                    ie.Kill();
                }
                catch { }
            }
        }
        public static void EdgeKillAllProcesses()
        {
            foreach (var ie in Process.GetProcesses().Where(x => x.ProcessName.Contains("Edge")))
            {
                try
                {
                    ie.Kill();
                }
                catch { }
            }
        }
        public static void IeKillAllProcesses()
        {
            foreach (var ie in Process.GetProcessesByName("iexplore"))
            {
                try
                {
                    ie.Kill();
                }
                catch { }
            }
        }

        public static int IeGetInstancesCount()
        {
            return Process.GetProcesses().
                Where(x => !string.IsNullOrEmpty(x.MainWindowTitle) && x.MainWindowTitle.
                Contains("Internet Explorer")).Count();
        }
        public static int ChromeGetInstancesCount()
        {
            return Process.GetProcesses().
                Where(x => !string.IsNullOrEmpty(x.MainWindowTitle) && x.MainWindowTitle.
                Contains("Chrome")).Count();
        }
        public static int EdgeGetInstancesCount()
        {
            return Process.GetProcesses().
                Where(x => !string.IsNullOrEmpty(x.MainWindowTitle) && x.MainWindowTitle.
                Contains("Edge")).Count();
        }
        public static int FirefoxGetInstancesCount()
        {
            return Process.GetProcesses().
                Where(x => !string.IsNullOrEmpty(x.MainWindowTitle) && x.MainWindowTitle.
                Contains("Firefox")).Count();
        }
    }
}
