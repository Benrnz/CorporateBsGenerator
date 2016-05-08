using NUnit.Framework;

namespace CorporateBsGenerator.UnitTest
{
    [TestFixture]
    public class ExperimentalTests
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(2, 1 + 1);
        }

        [Test]
        public void Test2()
        {
            Assert.AreEqual(5, 2 + 2);
        }
    }
}
