using G1ANT.Language;
using System;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.presskey", Tooltip = "Types text into element.")]
    public class SeleniumPressKeyCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Key to press")]
            public TextStructure Key { get; set; }

            [Argument(Required = true, Tooltip = "Phrase to find element by")]
            public TextStructure Search { get; set; }

            [Argument(Tooltip = "Specifies an element selector, possible values are: 'name', 'text', 'title', 'class', 'id', 'selector', 'query', 'jquery'")]
            public TextStructure By { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());

            [Argument(DefaultVariable = "timeoutselenium")]
            public  override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

        }
        public SeleniumPressKeyCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.PressKey(
                    arguments.Key.Value,
                    arguments.Search.Value,
                    arguments.By.Value,
                    arguments.Timeout.Value.Milliseconds / 1000);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while pressing key on element. Text: '{arguments.Key.Value}'. 'Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
