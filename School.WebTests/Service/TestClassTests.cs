using Microsoft.VisualStudio.TestTools.UnitTesting;
using School.Web.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Web.Service.Tests
{
    [TestClass()]
    public class TestClassTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var a = 10;
            var b = 20;
            var expectedResult = 30;
            var test = new TestClass();
            var actualResult = test.Add(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void AddTestV2()
        {
            var a = 0;
            var b = 0;
            var expectedResult = 0;
            var test = new TestClass();
            var actualResult = test.Add(a, b);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod()]
        public void SubtectTest()
        {
            var a = 10;
            var b = 10;
            var expected = 0;
            var test = new TestClass();
            var actualResult = test.Subtract(a, b);
            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod()]
        public void SubtectTestV2()
        {
            var a = 0;
            var b = 0;
            var expected = 0;
            var test = new TestClass();
            var actualResult = test.Subtract(a, b);
            Assert.AreEqual(expected, actualResult);
        }

        [TestMethod()]
        public void TaxTestV1()
        {
            var a = 100;
            var expected = 113d;
            var test = new TestClass();
            var actualResult = test.CalculateTax(a);
            Assert.AreEqual(expected, actualResult);
        }
    }
}