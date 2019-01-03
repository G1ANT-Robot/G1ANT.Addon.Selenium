﻿/**
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
    [Command(Name = "selenium.gettext", Tooltip = "Gets text of specified element.")]

    public class SeleniumGetTextCommand : Command
    {
        public class Arguments : SeleniumCommandArguments
        {
            [Argument(DefaultVariable = "timeoutselenium")]
            public override TimeSpanStructure Timeout { get; set; } = new TimeSpanStructure(SeleniumSettings.SeleniumTimeout);

            [Argument(Tooltip = "Name of variable where value of specified attribute will be stored")]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }
        public SeleniumGetTextCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                var attributeValue = SeleniumManager.CurrentWrapper.GetTextValue(
                arguments,
                arguments.Timeout.Value);

                Scripter.Variables.SetVariableValue(arguments.Result.Value, new TextStructure(attributeValue));
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
