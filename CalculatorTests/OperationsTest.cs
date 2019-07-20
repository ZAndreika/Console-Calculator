using System;
using System.Collections.Generic;
using ConsoleCalculator.Converters;
using ConsoleCalculator.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class OperationsTest
    {
        [TestMethod]
        public void TestPlus()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("2+3");
            double expected = 5;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUnaryPlus()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("+32");
            double expected = 32;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMinus()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("2+3");
            double expected = 5;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestUnaryMinus()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("-8");
            double expected = -8;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMult()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("2.5*3");
            double expected = 7.5;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDiv()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("8/2");
            double expected = 4;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDivRemainder()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("12.5%3");
            double expected = 0.5;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestExp()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("2^3");
            double expected = 8;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSqrt()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("sqrt(100)");
            double expected = 10;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestFactorial()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("5!");
            double expected = 120;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSin()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("sin(pi/2)");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCos()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("cos(0)");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTg()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("tg(0)");
            double expected = 0;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCtg()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("ctg(pi/4)");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLog()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("log(e)");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLogicOR()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("1||0");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLogicAND()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("1&&0");
            double expected = 0;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLogicNOT()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("not(1)");
            double expected = 0;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBitOR()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("4 or 2");
            double expected = 6;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBitXOR()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("7 xor 2");
            double expected = 5;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBitAND()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("11 and 5");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBitLSH()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("4 << 2");
            double expected = 16;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBitRSH()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("12 >> 2");
            double expected = 3;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEqual()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("3 == 3");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNotEqual()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("3 != 3");
            double expected = 0;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMore()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("3 > 3");
            double expected = 0;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMoreOrEqual()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("3 >= 3");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLess()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("3 < 5");
            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLessOrEqual()
        {
            List<Token> mathExpression = StringConverter.ConvertToTokensExpression("6 <= 5");
            double expected = 0;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }
    }
}
