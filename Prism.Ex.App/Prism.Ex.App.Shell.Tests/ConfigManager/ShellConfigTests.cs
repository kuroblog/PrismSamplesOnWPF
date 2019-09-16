using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics.CodeAnalysis;

namespace Prism.Ex.App.Shell.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ShellConfigTests
    {
        //private class TestShellConfig : ShellConfig { }

        //private readonly TestShellConfig tsc = new TestShellConfig();

        private readonly ShellConfig tsc = new ShellConfig();

        [TestMethod]
        public void ProductNameTest()
        {
            var res = tsc.ProductName;
            Assert.AreEqual("Prism Demo on WPF", res);
        }

        [TestMethod]
        public void ShellWidthTest()
        {
            var res = tsc.ShellWidth;
            Assert.AreEqual(1280, res);
        }

        [TestMethod]
        public void ShellWidthWhenInvalidTest()
        {
            var testKey = nameof(tsc.ShellWidth);

            var testValue = tsc.ReadAppSetting(testKey);
            Assert.AreEqual(false, string.IsNullOrEmpty(testValue));

            tsc.SaveAppSetting(testKey, "");

            var res = tsc.ShellWidth;
            Assert.AreEqual(1280, res);

            tsc.SaveAppSetting(testKey, testValue);
        }

        [TestMethod]
        public void ShellHeightTest()
        {
            var res = tsc.ShellHeight;
            Assert.AreEqual(960, res);
        }

        [TestMethod]
        public void ShellHeightWhenInvalidTest()
        {
            var testKey = nameof(tsc.ShellHeight);

            var testValue = tsc.ReadAppSetting(testKey);
            Assert.AreEqual(false, string.IsNullOrEmpty(testValue));

            tsc.SaveAppSetting(testKey, "");

            var res = tsc.ShellHeight;
            Assert.AreEqual(960, res);

            tsc.SaveAppSetting(testKey, testValue);
        }
    }
}