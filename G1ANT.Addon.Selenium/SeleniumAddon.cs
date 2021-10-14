/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using G1ANT.Language;
using G1ANT.Addon.Selenium.Properties;
using System.IO;
using System.Diagnostics;

namespace G1ANT.Addon.Selenium
{
    [Addon(Name = "Selenium",
        Tooltip = "Selenium Commands")]
    [Copyright(Author = "G1ANT LTD", Copyright = "G1ANT LTD", Email = "hi@g1ant.com", Website = "www.g1ant.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    [CommandGroup(Name = "selenium", Tooltip = "Commands to work with web pages via supported web browsers.", IconName = "seleniumicon")]
    public class SeleniumAddon : Language.Addon
    {
        public override void LoadDlls()
        {
            UnpackDrivers();
            UnpackMSEdgeDriver();
            base.LoadDlls();
        }

        private string UnpackFolder { get => AbstractSettingsContainer.Instance.UserDocsAddonFolder.FullName; }
        
        private void UnpackMSEdgeDriver()
        {
            var filename = "msedgedriver.exe";
            var driverData = Environment.Is64BitOperatingSystem ? Resources.msedgedriver_64 : Resources.msedgedriver_32;

            if (DriverNeedsUpdate(filename, driverData))
                UpdateDriverFromResource(filename, driverData);
        }

        private void UnpackDrivers()
        {
            var embeddedResourceDictionary = new Dictionary<string, byte[]>()
            {
                { "chromedriver.exe", Resources.chromedriver },
                { "geckodriver.exe", Resources.geckodriver },
                { "IEDriverServer.exe", Resources.IEDriverServer }
            };
            foreach (var embededResource in embeddedResourceDictionary.Where(e => DriverNeedsUpdate(e.Key, e.Value)))
            {
                UpdateDriverFromResource(embededResource.Key, embededResource.Value);
            }
        }

        private bool DriverNeedsUpdate(string filename, byte[] resourceData)
        {
            return !DoesFileExist(UnpackFolder, filename) || !AreFilesOfTheSameLength(resourceData.Length, UnpackFolder, filename);
        }

        private void UpdateDriverFromResource(string filename, byte[] resourceData)
        {
            try
            {
                KillWorkingProcess(Path.GetFileNameWithoutExtension(filename));
                using (FileStream stream = File.Create(Path.Combine(UnpackFolder, filename)))
                {
                    stream.Write(resourceData, 0, resourceData.Length);
                }
            }
            catch (Exception ex)
            {
                RobotMessageBox.Show(ex.Message);
            }
        }

        private void KillWorkingProcess(string processName)
        {
            foreach (Process proc in Process.GetProcessesByName(processName))
            {
                try
                {
                    proc.Kill();
                }
                catch
                {

                }
            }
        }

        private bool DoesFileExist(string folder, string fileName)
        {
            return File.Exists(Path.Combine(folder, fileName));
        }

        private bool AreFilesOfTheSameLength(int length, string folder, string fileName)
        {
            return length == new FileInfo(Path.Combine(folder, fileName)).Length;
        }
    }
}