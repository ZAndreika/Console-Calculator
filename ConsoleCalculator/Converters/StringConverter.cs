using Calculator.Managers;
using System;
using System.Collections.Generic;

namespace ConsoleCalculator.Converters
{
    public static class StringConverter
    {
        public static List<Token> ConvertToTokensExpression(string inputString)
        {
            inputString = inputString.Replace(" ", "").ToLower();

            List<Token> tokenExpression = new List<Token>();

            int i = 0;
            while (i < inputString.Length)
            {
                string tmp = "";
                Token newToken = new Token();

                if (inputString[i] == '-' &&
                    (i == 0 || inputString[i - 1] == '(' || OperationsManager.IsOperation(inputString[i - 1].ToString()) || inputString[i - 1] == ','))
                {
                    newToken.Type = TOKEN_TYPE.UNARY_OPERATION;
                }

                if (inputString[i] == '(')
                {
                    newToken.Type = TOKEN_TYPE.OPENING_BRACKET;
                }
                else if (inputString[i] == ')')
                {
                    newToken.Type = TOKEN_TYPE.CLOSING_BRACKET;
                }

                if (char.IsDigit(inputString[i]))
                {
                    newToken.Type = TOKEN_TYPE.VARIABLE;
                    while (char.IsDigit(inputString[i]) || inputString[i] == '.')
                    {
                        if (inputString[i] == '.')
                        {
                            tmp += ','; // for parsing to double in future
                            i++;
                        }
                        else
                        {
                            tmp += inputString[i++];
                        }

                        if (i == inputString.Length)
                        {
                            break;
                        }
                    }
                }
                else if (char.IsLetter(inputString[i]))
                {
                    while (char.IsLetter(inputString[i]))
                    {
                        tmp += inputString[i++];
                        if (i == inputString.Length)
                        {
                            break;
                        }
                    }
                    try
                    {
                        if (OperationsManager.IsUnaryOperation(tmp))
                        {
                            newToken.Type = TOKEN_TYPE.UNARY_OPERATION;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                else
                {
                    tmp = inputString[i++].ToString();
                }
                newToken.Value = tmp;

                if (newToken.Value != ",") // for binary operations like pow(a,b)
                {
                    tokenExpression.Add(newToken);
                }
            }

            return tokenExpression;
        }

    }
}
