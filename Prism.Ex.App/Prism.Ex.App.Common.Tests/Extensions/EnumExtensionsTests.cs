using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using SCM = System.ComponentModel;

namespace Prism.Ex.App.Common.Tests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class EnumExtensionsTests
    {
        private enum TestModel
        {
            A,
            [SCM.Description("测试B")]
            B,
            C
        }

        [TestMethod]
        public void GetDescriptionTest()
        {
            var resA = TestModel.A.GetDescription();
            Assert.AreEqual(null, resA);

            var resB = TestModel.B.GetDescription();
            Assert.AreEqual("测试B", resB);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void GetDescriptionByInvalidTypeTest()
        {
            "".GetDescription();
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void GetDescriptionByNullTest()
        {
            object a = null;
            a.GetDescription();
        }
    }
}