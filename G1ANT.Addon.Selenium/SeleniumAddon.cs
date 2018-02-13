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
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;
using G1ANT.Addon.Selenium.Properties;
using System.IO;

namespace G1ANT.Addon.Selenium
{
    [Addon(Name = "Selenium",
        Tooltip = "Selenium Commands")]
    [Copyright(Author = "G1ANT LTD", Copyright = "G1ANT LTD", Email = "hi@g1ant.com", Website = "www.g1ant.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    [CommandGroup(Name = "selenium", Tooltip = "Commands to work with web pages via supported web browsers.", IconName = "seleniumicon")]
    public class SeleniumAddon : Language.Addon
    {
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadDlls()
        {
            UnpackDrivers();
            base.LoadDlls();
        }

        private void UnpackDrivers()
        {
            var unpackfolder = AbstractSettingsContainer.Instance.UserDocsAddonFolder.FullName;
            Dictionary<string, byte[]> exeList = new Dictionary<string, byte[]>()
            {
                { "chromedriver.exe", Resources.chromedriver },
                { "geckodriver.exe", Resources.geckodriver },
                { "IEDriverServer.exe", Resources.IEDriverServer },
                { "MicrosoftWebDriver.exe", Resources.MicrosoftWebDriver }
            };
            foreach (var exe in exeList)
            {
                try
                {
                    using (FileStream stream = File.Create(Path.Combine(unpackfolder, exe.Key)))
                    {
                        stream.Write(exe.Value, 0, exe.Value.Length);
                    }
                }
                catch { }                
            }
        }
    }
}