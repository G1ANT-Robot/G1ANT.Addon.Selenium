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
    [Command(Name = "selenium.activatetab", Tooltip = "Activates browser's tab.")]
    public class SeleniumActivateTabCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Tab searching phrase")]
            public TextStructure Search { get; set; }

            [Argument(Required = true, Tooltip = "Tab searching contstraint. Accepts either 'title' or 'url'")]
            public TextStructure By { get; set; }
        }
        public SeleniumActivateTabCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.ActivateTab(arguments.Search.Value, arguments.By.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while activating tab. Search tab phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
