﻿using G1ANT.Language;
using System;

namespace G1ANT.Addon.Selenium
{
    [Command(Name = "selenium.setattribute", Tooltip = "Sets specified attribute of specified element.")]

    public class SeleniumSetAttributeCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Name of attribute to set value of")]
            public TextStructure Name { get; set; }

            [Argument(Tooltip = "Value to set")]
            public TextStructure Value { get; set; }

            [Argument(Required = true, Tooltip = "Phrase to find element by")]
            public TextStructure Search { get; set; }

            [Argument(Tooltip = "Specifies an element selector, possible values are: 'name', 'text', 'title', 'class', 'id', 'selector', 'query', 'jquery'")]
            public TextStructure By { get; set; } = new TextStructure(ElementSearchBy.Id.ToString().ToLower());

            [Argument(DefaultVariable = "timeoutselenium")]
            public override int Timeout { get; set; } = (SeleniumSettings.SeleniumTimeout);
        }
        public SeleniumSetAttributeCommand(AbstractScripter scripter) : base(scripter)
        {
        }
        public void Execute(Arguments arguments)
        {
            try
            {
                SeleniumManager.CurrentWrapper.SetAttributeValue(
                    arguments.Name.Value,
                    arguments.Value?.Value ?? string.Empty,
                    arguments.Search.Value,
                    arguments.By.Value,
                    arguments.Timeout / 1000);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error occured while setting '{arguments.Name.Value}' attribute. Search element phrase: '{arguments.Search.Value}', by: '{arguments.By.Value}'. Message: {ex.Message}", ex);
            }

        }
    }
}
