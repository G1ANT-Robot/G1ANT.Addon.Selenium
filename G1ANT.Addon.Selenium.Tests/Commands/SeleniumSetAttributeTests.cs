using G1ANT.Engine;
using G1ANT.Language;
using NUnit.Framework;
using System;
using System.IO;

namespace G1ANT.Addon.Selenium.Tests
{
    [TestFixture]
    public class SeleniumSetAttributeTests
    {
        private Scripter scripter;
        private string pageAddress = "google.pl";

        [SetUp]
        public void TestInitialize()
        {
            Language.Addon addon = Language.Addon.Load(@"G1ANT.Addon.Selenium.dll");
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void BrowsersSetAttributesSuccessTest()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.setattribute name {SpecialChars.Text}title{SpecialChars.Text} value lol search {SpecialChars.Text}hplogo{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.getattribute name {SpecialChars.Text}title{SpecialChars.Text} search {SpecialChars.Text}hplogo{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
            Assert.AreEqual("lol", scripter.Variables.GetVariableValue<string>("result")?.ToLower());

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.setattribute name {SpecialChars.Text}title{SpecialChars.Text} value lol search {SpecialChars.Text}hplogo{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.getattribute name {SpecialChars.Text}title{SpecialChars.Text} search {SpecialChars.Text}hplogo{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
            Assert.AreEqual("lol", scripter.Variables.GetVariableValue<string>("result")?.ToLower());

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}edge{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.setattribute name {SpecialChars.Text}title{SpecialChars.Text} value lol search {SpecialChars.Text}hplogo{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.getattribute name {SpecialChars.Text}title{SpecialChars.Text} search {SpecialChars.Text}hplogo{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
            Assert.AreEqual("lol", scripter.Variables.GetVariableValue<string>("result")?.ToLower());

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.setattribute name {SpecialChars.Text}title{SpecialChars.Text} value lol search {SpecialChars.Text}hplogo{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.getattribute name {SpecialChars.Text}title{SpecialChars.Text} search {SpecialChars.Text}hplogo{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
            Assert.AreEqual("lol", scripter.Variables.GetVariableValue<string>("result")?.ToLower());
        }

        [TearDown]
        public void CleanUp()
        {
            SeleniumTests.KillAllBrowserProcesses();
        }
    }
}
