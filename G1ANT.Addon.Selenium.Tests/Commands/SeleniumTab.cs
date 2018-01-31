using G1ANT.Engine;
using G1ANT.Language;
using G1ANT.Language.Semantic;
using NUnit.Framework;
using System;
using System.IO;

namespace G1ANT.Addon.Selenium.Tests
{
    [TestFixture]

    public class SeleniumTabTests
    {
        private Scripter scripter;

        [SetUp]
        public void TestInitialize()
        {
            Language.Addon addon = Language.Addon.Load(@"G1ANT.Addon.Selenium.dll");
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void SeleniumTabAlLBrowsersTests()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text} url {SpecialChars.Text}msz.gov.pl{SpecialChars.Text} nowait true
                    selenium.newtab url {SpecialChars.Text}minrol.gov.pl{SpecialChars.Text}
                    selenium.activatetab search {SpecialChars.Text}msz{SpecialChars.Text} by {SpecialChars.Text}url{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}tibia.com{SpecialChars.Text}
                    selenium.activatetab search {SpecialChars.Text}minrol{SpecialChars.Text} by {SpecialChars.Text}url{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}tibia.com{SpecialChars.Text}
                    selenium.close

                    selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}msz.gov.pl{SpecialChars.Text} nowait true
                    selenium.newtab url {SpecialChars.Text}minrol.gov.pl{SpecialChars.Text}
                    selenium.activatetab search {SpecialChars.Text}msz{SpecialChars.Text} by {SpecialChars.Text}url{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}tibia.com{SpecialChars.Text}
                    selenium.activatetab search {SpecialChars.Text}minrol{SpecialChars.Text} by {SpecialChars.Text}url{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}tibia.com{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
        }

        [TearDown]
        public void CleanUp()
        {
            SeleniumTests.KillAllBrowserProcesses();
        }
    }
}
