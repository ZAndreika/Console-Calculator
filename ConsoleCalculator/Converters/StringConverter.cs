using Calculator.Managers;
using System;
using System.Collections.Generic;

namespace ConsoleCalculator.Converters
{
    public static class StringConverter
    {
        public static List<Token> ConvertToTokensExpression(string inputString)
        {
            inputString = inputString.Replace(" ", "").ToLower(); // remove spaces

            List<Token> tokenExpression = new List<Token>();

            int i = 0;
            while (i < inputString.Length)
            {
                string tmp = "";
                Token newToken = new Token();

                if ((inputString[i] == '-' || inputString[i] == '+') &&
                    (i == 0 || inputString[i - 1] == '(' || OperationsManager.IsOperation(inputString[i - 1].ToString())))
                {
                    newToken.Type = TOKEN_TYPE.UNARY_OPERATION;
                }

                if (inputString[i] == '(')
                {
                    newToken.Type = TOKEN_TYPE.OPENING_BRACKET;
                    tmp = inputString[i++].ToString();
                }
                else if (inputString[i] == ')')
                {
                    newToken.Type = TOKEN_TYPE.CLOSING_BRACKET;
                    tmp = inputString[i++].ToString();
                }
                else if (char.IsDigit(inputString[i]))
                {
                    newToken.Type = TOKEN_TYPE.VARIABLE;
                    while (i != inputString.Length &&
                        (char.IsDigit(inputString[i]) || inputString[i] == '.' || inputString[i] == ','))
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
                    string checkOp = tmp;
                    if (i != inputString.Length)
                    {
                        checkOp += inputString[i];
                    }
                    if (OperationsManager.IsBitOperation(checkOp)
                        || OperationsManager.IsLogicOperation(checkOp)
                        || OperationsManager.IsCompareOperation(checkOp))
                    {
                        tmp = checkOp;
                        i++;
                    }

                    if (OperationsManager.IsUnaryOperation(tmp))
                    {
                        newToken.Type = TOKEN_TYPE.UNARY_OPERATION;
                    }

                }
                newToken.Value = tmp;
                tokenExpression.Add(newToken);
            }

            return tokenExpression;
        }

    }
}
