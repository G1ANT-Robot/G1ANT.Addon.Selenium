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
    [Command(Name = "selenium.closetab", Tooltip = "Close current tab in current browser.")]
    public class SeleniumCloseTabCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);
        }
        public SeleniumCloseTabCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.CloseTab((int)arguments.Timeout.Value.TotalMilliseconds / 1000);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while closing current tab. Message: {ex.Message}", ex);
            }
        }
    }
}
