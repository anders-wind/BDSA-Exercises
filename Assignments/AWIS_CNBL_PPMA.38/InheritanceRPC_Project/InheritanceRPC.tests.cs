using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InheritanceRPC_Project
{
    [TestFixture]
    class InheritanceRPCtests
    {
        private InheritanceRPC iRPC;

        [SetUp]
        public void Setup()
        {
            iRPC = new InheritanceRPC();
        }

        /// <summary>
        /// Testcase where the input is null - should return 0.
        /// </summary>
        [Test]
        public void TestNullInput()
        {
            Assert.AreEqual(0, iRPC.CalculateExpression(null));
        }

        /// <summary>
        /// Testcase where the input is "" - should return 0.
        /// </summary>
        [Test]
        public void TestEmptyInput()
        {
            Assert.AreEqual(0, iRPC.CalculateExpression(""));
        }

        /// <summary>
        /// Testcase where the input contains a + operator (5 5 +) - should return 10.
        /// </summary>
        [Test]
        public void TestPlusOperator()
        {
            Assert.AreEqual(10,5, iRPC.CalculateExpression("5,0 5,5 +"));
            Assert.AreEqual(10, iRPC.CalculateExpression("5 5 +"));
        }

        /// <summary>
        /// Testcase where the input contains a - operator (3 5 -) - should return -2.
        /// </summary>
        [Test]
        public void TestMinusOperator()
        {
            Assert.AreEqual(2, iRPC.CalculateExpression("5 3 -"));
            Assert.AreEqual(2,5, iRPC.CalculateExpression("5,5 3,0 -"));
        }

        /// <summary>
        /// Testcase where the input contains a * operator (3 4 *) - should return 12.
        /// </summary>
        [Test]
        public void TestMultiplyOperator()
        {
            Assert.AreEqual(12, iRPC.CalculateExpression("3 4 *"));
            Assert.AreEqual(13,5, iRPC.CalculateExpression("3,0 4,5 *"));
        }

        /// <summary>
        /// Testcase where the input contains a / operator (12 4 *) - should return 3.
        /// </summary>
        [Test]
        public void TestDivideOperator()
        {
            Assert.AreEqual(3, iRPC.CalculateExpression("12 4 /"));
            Assert.AreEqual(3.1, iRPC.CalculateExpression("12,4 4,0 /"));
        }

        /// <summary>
        /// Testcase where the input contains a pov (^) operator (5 2 pov) - should return 25.
        ///                                                      (2 5 ^) - should return 32.
        /// </summary>
        [Test]
        public void TestPowOperator()
        {
            Assert.AreEqual(25, iRPC.CalculateExpression("5 2 pow"));
            Assert.AreEqual(32, iRPC.CalculateExpression("2 5 pow"));
            Assert.AreEqual(25,0, iRPC.CalculateExpression("5,0 2,0 pow"));
            Assert.AreEqual(32,0, iRPC.CalculateExpression("2,0 5,0 pow"));
        }

        /// <summary>
        /// Testcase where the input contains sin operator (30 sin) - should return Math.Sin(30).
        /// </summary>
        [Test]
        public void TestSinOperator()
        {
            Assert.AreEqual(Math.Sin(30),iRPC.CalculateExpression("30 sin"), 0.001D);
            Assert.AreEqual(Math.Sin(30), iRPC.CalculateExpression("30,0 sin"), 0.001D);
        }

        /// <summary>
        /// Testcase where the input contains cos operator (30 cos) - should return Math.Cos(30).
        /// </summary>
        [Test]
        public void TestCosOperator()
        {
            Assert.AreEqual(Math.Cos(60), iRPC.CalculateExpression("60 cos"), 0.001D);
            Assert.AreEqual(Math.Cos(60), iRPC.CalculateExpression("60,0 cos"), 0.001D);
        }

        /// <summary>
        /// Testcase where the input contains sqrt operator (25 sqrt) - should return Math.Cos(5).
        /// </summary>
        [Test]
        public void TestSqrtOperator()
        {
            Assert.AreEqual(5, iRPC.CalculateExpression("25 sqrt"));
            Assert.AreEqual(5,0, iRPC.CalculateExpression("25,0 sqrt"));
        }

        /// <summary>
        /// Testcase where the input contains abs operator (25 abs, -25 abs, 0 abs, -0 abs) - should return Math.Cos(5).
        /// </summary>
        [Test]
        public void TestAbsOperator()
        {
            Assert.AreEqual(25, iRPC.CalculateExpression("25 abs"));
            Assert.AreEqual(25, iRPC.CalculateExpression("-25 abs"));
            Assert.AreEqual(0, iRPC.CalculateExpression("0 abs"));
            Assert.AreEqual(0, iRPC.CalculateExpression("-0 abs"));

            Assert.AreEqual(25,0, iRPC.CalculateExpression("25,0 abs"));
            Assert.AreEqual(25,0, iRPC.CalculateExpression("-25,0 abs"));
            Assert.AreEqual(0,0, iRPC.CalculateExpression("0,0 abs"));
            Assert.AreEqual(0,0, iRPC.CalculateExpression("-0,0 abs"));
        }

        /// <summary>
        /// Testcase where the input contains multiple operators and values.
        /// </summary>
        [Test]
        public void TestComplexExpressionOperator()
        {
            Assert.AreEqual(14, iRPC.CalculateExpression("5 1 2 + 4 * + 3 -"));
            Assert.AreEqual(3, iRPC.CalculateExpression("5 1 2 pow 4 * + 3 - 3 + sqrt"));

            Assert.AreEqual(14,0, iRPC.CalculateExpression("5,0 1,0 2,0 + 4,0 * + 3,0 -"));
            Assert.AreEqual(3,0, iRPC.CalculateExpression("5,0 1,0 2,0 pow 4,0 * + 3,0 - 3,0 + sqrt"));
        }

        /// <summary>
        /// Testcase where the input contains letters and letters combined with numbers.
        /// </summary>
        [Test]
        public void TestExpressionWithLettersOperator()
        {
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("a b1 2c + +")); // exception
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("5 a 5 +"));
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("a 5 5 +"));
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("5 5 a +"));
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("a 5a 5 +")); // exception
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("a 5")); // no calculations
            Assert.AreEqual(5, iRPC.CalculateExpression("5")); // no calculations

            Assert.Throws<Exception>(() => iRPC.CalculateExpression("a b,01 2,0c + +")); // exception
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("5,0 a 5,0 +"));
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("a 5,0 5,0 +"));
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("5,0 5 a +"));
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("a 5,0a 5,0 +")); // exception
            Assert.Throws<Exception>(() => iRPC.CalculateExpression("a 5,0")); // no calculations
            Assert.AreEqual(5,0, iRPC.CalculateExpression("5,0")); // no calculations

        }
    }
}
