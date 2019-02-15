using G1ANT.Tests;
using NUnit.Framework;
using System;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;

namespace G1ANT.Addon.Selenium.Tests
{
    /// <summary>
    /// Summary description for SeleniumVersionTest
    /// </summary>
    [TestFixture]
    [TestCategory(TestCategories.Slow)]
    public class SeleniumVersionTest
    {

        [Test]
        public void ValidateSeleniumVersion()
        {
            int result = -1;
            using (WebClient client = new WebClient())
            {
                var ourVersion = Assembly.Load("WebDriver").GetName().Version;
                var pattern = $@"Selenium.WebDriver -Version (\d+(?:\.\d+)+)";
                var page = client.DownloadString("https://www.nuget.org/packages/Selenium.WebDriver");
                Regex regex = new Regex(pattern);
                Match match = regex.Match(page);
                var siteVersion = new Version(match.Groups[1].ToString());
                result = ourVersion.CompareTo(siteVersion);
            }
            Assert.IsTrue(result >= 0);
        }
    }
}
