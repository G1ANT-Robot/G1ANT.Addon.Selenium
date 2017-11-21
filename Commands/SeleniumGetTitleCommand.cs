using G1ANT.Language;
using System;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.gettitle", Tooltip = "Gets title of currently active web browser instance.")]
    public class SeleniumGetTitleCommand : Command
    {
        public class Arguments : CommandArguments
        {

            [Argument(Tooltip = "Name of variable where title of currently attached web browser instance will be stored")]
            public TextStructure Result { get; set; } = new TextStructure("result");
        }
        public SeleniumGetTitleCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                Scripter.Variables.SetVariableValue(arguments.Result.Value, new Language.TextStructure(SeleniumManager.CurrentWrapper.Title));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while getting title of currently active selenium instance. Message: {ex.Message}", ex);
            }
        }
    }
}
