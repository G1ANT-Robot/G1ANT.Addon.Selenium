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
    [Addon(Name = "Selenuium",
        Tooltip = "Selenium Commands")]
    [CommandGroup(Name = "selenium", Tooltip = "Commands to work with web pages via supported web browsers.")]
    public class SeleniumAddon : Language.Addon
    {
        public override void Initialize()
        {
            base.Initialize();
            UnpackDrivers();
        }

        private void UnpackDrivers()
        {
            var unpackfolder = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly().Location);
            Dictionary<string, byte[]> exeList = new Dictionary<string, byte[]>();
            exeList.Add("chrome.exe", Resources.chromedriver);
            exeList.Add("geckodriver.exe", Resources.geckodriver);
            exeList.Add("IEDriverServer.exe", Resources.IEDriverServer);
            exeList.Add("MicrosoftWebDriver.exe", Resources.MicrosoftWebDriver);
            foreach (var exe in exeList)
            {
                var stream = File.Create(Path.Combine(unpackfolder, exe.Key));
                stream.Write(exe.Value, 0, exe.Value.Length);
                stream.Close();
            }
        }
    }
}