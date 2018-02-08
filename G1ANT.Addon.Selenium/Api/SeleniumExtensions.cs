/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace G1ANT.Addon.Selenium
{
    public static class SeleniumExtensions
    {
        public static IJavaScriptExecutor JavaScriptExecutor(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }

        public static IWebElement SetAttribute(this IWebElement element, string name, string value)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].setAttribute(arguments[1], arguments[2]);", element, name, value);
            return element;
        }

        public static IWebElement CallFunction(this IWebElement element, string functionName, object[] arguments, string type)
        {
            var driver = ((IWrapsDriver)element).WrappedDriver;
            var jsExecutor = (IJavaScriptExecutor)driver;
            string argumentsToPass = string.Empty;
            for (int i = 1; i <= arguments.Length; i++)
            {
                argumentsToPass += $"arguments[{i}]";
                if (i < arguments.Length)
                {
                    argumentsToPass += ", ";
                }
            }

            string jsCode = string.Empty;
            switch (type.ToLower())
            {
                case "javascript":
                    jsCode = $"arguments[0].{functionName}({argumentsToPass});";
                    break;

                case "jquery":
                    jsCode = $"$(arguments[0]).{functionName}({argumentsToPass});";
                    break;
                default:
                    throw new ArgumentException("'Type' argument accepts either 'javascript' or 'jquery' value");

            }
            jsExecutor.ExecuteScript(jsCode, element, arguments);
            return element;
        }
    }
}
