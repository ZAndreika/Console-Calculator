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
            // -sqrt(-4+5*pow(-2,2))*2.5

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
                new Token(TOKEN_TYPE.BINARY_OPERATION, "pow"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "2,5")
            };

            double expected = -10;
            double actual = ConsoleCalculator.Calculator.CalculateExpression(mathExpression);

            Assert.AreEqual(expected, actual);
        }
    }
}
