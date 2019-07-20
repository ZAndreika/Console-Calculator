using System.Collections.Generic;
using ConsoleCalculator;
using ConsoleCalculator.Converters;
using ConsoleCalculator.DataTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PerformanceTest
    {
        [TestMethod]
        public void MediumTest()
        {
            string mathExpression = "(ctg(pi/4)+3%2)^(sqrt(100/10/2+-1))";
            List<Token> tokensExpression = StringConverter.ConvertToTokensExpression(mathExpression);
            double actual = Calculator.CalculateExpression(tokensExpression);

            double expected = 4;
            Assert.AreEqual(expected, actual);
        }
    }
}
