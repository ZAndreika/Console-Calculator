using ConsoleCalculator.Converters;
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
                    case TOKEN_TYPE.UNARY_OPERATION:
                    {
                        Token variable = variablesStack.Pop();
                        switch (token.Value)
                        {
                            case "-":
                            {
                                if (variable.Value.StartsWith("-"))
                                {
                                    variable.Value = variable.Value.Substring(1, variable.Value.Length - 1);
                                }
                                else
                                {
                                    variable.Value = "-" + variable.Value;
                                }
                                variablesStack.Push(variable);
                                break;
                            }
                            case "sqrt":
                            {
                                double var = double.Parse(variable.Value);
                                if (var < 0)
                                {
                                    throw new Exception("sqrt from negative number");
                                }
                                var = Math.Sqrt(var);

                                variable.Value = var.ToString();

                                variablesStack.Push(variable);
                                break;
                            }
                            default:
                            {
                                throw new Exception("Undefined unary operator");
                            }
                        }
                        break;
                    }
                    case TOKEN_TYPE.BINARY_OPERATION:
                    {
                        Token secondVar = variablesStack.Pop();
                        Token firstVar = variablesStack.Pop();

                        if (firstVar.Type != secondVar.Type && firstVar.Type != TOKEN_TYPE.VARIABLE)
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
                                    throw new Exception("Division by zero");
                                }
                                newVar.Value = (firstDouble / secondDouble).ToString();
                                break;
                            }
                            case "^":
                            {
                                newVar.Value = Math.Pow(firstDouble, secondDouble).ToString();
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
