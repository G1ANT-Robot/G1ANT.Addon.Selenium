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
    [Command(Name = "selenium.gettable", Tooltip = "This command gets table content from a website and assigns it to a variable of datatable structure")]
    public class SeleniumGetTableCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Tooltip = "Name of a variable where the value of a specified attribute will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public SeleniumGetTableCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            SeleniumManager.CurrentWrapper.GetTableElement(arguments, arguments.Timeout.Value);
            Scripter.Variables.SetVariableValue(arguments.Result.Value, new DataTableStructure(""));
        }
    }
}
