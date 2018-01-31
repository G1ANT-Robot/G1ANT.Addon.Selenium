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
