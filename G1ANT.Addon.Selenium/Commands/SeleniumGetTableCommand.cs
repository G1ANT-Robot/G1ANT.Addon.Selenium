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
using System.Data;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.gettable", Tooltip = "This command gets table from a website and assigns its content to a variable of datatable structure")]
    public class SeleniumGetTableCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Tooltip = "Name of a datatable variable where the table content from a website will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public SeleniumGetTableCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            var table = SeleniumManager.CurrentWrapper.GetTableElement(arguments, arguments.Timeout.Value);
            var dataTable = new DataTable();

            foreach (var row in table)
            {
                var i = dataTable.Columns.Count;
                while (i < row.Length)
                {
                    dataTable.Columns.Add();
                    i++;
                }

                dataTable.Rows.Add(row);
            }

            Scripter.Variables.SetVariableValue(arguments.Result.Value, new DataTableStructure(dataTable));
        }
    }
}
