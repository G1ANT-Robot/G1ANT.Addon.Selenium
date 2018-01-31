using G1ANT.Language;
using System;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.newtab", Tooltip = "Creates new tab in current browser.")]
    public class SeleniumNewTabCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Tooltip = "Webpage address to load")]
            public TextStructure Url { get; set; }

            [Argument(DefaultVariable = "timeoutselenium")]
            public  override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Does not wait for a webpage to fully load")]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
            
        }
        public SeleniumNewTabCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.NewTab((int)arguments.Timeout.Value.TotalMilliseconds/ 1000, arguments.Url?.Value, arguments.NoWait.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while opening new tab. Url '{arguments.Url.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
