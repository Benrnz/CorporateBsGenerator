using System;
using System.Collections.Generic;
using CorporateBsGenerator.Service;
using NUnit.Framework;

namespace UnitTest
{
    [TestFixture]
    public class BsServiceTest
    {
        private GeneratorService subject;

        [SetUp]
        public void TestSetup()
        {
            this.subject = new GeneratorService();
        }

        [Test]
        public void Generate_ShouldReturnSomething()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(this.subject.Generate()));
        }

        [Test]
        public void Generate_ShouldReturnDifferentValues()
        {
            var results = new HashSet<int>();
            for (int i = 0; i < 10; i++)
            {
                results.Add(this.subject.Generate().GetHashCode());
            }

            Assert.AreEqual(10, results.Count);
        }
    }
}