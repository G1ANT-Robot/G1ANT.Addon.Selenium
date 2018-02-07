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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.switch", Tooltip = "Changes current active web browser instance.")]
    public class SeleniumSwitchCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Id of web browser")]
            public IntegerStructure Id { get; set; }
        }
        public SeleniumSwitchCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.Switch(arguments.Id.Value);

            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while switching to another selenium instance. Selenium instance id: '{arguments.Id.Value}'. Message: {ex.Message}", ex);
            }
        }
    }
}
