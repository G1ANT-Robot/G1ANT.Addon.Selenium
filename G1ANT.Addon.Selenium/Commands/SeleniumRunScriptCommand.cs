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
    [Command(Name = "selenium.runscript", Tooltip = "Runs javascript code inside web browser.")]
    public class SeleniumRunScriptCommandCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Script which will be used inside web browser")]
            public TextStructure Script { get; set; }

            [Argument(Tooltip = "True if command should wait for new window to appear after click the element.")]
            public BooleanStructure WaitForNewWindow { get; set; } = new BooleanStructure(false);

            [Argument(DefaultVariable = "timeoutselenium")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public SeleniumRunScriptCommandCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                var result = SeleniumManager.CurrentWrapper.RunScript(arguments.Script.Value, arguments.Timeout.Value, arguments.WaitForNewWindow.Value);
                Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(result));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while running javascript script: '{arguments.Script.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
