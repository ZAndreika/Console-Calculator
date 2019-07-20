using ConsoleCalculator.Converters;
using ConsoleCalculator.Managers;
using System;
using System.Collections.Generic;

namespace ConsoleCalculator
{
    public static class Calculator
    {
        public static double CalculateExpression(List<Token> mathTokensExpression)
        {
            Stack<Token> postfixExpresion = ExpressionConverter.GetPostfixExpression(mathTokensExpression);
            Stack<Token> variablesStack = new Stack<Token>();

            while (postfixExpresion.Count > 0)
            {
                Token token = postfixExpresion.Pop();
                switch (token.Type)
                {
                    case TOKEN_TYPE.VARIABLE:
                    {
                        variablesStack.Push(token);
                        break;
                    }
                    case TOKEN_TYPE.CONST:
                    {
                        token.Value = ConstManager.GetConstByToken(token).Value.ToString();
                        variablesStack.Push(token);
                        break;
                    }
                    case TOKEN_TYPE.UNARY_OPERATION:
                    {
                        Token variable;
                        double var;
                        try
                        {
                            variable = variablesStack.Pop();
                            var = double.Parse(variable.Value);
                        }
                        catch (Exception)
                        {
                            throw new Exception("Bad expression");
                        }

                        switch (token.Value)
                        {
                            case "-":
                            {
                                var *= -1;
                                break;
                            }
                            case "+":
                            {
                                break;
                            }
                            case "sqrt":
                            {
                                if (var < 0)
                                {
                                    throw new Exception("Do not extract the sqrt of a negative number");
                                }
                                var = Math.Sqrt(var);

                                break;
                            }
                            case "not":
                            {
                                if (var != 0 && var != 1)
                                {
                                    throw new Exception("Not boolean operand for \"" + token.Value + "\"");
                                }
                                var = var == 0 ? 1 : 0;

                                break;
                            }
                            case "!":
                            {
                                double n = var;
                                var = 1;

                                for (int i = 2; i <= n; i++)
                                {
                                    var *= i;
                                }
                                break;
                            }
                            case "sin":
                            {
                                var = Math.Sin(var);
                                break;
                            }
                            case "cos":
                            {
                                var = Math.Cos(var);
                                break;
                            }
                            case "tg":
                            {
                                var = Math.Tan(var);
                                break;
                            }
                            case "ctg":
                            {
                                var = Math.Cos(var) / Math.Sin(var);
                                break;
                            }
                            case "log":
                            {
                                var = Math.Log(var);
                                break;
                            }
                            default:
                            {
                                throw new Exception("Undefined unary operator");
                            }
                        }

                        variable.Value = var.ToString();
                        variablesStack.Push(variable);
                        break;
                    }
                    case TOKEN_TYPE.BINARY_OPERATION:
                    {
                        Token secondVar;
                        Token firstVar;

                        try
                        {
                            secondVar = variablesStack.Pop();
                            firstVar = variablesStack.Pop();
                        }
                        catch (Exception)
                        {
                            throw new Exception("Bad expression");
                        }

                        double firstDouble, secondDouble;
                        try
                        {
                            firstDouble = double.Parse(firstVar.Value);
                            secondDouble = double.Parse(secondVar.Value);
                        }
                        catch (Exception)
                        {
                            throw new Exception("Bad variable syntax");
                        }

                        Token newVar = new Token();
                        newVar.Type = TOKEN_TYPE.VARIABLE;

                        switch (token.Value)
                        {
                            case "+":
                            {
                                newVar.Value = (firstDouble + secondDouble).ToString();
                                break;
                            }
                            case "-":
                            {
                                newVar.Value = (firstDouble - secondDouble).ToString();
                                break;
                            }
                            case "*":
                            {
                                newVar.Value = (firstDouble * secondDouble).ToString();
                                break;
                            }
                            case "/":
                            {
                                if (secondDouble == 0)
                                {
                                    throw new Exception("Сannot be divided by zero");
                                }
                                newVar.Value = (firstDouble / secondDouble).ToString();
                                break;
                            }
                            case "%":
                            {
                                newVar.Value = (firstDouble % secondDouble).ToString();
                                break;
                            }
                            case "^":
                            {
                                newVar.Value = Math.Pow(firstDouble, secondDouble).ToString();
                                break;
                            }
                            case "and":
                            {
                                newVar.Value = ((int)secondDouble & (int)firstDouble).ToString();
                                break;
                            }
                            case "or":
                            {
                                newVar.Value = ((int)secondDouble | (int)firstDouble).ToString();
                                break;
                            }
                            case "xor":
                            {
                                newVar.Value = ((int)secondDouble ^ (int)firstDouble).ToString();
                                break;
                            }
                            case ">>":
                            {
                                newVar.Value = ((int)firstDouble >> (int)secondDouble).ToString();
                                break;
                            }
                            case "<<":
                            {
                                newVar.Value = ((int)firstDouble << (int)secondDouble).ToString();
                                break;
                            }
                            case "||":
                            {
                                if ((firstDouble != 0 && firstDouble != 1) || (secondDouble != 0 && secondDouble != 1))
                                {
                                    throw new Exception("Not boolean operands for \"||\"");
                                }
                                bool firstBool = firstDouble == 0 ? false : true;
                                bool secondBool = secondDouble == 0 ? false : true;
                                newVar.Value = (firstBool || secondBool == true ? 1 : 0).ToString();
                                break;
                            }
                            case "&&":
                            {
                                if (firstDouble != 0 && firstDouble != 1 || secondDouble != 0 && secondDouble != 1)
                                {
                                    throw new Exception("No boolean operands for \"" + token.Value + "\"");
                                }
                                bool firstBool = firstDouble == 0 ? false : true;
                                bool secondBool = secondDouble == 0 ? false : true;
                                newVar.Value = (firstBool && secondBool == true ? 1 : 0).ToString();
                                break;
                            }
                            case ">":
                            {
                                newVar.Value = (firstDouble > secondDouble ? 1 : 0).ToString();
                                break;
                            }
                            case ">=":
                            {
                                newVar.Value = (firstDouble >= secondDouble ? 1 : 0).ToString();
                                break;
                            }
                            case "<":
                            {
                                newVar.Value = (firstDouble < secondDouble ? 1 : 0).ToString();
                                break;
                            }
                            case "<=":
                            {
                                newVar.Value = (firstDouble <= secondDouble ? 1 : 0).ToString();
                                break;
                            }
                            case "==":
                            {
                                newVar.Value = (firstDouble == secondDouble ? 1 : 0).ToString();
                                break;
                            }
                            case "!=":
                            {
                                newVar.Value = (firstDouble != secondDouble ? 1 : 0).ToString();
                                break;
                            }
                            default:
                            {
                                throw new Exception("Undefined binary operator");
                            }
                        }
                        
                        variablesStack.Push(newVar);
                        break;
                    }
                    default:
                    {
                        throw new Exception("Bad expression");
                    }
                }
            }

            if (variablesStack.Count != 1)
            {
                throw new Exception("Bad expression");
            }

            return double.Parse(variablesStack.Pop().Value);
        }
    }
}
