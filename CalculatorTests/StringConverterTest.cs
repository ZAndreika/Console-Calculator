using System.Collections.Generic;
using ConsoleCalculator;
using ConsoleCalculator.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class StringConverterTest
    {

        [TestMethod]
        public void TestEasyConvertToTokensExpression()
        {
            string entry = "2+3";
            List<Token> expected = new List<Token>()
            {
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "+"),
                new Token(TOKEN_TYPE.VARIABLE, "3")
            };
            List<Token> actual = StringConverter.ConvertToTokensExpression(entry);

            Assert.AreEqual(true, CompareLists(expected, actual));
        }

        [TestMethod]
        public void TestMediumConvertToTokensExpression()
        {
            string entry = "(-2-3)*4";
            List<Token> expected = new List<Token>()
            {
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "4")
            };
            List<Token> actual = StringConverter.ConvertToTokensExpression(entry);

            Assert.AreEqual(true, CompareLists(expected, actual));
        }

        [TestMethod]
        public void TestHardConvertToTokensExpression()
        {
            string entry = "-sqrt(-2-3*(-2)^2)*4";
            List<Token> expected = new List<Token>()
            {
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "sqrt"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "3"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.OPENING_BRACKET, "("),
                new Token(TOKEN_TYPE.UNARY_OPERATION, "-"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "^"),
                new Token(TOKEN_TYPE.VARIABLE, "2"),
                new Token(TOKEN_TYPE.CLOSING_BRACKET, ")"),
                new Token(TOKEN_TYPE.BINARY_OPERATION, "*"),
                new Token(TOKEN_TYPE.VARIABLE, "4")
            };
            List<Token> actual = StringConverter.ConvertToTokensExpression(entry);

            Assert.AreEqual(true, CompareLists(expected, actual));
        }

        bool CompareLists(List<Token> expected, List<Token> actual)
        {
            if (expected.Count != actual.Count)
            {
                return false;
            }
            for (int i = 0; i < expected.Count; i++)
            {
                if (actual[i].Type != expected[i].Type || actual[i].Value != expected[i].Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
