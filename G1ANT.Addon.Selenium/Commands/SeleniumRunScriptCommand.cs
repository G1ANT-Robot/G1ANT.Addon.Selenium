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
    [Command(Name = "selenium.runscript", Tooltip = "This command runs Javascript code inside the web browser.")]
    public class SeleniumRunScriptCommandCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Script to be executed in the web browser")]
            public TextStructure Script { get; set; }

            [Argument(Tooltip = "If set to `true`, the command should wait for a new window to appear after the script execution")]
            public BooleanStructure WaitForNewWindow { get; set; } = new BooleanStructure(false);

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
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
