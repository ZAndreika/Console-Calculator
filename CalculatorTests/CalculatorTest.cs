using System.Collections.Generic;
using ConsoleCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CalculatorTest
    {
        [TestMethod]
        public void TestEasyCalculateExpression()
        {
            // 2+3
            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.VARIABLE, "3")
            };

            double expected = 5;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMediumCalculateExpression()
        {
            // sqrt(-2+3)*4.5

            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.UNARY_OPERATION, "sqrt"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "4,5")
            };

            double expected = 4.5;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHardCalculateExpression()
        {
            // -sqrt(-4+5*(-2)^2)*2.5

            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "sqrt"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "4"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.VARIABLE, "5"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "^"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "2,5")
            };

            double expected = -10;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEasyCalculateLogicExpression()
        {
            // not(1)||0

            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.UNARY_OPERATION, "not"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.VARIABLE, "1"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "||"),
                new Token(TOKEN_TYPE.VARIABLE, "0"),
            };

            double expected = 0;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMediumCalculateLogicExpression()
        {
            // (not(1)||0)&&(1||0)

            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "not"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.VARIABLE, "1"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "||"),
                new Token(TOKEN_TYPE.VARIABLE, "0"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "&&"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.VARIABLE, "1"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "||"),
                new Token(TOKEN_TYPE.VARIABLE, "0"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
            };

            double expected = 0;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHardCalculateLogicExpression()
        {
            // (2>=1)||(0==2)&&(1>0)

            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, ">="),
                new Token(TOKEN_TYPE.VARIABLE, "1"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "||"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.VARIABLE, "0"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "=="),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "&&"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.VARIABLE, "1"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, ">"),
                new Token(TOKEN_TYPE.VARIABLE, "0"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
            };

            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestEasyCalculateBitExpression()
        {
            // 7 xor 3

            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "7"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "xor"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
            };

            double expected = 4;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMediumCalculateBitExpression()
        {
            // (4 or 3 and 2) xor 7

            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.VARIABLE, "4"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "or"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "and"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "xor"),
                new Token(TOKEN_TYPE.VARIABLE, "7"),
            };

            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestHardCalculateBitExpression()
        {
            // (16 >> 3 or 1 << 3) xor 16

            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.VARIABLE, "16"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, ">>"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "or"),
                new Token(TOKEN_TYPE.VARIABLE, "1"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "<<"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "xor"),
                new Token(TOKEN_TYPE.VARIABLE, "16"),
            };

            double expected = 26;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCalculateEqualsExpressions()
        {
            // 12 != 13
            List<Token> mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "12"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "!="),
                new Token(TOKEN_TYPE.VARIABLE, "13"),
            };

            double expected = 1;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);


            // 12 == 13
            mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "12"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "=="),
                new Token(TOKEN_TYPE.VARIABLE, "13"),
            };

            expected = 0;
            actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);


            // 10 > 10
            mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "10"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, ">"),
                new Token(TOKEN_TYPE.VARIABLE, "10"),
            };

            expected = 0;
            actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);


            // 10 >= 10
            mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "10"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, ">="),
                new Token(TOKEN_TYPE.VARIABLE, "10"),
            };

            expected = 1;
            actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);

            // 255+3 < 256+2
            mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "255"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "<"),
                new Token(TOKEN_TYPE.VARIABLE, "256"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.VARIABLE, "2")
            };

            expected = 0;
            actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);


            // 16*4 <= 8*8
            mathExpression = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "16"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "4"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "<="),
                new Token(TOKEN_TYPE.VARIABLE, "8"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "8")
            };

            expected = 1;
            actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }
    }
}
