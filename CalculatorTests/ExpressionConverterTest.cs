using System.Collections.Generic;
using ConsoleCalculator.DataTypes;
using ConsoleCalculator.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ExpressionConverterTest
    {
        [TestMethod]
        public void TestEasyGetPostfixExpression()
        {
            // 2+3
            List<Token> entry = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.VARIABLE, "3")
            };

            List<Token> initList = new List<Token>() {
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+")
            };
            initList.Reverse();

            Stack<Token> expected = new Stack<Token>(initList);
            Stack<Token> actual = ExpressionConverter.GetPostfixExpression(entry);

            Assert.AreEqual(true, CompareStacks(expected, actual));
        }

        [TestMethod]
        public void TestMediumGetPostfixExpression()
        {
            // sqrt(-2+3)*4

            List<Token> entry = new List<Token>()
            {
                new Token(TOKEN_TYPE.UNARY_OPERATION, "sqrt"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "4")
            };

            List<Token> initList = new List<Token>() {
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "sqrt"),
                new Token(TOKEN_TYPE.VARIABLE, "4"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
            };
            initList.Reverse();

            Stack<Token> expected = new Stack<Token>(initList);
            Stack<Token> actual = ExpressionConverter.GetPostfixExpression(entry);

            Assert.AreEqual(true, CompareStacks(expected, actual));
        }

        [TestMethod]
        public void TestHardGetPostfixExpression()
        {
            // -sqrt(-4+5*(-2)^2)*4

            List<Token> entry = new List<Token>()
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
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "^"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "4")
            };

            List<Token> initList = new List<Token>() {
                new Token(TOKEN_TYPE.VARIABLE, "4"),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "5"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "^"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "sqrt"),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "4"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*")
            };
            initList.Reverse();

            Stack<Token> expected = new Stack<Token>(initList);
            Stack<Token> actual = ExpressionConverter.GetPostfixExpression(entry);

            Assert.AreEqual(true, CompareStacks(expected, actual));
        }

        bool CompareStacks(Stack<Token> expected, Stack<Token> actual)
        {
            if (expected.Count != actual.Count)
            {
                return false;
            }
            for (int i = 0; i < expected.Count; i++)
            {
                if (actual.Peek().Type != expected.Peek().Type || actual.Peek().Value != expected.Peek().Value)
                {
                    return false;
                }
                actual.Pop();
                expected.Pop();
            }
            return true;
        }
    }
}
