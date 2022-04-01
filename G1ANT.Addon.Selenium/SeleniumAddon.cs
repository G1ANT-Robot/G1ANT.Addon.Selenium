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
using G1ANT.Language;
using G1ANT.Addon.Selenium.Api;
using G1ANT.Addon.Selenium.Api.Interfaces;
using G1ANT.Addon.Selenium.Api.Services;

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
            base.LoadDlls();
        }

        private string UnpackFolder { get => AbstractSettingsContainer.Instance.UserDocsAddonFolder.FullName; }
        
        private void UnpackDrivers()
        {
            try
            {
                var seleniumDrivers = new SeleniumDrivers();
                seleniumDrivers.Unpack(Assembly, UnpackFolder);
                seleniumDrivers.InstallAll(UnpackFolder);
            }
            catch (Exception ex)
            {
                RobotMessageBox.Show(ex.Message);
            }
        }
    }
}