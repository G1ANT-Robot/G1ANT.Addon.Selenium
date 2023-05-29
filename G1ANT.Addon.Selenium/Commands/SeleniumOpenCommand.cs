/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/
using G1ANT.Language;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.open", Tooltip = "This command opens a new instance of a chosen web browser and optionally navigates to a specified URL address")]
    public class SeleniumOpenCommand : Language.Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Name of a web browser")]
            public TextStructure Type { get; set; }

            [Argument(Tooltip = "URL address of a webpage to be loaded")]
            public TextStructure Url { get; set; } = new TextStructure(string.Empty);

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "By default, waits until the webpage fully loads")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);

            [Argument(Tooltip = "Additional switches for Chrome driver ")]
            public ListStructure ChromeSwitches { get; set; }

            [Argument(Tooltip = "Additional profiles for Chrome driver ")]
            public DictionaryStructure ChromeProfiles { get; set; }

            [Argument(Tooltip = "Chrome port, which enable to attach by selenium.chromeattach. Example 9222.")]
            public IntegerStructure ChromePort { get; set; } = new IntegerStructure(0);

            [Argument(Tooltip = "Run selenium in silent mode")]
            public BooleanStructure SilentMode { get; set; } = new BooleanStructure(false);

            [Argument(Tooltip = "Profile name or folder for the Firefox")]
            public TextStructure FirefoxProfile { get; set; }

            [Argument(Tooltip = "Name of a variable where the command's result will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public SeleniumOpenCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                int chromePort = 0;
                var chromeProfiles = new Dictionary<string, bool>();
                if (arguments.ChromeProfiles != null)
                    foreach (var pair in arguments.ChromeProfiles.Value)
                        chromeProfiles.Add(pair.Key, Convert.ToBoolean(pair.Value));
                if (arguments.ChromePort != null)
                    chromePort = arguments.ChromePort.Value;
                SeleniumWrapper wrapper = SeleniumManager.CreateWrapper(
                        arguments.Type.Value,
                        arguments.Url?.Value,
                        arguments.Timeout.Value,
                        arguments.NoWait.Value,
                        Scripter.Log,
                        Scripter.Settings.UserDocsAddonFolder.FullName,
                        arguments.SilentMode.Value,
                        arguments.ChromeSwitches?.Value,
                        chromeProfiles,
                        chromePort,
                        false,
                        arguments.FirefoxProfile?.Value);
                int wrapperId = wrapper.Id;
                OnScriptEnd = () =>
                {
                    SeleniumManager.DisposeAllOpenedDrivers();
                    SeleniumManager.RemoveWrapper(wrapperId);
                    SeleniumManager.CleanUp();
                };
                Scripter.Variables.SetVariableValue(arguments.Result.Value, new IntegerStructure(wrapper.Id));
            }
            catch (DriverServiceNotFoundException ex)
            {
                throw new ApplicationException("Driver not found", ex);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new selenium instance. Url '{arguments.Url.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
