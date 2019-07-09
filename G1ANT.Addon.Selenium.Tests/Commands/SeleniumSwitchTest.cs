/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/
using G1ANT.Engine;
using G1ANT.Language;
using G1ANT.Language.Semantic;
using NUnit.Framework;
using System;

namespace G1ANT.Addon.Selenium.Tests
{
    [TestFixture]

    public class SeleniumSwitchTests
    {
        [SetUp]
        public void TestInitialize()
        {
            Language.Addon addon = Language.Addon.Load(@"G1ANT.Addon.Selenium.dll");
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        private Scripter scripter;

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void SeleniumSwitchTest()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                        selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text} url {SpecialChars.Text}msz.gov.pl{SpecialChars.Text}
                        selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}www.nasa.gov{SpecialChars.Text} nowait true
                        selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}sauletech.com{SpecialChars.Text} nowait true
                        selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}www.minrol.gov.pl{SpecialChars.Text} nowait true
                        selenium.open type {SpecialChars.Text}edge{SpecialChars.Text} url {SpecialChars.Text}https://www.gov.pl/cyfryzacja/ {SpecialChars.Text}
                        selenium.switch 0
                        selenium.switch 1
                        selenium.switch 2
                        selenium.switch 3
                        selenium.switch 4
                ";
            scripter.Run();
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void SeleniumSwitchFailTest()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                        selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text} url {SpecialChars.Text}msz.gov.pl{SpecialChars.Text}
                        selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}www.nasa.gov{SpecialChars.Text} nowait true
                        selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}sauletech.com{SpecialChars.Text} nowait true
                        selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}www.minrol.gov.pl{SpecialChars.Text} nowait true
                        selenium.switch 0
                        selenium.switch 1
                        selenium.switch 2
                        selenium.switch 3
                        selenium.switch 4
                ";
            Exception exception = Assert.Throws<ApplicationException>(delegate
            {
                scripter.Run();
            });
            Assert.IsInstanceOf<InvalidOperationException>(exception.GetBaseException());
        }

        [TearDown]
        public void CleanUp()
        {
            SeleniumTests.KillAllBrowserProcesses();
        }
    }
}
