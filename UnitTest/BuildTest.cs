using CorporateBsGenerator.Services;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class BuildTest
    {
        [Test]
        public void TestCase1()
        {
            Assert.True(true);
        }

        [Test]
        public void TestCase2()
        {
            var subject = new GeneratorService();
            Assert.IsFalse(string.IsNullOrWhiteSpace(subject.Generate()));
        }
    }
}