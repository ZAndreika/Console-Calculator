using ConsoleCalculator.Converters;
using ConsoleCalculator.DataTypes;
using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string mathExpression = Console.ReadLine();

            try
            {
                List<Token> tokensExpression = StringConverter.ConvertToTokensExpression(mathExpression);
                var res = Calculator.CalculateExpression(tokensExpression);
                Console.WriteLine(res.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
