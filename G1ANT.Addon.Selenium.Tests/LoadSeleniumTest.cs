/**
*    Copyright(C) G1ANT Ltd, All rights reserved
*    Solution G1ANT.Addon, Project G1ANT.Addon.Selenium
*    www.g1ant.com
*
*    Licensed under the G1ANT license.
*    See License.txt file in the project root for full license information.
*
*/
using System;
using NUnit.Framework;

namespace G1ANT.Addon.Selenium.Tests
{
    [TestFixture]
    public class SeleniumLoadTests
    {
        [Test]
        public void LoadSelleniumAddon()
        {
            Language.Addon addon = Language.Addon.Load("G1ANT.Addon.Selenium.dll");
            Assert.IsNotNull(addon);
            Assert.IsTrue(addon.Commands.Count > 0);
        }
    }
}
