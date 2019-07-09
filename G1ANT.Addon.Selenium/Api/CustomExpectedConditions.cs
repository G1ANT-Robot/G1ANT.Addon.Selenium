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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.Selenium
{
    public class CustomExpectedConditions
    {
        public static Func<IWebDriver, IWebElement> ElementExistsByJquery(string jquerySelector)
        {
            Func<IWebDriver, IWebElement> function = new Func<IWebDriver, IWebElement>((webDriver) =>
            {
                IWebElement result = null;
                try
                {
                    result = webDriver.JavaScriptExecutor().ExecuteScript($@"return $(""{jquerySelector.Replace("\"", "'")}"").get(0);", new object[0]) as IWebElement;
                }
                catch { }
                return result;
            });
            return function;
        }

        public static Func<IWebDriver, IWebElement> ElementExistsByJavaScript(string jsSelector)
        {
            Func<IWebDriver, IWebElement> function = new Func<IWebDriver, IWebElement>((webDriver) =>
            {
                IWebElement result = null;
                try
                {
                    result = webDriver.JavaScriptExecutor().ExecuteScript($@"return document.querySelectorAll(""{jsSelector.Replace("\"", "'")}"")[0];", new object[0]) as IWebElement;
                }
                catch { }
                return result;
            });
            return function;
        }
    }
}
