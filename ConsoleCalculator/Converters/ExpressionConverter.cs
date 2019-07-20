using ConsoleCalculator.Managers;
using System.Collections.Generic;

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
                    case TOKEN_TYPE.CONST:
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
                        else
                        {
                            Operation peekOp = OperationsManager.GetOperationByToken(operationsStack.Peek());
                            Operation currentOp = OperationsManager.GetOperationByToken(currentToken);

                            if (currentOp.Priority > peekOp.Priority)
                            {
                                operationsStack.Push(currentToken);
                            }
                            else
                            {
                                while (operationsStack.Peek().Type != TOKEN_TYPE.OPENING_BRACKET
                                    && currentOp.Priority <= peekOp.Priority)
                                {
                                    postfixExpression.Push(operationsStack.Pop());
                                    if (operationsStack.Count == 0 || operationsStack.Peek().Type == TOKEN_TYPE.OPENING_BRACKET)
                                    {
                                        break;
                                    }
                                    peekOp = OperationsManager.GetOperationByToken(operationsStack.Peek());
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
                        operationsStack.Pop(); // remove opening bracket from operations stack
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
