
namespace Prism.Ex.App.Common.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Diagnostics.CodeAnalysis;
    using SCM = System.ComponentModel;

    [ExcludeFromCodeCoverage]
    [TestClass]
    public class ExpressionSupportTests
    {
        private class TestModel
        {
            public string A { get; set; }

            [SCM.Description("测试B")]
            public static string B { get; set; }

            public string c = "";
        }

        private readonly TestModel tm = new TestModel();

        [TestMethod]
        public void ExtractPropertyNameTest()
        {
            var resA = ExpressionSupport.ExtractPropertyName(() => tm.A);
            Assert.AreEqual(nameof(tm.A), resA);

            var resB = ExpressionSupport.ExtractPropertyName(() => TestModel.B);
            Assert.AreEqual(nameof(TestModel.B), resB);

            //var resC = ExpressionSupport.ExtractPropertyName(() => tm.c);
            //Assert.AreEqual(nameof(tm.c), resC);
        }

        [TestMethod]
        public void ExtractPropertyDescriptionTest()
        {
            var resA = ExpressionSupport.ExtractPropertyDescription(() => tm.A);
            Assert.AreEqual(null, resA);

            var resB = ExpressionSupport.ExtractPropertyDescription(() => TestModel.B);
            Assert.AreEqual("测试B", resB);
        }
    }
}