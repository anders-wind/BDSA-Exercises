using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ReversePolishCalculator
{
    [TestFixture]
    class ReversePolishCalculatorTests
    {

        [Test]
        public void TestNullInput()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression(null), 0);
        }

        [Test]
        public void TestEmptyInput()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression(""), 0);
        }

        [Test]
        public void TestPlusOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 5 +"), 10);
        }

        [Test]
        public void TestMinusOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("3 5 -"), -2);
        }

        [Test]
        public void TestMultiplyOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("3 4 *"), 12);
        }

        [Test]
        public void TestDivideOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("12 4 /"), 3);
        }

        [Test]
        public void TestPovOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 2 pov"), 25);
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("2 5 pov"), 32);
        }

        [Test]
        public void TestSinOperator()
        {
            Assert.AreEqual((double)ReversePolishCalculator.CalculateExpression("30 sin"), Math.Sin(30), 0.001D);
        }

        [Test]
        public void TestCosOperator()
        {
            Assert.AreEqual((double)ReversePolishCalculator.CalculateExpression("60 cos"), Math.Cos(60), 0.001D);
        }

        [Test]
        public void TestSqrtOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("25 sqrt"), 5);
        }

        [Test]
        public void TestExpressionOperator()
        {
            Assert.AreEqual(ReversePolishCalculator.CalculateExpression("5 1 2 + 4 * + 3 -"), 14);
        }

    }
}
