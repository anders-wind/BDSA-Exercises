using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ReversePolishCalculator
{
    /// <summary>
    /// A test class which ensures that the reverse Polish calculator works as intended most of the time.
    /// </summary>
    [TestFixture]
    class ReversePolishCalculatorTests
    {

        /// <summary>
        /// Testcase where the input is null - should return 0.
        /// </summary>
        [Test]
        public void TestNullInput()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression(null), 0);
        }

        /// <summary>
        /// Testcase where the input is "" - should return 0.
        /// </summary>
        [Test]
        public void TestEmptyInput()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression(""), 0);
        }

        /// <summary>
        /// Testcase where the input contains a + operator (5 5 +) - should return 10.
        /// </summary>
        [Test]
        public void TestPlusOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 5 +"), 10);
        }

        /// <summary>
        /// Testcase where the input contains a - operator (3 5 -) - should return -2.
        /// </summary>
        [Test]
        public void TestMinusOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("3 5 -"), -2);
        }

        /// <summary>
        /// Testcase where the input contains a * operator (3 4 *) - should return 12.
        /// </summary>
        [Test]
        public void TestMultiplyOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("3 4 *"), 12);
        }

        /// <summary>
        /// Testcase where the input contains a / operator (12 4 *) - should return 3.
        /// </summary>
        [Test]
        public void TestDivideOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("12 4 /"), 3);
        }

        /// <summary>
        /// Testcase where the input contains a pov (^) operator (5 2 pov) - should return 25.
        ///                                                      (2 5 ^) - should return 32.
        /// </summary>
        [Test]
        public void TestPovOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 2 pov"), 25);
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("2 5 pov"), 32);
        }

        /// <summary>
        /// Testcase where the input contains sin operator (30 sin) - should return Math.Sin(30).
        /// </summary>
        [Test]
        public void TestSinOperator()
        {
            Assert.AreEqual((double)ReversePolishCalculator.CalculateExpression("30 sin"), Math.Sin(30), 0.001D);
        }

        /// <summary>
        /// Testcase where the input contains cos operator (30 cos) - should return Math.Cos(30).
        /// </summary>
        [Test]
        public void TestCosOperator()
        {
            Assert.AreEqual((double)ReversePolishCalculator.CalculateExpression("60 cos"), Math.Cos(60), 0.001D);
        }

        /// <summary>
        /// Testcase where the input contains sqrt operator (25 sqrt) - should return Math.Cos(5).
        /// </summary>
        [Test]
        public void TestSqrtOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("25 sqrt"), 5);
        }

        /// <summary>
        /// Testcase where the input contains multiple operators and values.
        /// </summary>
        [Test]
        public void TestComplexExpressionOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 1 2 + 4 * + 3 -"), 14);
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 1 2 pov 4 * + 3 - 3 + sqrt"), 3);
        }

        /// <summary>
        /// Testcase where the input contains letters and letters combined with numbers.
        /// </summary>
        [Test]
        public void TestExpressionWithLettersOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("a b1 2c + +"), 0); // exception
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 a 5 +"), 10);
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("a 5 5 +"), 10);
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 5 a +"), 10);
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("a 5a 5 +"), 0); // exception
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("a 5"), 5); // no calculations
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5"), 5); // no calculations

        }

    }
}
