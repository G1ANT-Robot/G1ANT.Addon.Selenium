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
using System.IO;

namespace G1ANT.Addon.Selenium.Tests
{
    [TestFixture]
    public class SeleniumGetAttributeTests
    {
        private string pageAddress = "minrol.gov.pl";

        [SetUp]
        public void TestInitialize()
        {
            Language.Addon addon = Language.Addon.Load(@"G1ANT.Addon.Selenium.dll");
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        private Scripter scripter;

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void BrowsersGetAttributesSuccessTest()
        {
            scripter = new Scripter();
            scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.getattribute name {SpecialChars.Text}class{SpecialChars.Text} search {SpecialChars.Text}content{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
            Assert.AreEqual("main", scripter.Variables.GetVariableValue<string>("result")?.ToLower());


            scripter = new Scripter();
            scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.getattribute name {SpecialChars.Text}class{SpecialChars.Text} search {SpecialChars.Text}content{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
            Assert.AreEqual("main", scripter.Variables.GetVariableValue<string>("result")?.ToLower());

            scripter = new Scripter();
            scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.getattribute name {SpecialChars.Text}class{SpecialChars.Text} search {SpecialChars.Text}content{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
            Assert.AreEqual("main", scripter.Variables.GetVariableValue<string>("result")?.ToLower());

            scripter = new Scripter();
            scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}edge{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.getattribute name {SpecialChars.Text}class{SpecialChars.Text} search {SpecialChars.Text}content{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text}
                    selenium.close
                ";
            scripter.Run();
            Assert.AreEqual("main", scripter.Variables.GetVariableValue<string>("result")?.ToLower());
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void FirefoxGetAttributesFailureTest()
        {
            scripter = new Scripter();
            scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.getattribute name {SpecialChars.Text}title{SpecialChars.Text} search {SpecialChars.Text}abcdefgh{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} timeout 1500
                    selenium.close
                ";
            Exception exception = Assert.Throws<ApplicationException>(delegate
            {
                scripter.Run();
            });
            Assert.IsInstanceOf<TimeoutException>(exception.GetBaseException());
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void EdgeGetAttributesFailureTest()
        {
            scripter = new Scripter();
            scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}edge{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.getattribute name {SpecialChars.Text}title{SpecialChars.Text} search {SpecialChars.Text}abcdefgh{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} timeout 1500
                    selenium.close
                ";
            Exception exception = Assert.Throws<ApplicationException>(delegate
            {
                scripter.Run();
            });
            Assert.IsInstanceOf<TimeoutException>(exception.GetBaseException());
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void IeGetAttributesFailureTest()
        {
            scripter = new Scripter();
            scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.getattribute name {SpecialChars.Text}title{SpecialChars.Text} search {SpecialChars.Text}abcdefgh{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} timeout 1500
                    selenium.close
                ";
            Exception exception = Assert.Throws<ApplicationException>(delegate
            {
                scripter.Run();
            });
            Assert.IsInstanceOf<TimeoutException>(exception.GetBaseException());
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void ChromeGetAttributesFailureTest()
        {
            scripter = new Scripter();
            scripter.InitVariables.Clear();
            scripter.Text = $@"
                    selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text} url {SpecialChars.Text}{pageAddress}{SpecialChars.Text}
                    selenium.waitforvalue script {SpecialChars.Text}return document.querySelectorAll('img[src=""/bundles/webhqminrolbiplayout/images/bip-logo.png""]').length > 0{SpecialChars.Text} expectedvalue {SpecialChars.Text}true{SpecialChars.Text} timeout 20000
                    selenium.getattribute name {SpecialChars.Text}title{SpecialChars.Text} search {SpecialChars.Text}abcdefgh{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} timeout 1500
                    selenium.close
                ";
            Exception exception = Assert.Throws<ApplicationException>(delegate
            {
                scripter.Run();
            });
            Assert.IsInstanceOf<TimeoutException>(exception.GetBaseException());
        }

        [TearDown]
        public void CleanUp()
        {
            SeleniumTests.KillAllBrowserProcesses();
        }
    }
}
