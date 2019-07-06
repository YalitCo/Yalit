using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yalit.Core.Test
{
    [TestClass]
    public class GlobalUnitTest
    {
        [TestMethod]
        public void TestToInt()
        {
            Assert.AreEqual(1000, "1000".ToInt());

            Assert.AreEqual(0, "asda".ToInt());

            Assert.AreEqual(125420000, "125420000".ToInt());

            Assert.AreEqual(1, 1.1.ToInt());
        }

        [TestMethod]
        public void TestToDouble()
        {
            Assert.AreEqual(1000, "1000".ToDouble());

            Assert.AreEqual(0, "asda".ToDouble());

            Assert.AreEqual(125420000, "125420000".ToDouble());

            Assert.AreEqual(1.1, "1.1".ToDouble());
        }
        
    }
}
