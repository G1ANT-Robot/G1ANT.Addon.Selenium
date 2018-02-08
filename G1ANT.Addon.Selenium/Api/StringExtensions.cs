/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/
using System.Linq;

namespace G1ANT.Addon.Selenium
{
    public static class StringExtensions
    {
        public static string CapitalizeFirstLetter(this string text)
        {
            if (string.IsNullOrEmpty(text) == false)
            {
                return text.First().ToString().ToUpper() + text.Substring(1).ToLower();
            }
            else
            {
                return text;
            }
        }
    }
}
