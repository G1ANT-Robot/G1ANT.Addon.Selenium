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
    [Command(Name = "selenium.select", Tooltip = "This command select option from select button")]
    class SeleniumSelectCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Value to be selected")]
            public TextStructure SelectValue { get; set; }

            [Argument(Required = true, Tooltip = "Type of selector. May be index, text, value")]
            public TextStructure SelectBy { get; set; }

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public SeleniumSelectCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.Select(
                    arguments.SelectValue.Value,
                    arguments.SelectBy.Value,
                    arguments,
                    arguments.Timeout.Value); ;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while selecting option of the element. SelectValue: '{arguments.SelectValue.Value}'. SelectBy: '{arguments.SelectBy.Value}'. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);

            }
        }
    }
}
