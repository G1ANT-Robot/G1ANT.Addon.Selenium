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
