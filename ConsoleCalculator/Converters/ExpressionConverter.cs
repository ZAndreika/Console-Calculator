using Calculator.Managers;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleCalculator.Converters
{
    public static class ExpressionConverter
    {
        public static Stack<Token> GetPostfixExpression(List<Token> tokens)
        {
            Stack<Token> postfixExpression = new Stack<Token>();
            Stack<Token> operationsStack = new Stack<Token>();

            for (int i = 0; i < tokens.Count; i++)
            {
                Token currentToken = tokens[i];

                switch (currentToken.Type)
                {
                    case TOKEN_TYPE.VARIABLE:
                    {
                        postfixExpression.Push(currentToken);
                        break;
                    }
                    case TOKEN_TYPE.BINARY_OPERATION:
                    {
                        if (operationsStack.Count == 0)
                        {
                            operationsStack.Push(currentToken);
                        }
                        else if (operationsStack.Peek().Type == TOKEN_TYPE.OPENING_BRACKET)
                        {
                            operationsStack.Push(currentToken);
                        }
                        else if (operationsStack.Peek().Type == TOKEN_TYPE.BINARY_OPERATION
                            || operationsStack.Peek().Type == TOKEN_TYPE.UNARY_OPERATION)
                        {
                            Operation peekOp = OperationsManager.GetOperationBySymbol(operationsStack.Peek().Value);
                            Operation currentOp = OperationsManager.GetOperationBySymbol(currentToken.Value);

                            if (currentOp.Priority > peekOp.Priority)
                            {
                                operationsStack.Push(currentToken);
                            }
                            else
                            {
                                while (operationsStack.Peek().Type != TOKEN_TYPE.OPENING_BRACKET
                                    && currentOp.Priority <= peekOp.Priority)
                                {
                                    peekOp = OperationsManager.GetOperationBySymbol(operationsStack.Peek().Value);

                                    postfixExpression.Push(operationsStack.Pop());
                                    if (operationsStack.Count == 0)
                                    {
                                        break;
                                    }
                                }

                                operationsStack.Push(currentToken);
                            }
                        }

                        break;
                    }
                    case TOKEN_TYPE.UNARY_OPERATION:
                    {
                        operationsStack.Push(currentToken);
                        break;
                    }
                    case TOKEN_TYPE.OPENING_BRACKET:
                    {
                        operationsStack.Push(currentToken);
                        break;
                    }
                    case TOKEN_TYPE.CLOSING_BRACKET:
                    {
                        while (operationsStack.Peek().Type != TOKEN_TYPE.OPENING_BRACKET)
                        {
                            postfixExpression.Push(operationsStack.Pop());
                        }
                        operationsStack.Pop();
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }

            while (operationsStack.Count > 0)
            {
                postfixExpression.Push(operationsStack.Pop());
            }

            postfixExpression = new Stack<Token>(postfixExpression); // reverse stack

            return postfixExpression;
        }
    }
}
