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

            [Argument]
            public BooleanStructure NoWait { get; set; } = new BooleanStructure(false);
            
        }
        public SeleniumSetUrlCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.Navigate(arguments.Url.Value, arguments.Timeout.Value.Milliseconds, arguments.NoWait.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while setting url on currently active selenium instance. Url address: '{arguments.Url.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
