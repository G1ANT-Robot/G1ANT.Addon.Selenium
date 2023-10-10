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
    [Command(Name = "selenium.switchframe", Tooltip = "This command switches context of all commands to the frame specified by arguments")]

    public class SeleniumSwitchFrameCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Tooltip = "Phrase to find an element by")]
            public TextStructure Search { get; set; }

            [Argument(Tooltip = "Specifies an element selector: 'id', 'class', 'cssselector', 'tag', 'xpath', 'name', 'query', 'jquery'")]
            public TextStructure By { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());
        }

        public SeleniumSwitchFrameCommand(AbstractScripter scripter) : base(scripter)
        {
        }

        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.SwitchFrame(arguments.Search?.Value, arguments.By?.Value, arguments.Timeout.Value);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Unable to switch frame. Message: {ex.Message}", ex);
            }
        }
    }
}
