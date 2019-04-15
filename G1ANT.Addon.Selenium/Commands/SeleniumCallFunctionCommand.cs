/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/
using System;
using System.Collections.Generic;
using System.Linq;
using G1ANT.Language;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.callfunction", Tooltip = "This command calls a function on a specified element.")]
    public class SeleniumCallFunctionCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(Required = true, Tooltip = "Name of function to call")]
            public TextStructure FunctionName { get; set; }

            [Argument(Tooltip = "Parameters to be passed to the function")]
            public ListStructure Parameters { get; set; }

            [Argument(Required = true, Tooltip = "Function call type: `javascript` or `jquery`")]
            public TextStructure Type { get; set; } = new TextStructure("javascript");

            [Argument(DefaultVariable = "timeoutselenium", Tooltip = "Specifies time in milliseconds for G1ANT.Robot to wait for the command to be executed")]
            public  override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout); 
        }
        public SeleniumCallFunctionCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumWrapper wrapper = SeleniumManager.CurrentWrapper;
                
                wrapper.CallFunction(
                    arguments.FunctionName.Value,
                    GetParameters((arguments.Parameters?.Value)),  
                    arguments.Type.Value,
                    arguments,
                    arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while calling '{arguments.FunctionName.Value}' function. Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }            
        }

        private object[] GetParameters(List<Object> arguments)
        {
            List<object> parameters = new List<object>();
            if (arguments != null && arguments.Any())
            {
                foreach (var argument in arguments)
                {
                    if (argument is TextStructure)
                    {
                        parameters.Add((argument as TextStructure).Value);
                    }
                    else if (argument is TextStructure)
                    {
                        parameters.Add((argument as TextStructure).Value);
                    }
                }
            }
            return parameters.ToArray();
        }
    }
}
