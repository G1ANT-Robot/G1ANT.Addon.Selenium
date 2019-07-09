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
using NUnit.Framework;
using System;

namespace G1ANT.Addon.Selenium.Tests
{
    [TestFixture]

    public class SeleniumSetUrlTests
    {
        private Scripter scripter;

        [SetUp]
        public void TestInitialize()
        {
            Language.Addon addon = Language.Addon.Load(@"G1ANT.Addon.Selenium.dll");
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void BrowsersSetUrlFailTest()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}tibia aggs/1223;1'\\1'23./2{SpecialChars.Text}                    
                ";
            Exception exception = Assert.Throws<ApplicationException>(delegate
            {
                scripter.Run();
            });
            Assert.IsInstanceOf<UriFormatException>(exception.GetBaseException());
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void BrowsersSetUrlSuccessTest()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}msz.gov.pl/pl/{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#column1').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.gettitle result {SpecialChars.Variable}result1
                    selenium.seturl url {SpecialChars.Text}minrol.gov.pl{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.gettitle result {SpecialChars.Variable}result2
                    selenium.close
                ";
            scripter.Run();
            Assert.IsTrue(scripter.Variables.GetVariableValue<string>("result1")?.ToLower()?.Contains("spraw") ?? false);
            Assert.IsTrue(scripter.Variables.GetVariableValue<string>("result2")?.ToLower()?.Contains("rolnictwa") ?? false);

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}msz.gov.pl/pl/{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#column1').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.gettitle result {SpecialChars.Variable}result1
                    selenium.seturl url {SpecialChars.Text}minrol.gov.pl{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.gettitle result {SpecialChars.Variable}result2
                    selenium.close
                ";
            scripter.Run();
            Assert.IsTrue(scripter.Variables.GetVariableValue<string>("result1")?.ToLower()?.Contains("spraw") ?? false);
            Assert.IsTrue(scripter.Variables.GetVariableValue<string>("result2")?.ToLower()?.Contains("rolnictwa") ?? false);

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}edge{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}msz.gov.pl/pl/{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#column1').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.gettitle result {SpecialChars.Variable}result1
                    selenium.seturl url {SpecialChars.Text}minrol.gov.pl{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.gettitle result {SpecialChars.Variable}result2
                    selenium.close
                ";
            scripter.Run();
            Assert.IsTrue(scripter.Variables.GetVariableValue<string>("result1")?.ToLower()?.Contains("spraw") ?? false);
            Assert.IsTrue(scripter.Variables.GetVariableValue<string>("result2")?.ToLower()?.Contains("rolnictwa") ?? false);

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}ie{SpecialChars.Text}
                    selenium.seturl url {SpecialChars.Text}msz.gov.pl/pl/{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('#column1').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.gettitle result {SpecialChars.Variable}result1
                    selenium.seturl url {SpecialChars.Text}minrol.gov.pl{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.gettitle result {SpecialChars.Variable}result2
                    selenium.close
                ";
            scripter.Run();
            Assert.IsTrue(scripter.Variables.GetVariableValue<string>("result1")?.ToLower()?.Contains("spraw") ?? false);
            Assert.IsTrue(scripter.Variables.GetVariableValue<string>("result2")?.ToLower()?.Contains("rolnictwa") ?? false);
        }

        [TearDown]
        public void CleanUp()
        {
            SeleniumTests.KillAllBrowserProcesses();
        }
    }
}
