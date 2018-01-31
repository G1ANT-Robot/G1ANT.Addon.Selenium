using G1ANT.Engine;
using G1ANT.Language;
using NUnit.Framework;
using System;
using System.IO;

namespace G1ANT.Addon.Selenium.Tests
{
    [TestFixture]

    public class SeleniumRunScriptTests
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
        public void BrowsersRunScriptSuccessTest()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.runscript script {SpecialChars.Text}window.setlol = function(e, e2) {{window.lol = e + e2;}}{SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}setlol('ab', 'c'){SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}return lol{SpecialChars.Text}   
                    selenium.close";
            scripter.Run();
            Assert.AreEqual("abc", scripter.Variables.GetVariableValue<string>("result")?.ToLower());

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}edge{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.runscript script {SpecialChars.Text}window.setlol = function(e, e2) {{window.lol = e + e2;}}{SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}setlol('ab', 'c'){SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}return lol;{SpecialChars.Text}   
                    selenium.close";
            scripter.Run();
            Assert.AreEqual("abc", scripter.Variables.GetVariableValue<string>("result")?.ToLower());


            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.runscript script {SpecialChars.Text}window.setlol = function(e, e2) {{window.lol = e + e2;}}{SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}setlol('ab', 'c'){SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}return lol;{SpecialChars.Text}   
                    selenium.close";
            scripter.Run();
            Assert.AreEqual("abc", scripter.Variables.GetVariableValue<string>("result")?.ToLower());

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.runscript script {SpecialChars.Text}window.setlol = function(e, e2) {{window.lol = e + e2;}}{SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}setlol('ab', 'c'){SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}return lol;{SpecialChars.Text}   
                    selenium.close";
            scripter.Run();
            Assert.AreEqual("abc", scripter.Variables.GetVariableValue<string>("result")?.ToLower());
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void BrowsersRunScriptFailTest()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#lst-ib').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.runscript script {SpecialChars.Text}window.setlol = function(e, e2) {{window.lol = e + e2;}}{SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}setlol('ab', 'c'){SpecialChars.Text}
                    selenium.runscript script {SpecialChars.Text}return lol;{SpecialChars.Text}   
                    selenium.close";
            scripter.Run();
        }

        [TearDown]
        public void CleanUp()
        {
            SeleniumTests.KillAllBrowserProcesses();
        }
    }
}
