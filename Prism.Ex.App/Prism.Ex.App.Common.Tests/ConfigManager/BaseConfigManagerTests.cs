using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Prism.Ex.App.Common.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class BaseConfigManagerTests
    {
        private class TestConfigManager : BaseConfigManager { }

        private readonly TestConfigManager tcm = new TestConfigManager();

        [TestMethod]
        public void ReadAppSettingTest()
        {
            var res = tcm.ReadAppSetting("Version");
            Assert.AreEqual("1.0.0.0", res);
        }

        [TestMethod]
        public void SaveAppSettingTest()
        {
            var testKey = "TestSave";

            var testValue = Guid.NewGuid().ToString("N");
            tcm.SaveAppSetting(testKey, testValue);

            var res = tcm.ReadAppSetting(testKey);
            Assert.AreEqual(testValue, res);
        }

        [TestMethod]
        public void SaveAppSettingWhenNewKeyTest()
        {
            var testKey = Guid.NewGuid().ToString("N");

            tcm.SaveAppSetting(testKey, testKey);

            var res = tcm.ReadAppSetting(testKey);
            Assert.AreEqual(testKey, res);

            tcm.RemoveAppSetting(testKey);
        }

        [TestMethod]
        public void ReadConnectionStringTest()
        {
            var res = tcm.ReadConnectionString("TestConnection");
            Assert.AreEqual("TestConnectionString", res);
        }

        [TestMethod]
        public void ReadAllTextTest()
        {
            var res = tcm.ReadAllText(Assembly.GetExecutingAssembly().Location.Replace("dll", "txt"));
            Assert.AreEqual("HelloWorld", res);
        }

        [TestMethod, ExpectedException(typeof(NullReferenceException))]
        public void RemoveAppSettingTest()
        {
            var testKey = "TestRemove";

            var res = tcm.ReadAppSetting(testKey);
            Assert.AreEqual("12333", res);

            tcm.RemoveAppSetting(testKey);

            tcm.ReadAppSetting(testKey);
        }

        [TestMethod]
        public void ModuleVersionTest()
        {
            var res = tcm.ModuleVersion;
            Assert.AreEqual("1.0.0.9", res);
        }
    }
}