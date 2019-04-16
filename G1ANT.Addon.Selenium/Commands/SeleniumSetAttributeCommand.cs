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
using System;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.setattribute", Tooltip = "This command sets a specified attribute of a specified element")]

    public class SeleniumSetAttributeCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Name of an attribute to set its value")]
            public TextStructure Name { get; set; }

            [Argument(Tooltip = "Value to set")]
            public TextStructure Value { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public  override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public SeleniumSetAttributeCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.SetAttributeValue(
                    arguments.Name.Value,
                    arguments.Value?.Value ?? string.Empty,
                    arguments,
                    arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while setting '{arguments.Name.Value}' attribute. Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }

        }
    }
}
