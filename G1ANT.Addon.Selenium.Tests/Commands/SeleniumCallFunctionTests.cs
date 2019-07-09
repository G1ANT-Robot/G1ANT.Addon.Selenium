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
using System.Threading;

namespace G1ANT.Addon.Selenium.Tests
{
    [TestFixture]
    public class SeleniumCallFunctionTests
    {
        private Scripter scripter;

        [SetUp]
        public void TestInitialize()
        {
            Language.Addon addon = Language.Addon.Load(@"G1ANT.Addon.Selenium.dll");
            Environment.CurrentDirectory = TestContext.CurrentContext.TestDirectory;
        }

        [Test, Timeout(SeleniumTests.TestTimeout)]
        public void CallFunctionTests()
        {
            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                selenium.open type {SpecialChars.Text}ie{SpecialChars.Text} url {SpecialChars.Text}msn.com{SpecialChars.Text} timeout 30000
                list.create text {SpecialChars.Text}aa{SpecialChars.Text}  result {SpecialChars.Variable}lista
                selenium.callfunction search {SpecialChars.Text}q{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} functionname {SpecialChars.Text}val{SpecialChars.Text} parameters {SpecialChars.Variable}lista type {SpecialChars.Text}jquery{SpecialChars.Text}
                selenium.runscript script {SpecialChars.Text}return $('#q').val();{SpecialChars.Text} result {SpecialChars.Variable}wynik

                list.create text {SpecialChars.Text}id{SpecialChars.Text} result {SpecialChars.Variable}lista
                selenium.callfunction search {SpecialChars.Text}q{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} functionname {SpecialChars.Text}getAttribute{SpecialChars.Text} parameters {SpecialChars.Variable}lista type {SpecialChars.Text}javascript{SpecialChars.Text}
                selenium.close";
            scripter.Run();
            Assert.AreEqual("aa", scripter.Variables.GetVariableValue<string>("wynik"));

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                selenium.open type {SpecialChars.Text}edge{SpecialChars.Text} url {SpecialChars.Text}msn.com{SpecialChars.Text} timeout 30000
                list.create text {SpecialChars.Text}aa{SpecialChars.Text}  result lista
                selenium.callfunction search {SpecialChars.Text}q{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} functionname {SpecialChars.Text}val{SpecialChars.Text} parameters ♥lista type {SpecialChars.Text}jquery{SpecialChars.Text}
                selenium.runscript script {SpecialChars.Text}return $('#q').val();{SpecialChars.Text} result {SpecialChars.Variable}wynik

                list.create text {SpecialChars.Text}id{SpecialChars.Text} result lista
                selenium.callfunction search {SpecialChars.Text}q{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} functionname {SpecialChars.Text}getAttribute{SpecialChars.Text} parameters ♥lista type {SpecialChars.Text}javascript{SpecialChars.Text}
                selenium.close";
            scripter.Run();
            Assert.AreEqual("aa", scripter.Variables.GetVariableValue<string>("wynik"));

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                selenium.open type {SpecialChars.Text}firefox{SpecialChars.Text} url {SpecialChars.Text}msn.com{SpecialChars.Text} timeout 30000
                list.create text {SpecialChars.Text}aa{SpecialChars.Text}  result lista
                selenium.callfunction search {SpecialChars.Text}q{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} functionname {SpecialChars.Text}val{SpecialChars.Text} parameters ♥lista type {SpecialChars.Text}jquery{SpecialChars.Text}
                selenium.runscript script {SpecialChars.Text}return $('#q').val();{SpecialChars.Text} result {SpecialChars.Variable}wynik

                list.create text {SpecialChars.Text}id{SpecialChars.Text} result lista
                selenium.callfunction search {SpecialChars.Text}q{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} functionname {SpecialChars.Text}getAttribute{SpecialChars.Text} parameters ♥lista type {SpecialChars.Text}javascript{SpecialChars.Text}
                selenium.close";
            scripter.Run();
            Assert.AreEqual("aa", scripter.Variables.GetVariableValue<string>("wynik"));

            scripter = new Scripter();
scripter.InitVariables.Clear();
            scripter.Text = $@"
                selenium.open type {SpecialChars.Text}chrome{SpecialChars.Text} url {SpecialChars.Text}msn.com{SpecialChars.Text} timeout 30000
                list.create text {SpecialChars.Text}aa{SpecialChars.Text}  result lista
                selenium.callfunction search {SpecialChars.Text}q{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} functionname {SpecialChars.Text}val{SpecialChars.Text} parameters ♥lista type {SpecialChars.Text}jquery{SpecialChars.Text}
                selenium.runscript script {SpecialChars.Text}return $('#q').val();{SpecialChars.Text} result {SpecialChars.Variable}wynik

                list.create text {SpecialChars.Text}id{SpecialChars.Text} result lista
                selenium.callfunction search {SpecialChars.Text}q{SpecialChars.Text} by {SpecialChars.Text}id{SpecialChars.Text} functionname {SpecialChars.Text}getAttribute{SpecialChars.Text} parameters ♥lista type {SpecialChars.Text}javascript{SpecialChars.Text}
                selenium.close";
            scripter.Run();
            Assert.AreEqual("aa", scripter.Variables.GetVariableValue<string>("wynik"));
        }

        [TearDown]
        public void CleanUp()
        {
            SeleniumTests.KillAllBrowserProcesses();
        }
    }
}
