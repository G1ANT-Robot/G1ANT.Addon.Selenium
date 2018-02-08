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
    [Command(Name = "selenium.gettitle", Tooltip = "Gets title of currently active web browser instance.")]
    public class SeleniumGetTitleCommand : Command
    {
        public class Arguments : CommandArguments
        {

            [Argument(Tooltip = "Name of variable where title of currently attached web browser instance will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
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
