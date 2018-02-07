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
    [Command(Name = "selenium.seturl", Tooltip = "Navigates currently active selenium instance to specified url.")]
    public class SeleniumSetUrlCommand : Command
    {
        public class Arguments : CommandArguments
        {

            [Argument(Required = true, Tooltip = "New webpage address")]
            public TextStructure Url { get; set; } = new TextStructure(string.Empty);

            [Argument(DefaultVariable = "timeoutselenium")]
            public  override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Does not wait for a webpage to fully load")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
            
        }
        public SeleniumSetUrlCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.Navigate(arguments.Url.Value, (int)arguments.Timeout.Value.TotalMilliseconds, arguments.NoWait.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while setting url on currently active selenium instance. Url address: '{arguments.Url.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
