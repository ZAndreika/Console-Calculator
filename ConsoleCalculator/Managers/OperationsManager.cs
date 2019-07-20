using ConsoleCalculator;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculator.Managers
{
    public static class OperationsManager
    {
        public static readonly List<Operation> Operations = new List<Operation>()
        {
            new Operation("+", PRIORITY.ARITH_LOW),
            new Operation("-", PRIORITY.ARITH_LOW),
            new Operation("*", PRIORITY.ARITH_MEDIUM),
            new Operation("/", PRIORITY.ARITH_MEDIUM),
            new Operation("%", PRIORITY.ARITH_MEDIUM),
            new Operation("^", PRIORITY.ARITH_HIGH),
            new Operation("sqrt", PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY),
            new Operation("!", PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY),

            new Operation("||", PRIORITY.LOGIC_LOW),
            new Operation("&&", PRIORITY.LOGIC_MEDIUM),
            new Operation("not", PRIORITY.LOGIC_HIGH, OPERATION_TYPE.UNARY),

            new Operation("and", PRIORITY.BIT_MEDIUM),
            new Operation("xor", PRIORITY.BIT_LOW),
            new Operation("or", PRIORITY.BIT_LOWEST),
            new Operation("<<", PRIORITY.BIT_HIGH),
            new Operation(">>", PRIORITY.BIT_HIGH),

            new Operation("==", PRIORITY.EQUAL_LOW),
            new Operation("!=", PRIORITY.EQUAL_LOW),
            new Operation(">", PRIORITY.EQUAL_MEDIUM),
            new Operation(">=", PRIORITY.EQUAL_MEDIUM),
            new Operation("<", PRIORITY.EQUAL_MEDIUM),
            new Operation("<=", PRIORITY.EQUAL_MEDIUM),
        };

        public static bool IsOperation(string symbol)
        {
            Operation operation = Operations.FirstOrDefault(op => op.Symbol == symbol);
            if (operation == null)
            {
                return false;
            }
            return true;
        }

        public static bool IsUnaryOperation(string symbol)
        {
            Operation operation = Operations.Find(op => op.Symbol == symbol);
            if (operation == null)
            {
                throw new Exception("no such operation \"" + symbol + "\"");
            }
            if (operation.Type == OPERATION_TYPE.UNARY)
            {
                return true;
            }
            return false;
        }

        public static bool IsLogicOperation(string symbol)
        {
            Operation operation = Operations.Find(op => op.Symbol == symbol);
            if (operation == null)
            {
                return false;
            }
            if (operation.Priority == PRIORITY.LOGIC_LOW 
                || operation.Priority == PRIORITY.LOGIC_MEDIUM
                || operation.Priority == PRIORITY.LOGIC_HIGH)
            {
                return true;
            }
            return false;
        }

        public static bool IsBitOperation(string symbol)
        {
            Operation operation = Operations.Find(op => op.Symbol == symbol);
            if (operation == null)
            {
                return false;
            }
            if (operation.Priority == PRIORITY.BIT_LOWEST
                || operation.Priority == PRIORITY.BIT_LOW
                || operation.Priority == PRIORITY.BIT_MEDIUM
                || operation.Priority == PRIORITY.BIT_HIGH)
            {
                return true;
            }
            return false;
        }

        public static bool IsEqualOperation(string symbol)
        {
            Operation operation = Operations.Find(op => op.Symbol == symbol);
            if (operation == null)
            {
                return false;
            }
            if (operation.Priority == PRIORITY.EQUAL_LOW
                || operation.Priority == PRIORITY.EQUAL_MEDIUM)
            {
                return true;
            }
            return false;
        }

        public static Operation GetOperationByToken(Token token)
        {
            Operation operation = Operations.FirstOrDefault(x => x.Symbol == token.Value);
            if (operation == null)
            {
                throw new Exception("no such operation \"" + token.Value + "\"");
            }

            if (token.Type == TOKEN_TYPE.UNARY_OPERATION && operation.Symbol == "-") // change priority for unary minus
            {
                operation = new Operation(operation.Symbol, PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY);
            }

            return operation;
        }
    }
}
