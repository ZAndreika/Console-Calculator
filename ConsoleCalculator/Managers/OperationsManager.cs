using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleCalculator.DataTypes;

namespace ConsoleCalculator.Managers
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
            new Operation("sin", PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY),
            new Operation("cos", PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY),
            new Operation("tg", PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY),
            new Operation("ctg", PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY),
            new Operation("log", PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY),

            new Operation("||", PRIORITY.LOGIC_LOW),
            new Operation("&&", PRIORITY.LOGIC_MEDIUM),
            new Operation("not", PRIORITY.LOGIC_HIGH, OPERATION_TYPE.UNARY),

            new Operation("or", PRIORITY.BIT_LOWEST),
            new Operation("xor", PRIORITY.BIT_LOW),
            new Operation("and", PRIORITY.BIT_MEDIUM),
            new Operation("<<", PRIORITY.BIT_HIGH),
            new Operation(">>", PRIORITY.BIT_HIGH),

            new Operation("==", PRIORITY.COMPARE_LOW),
            new Operation("!=", PRIORITY.COMPARE_LOW),
            new Operation(">", PRIORITY.COMPARE_MEDIUM),
            new Operation(">=", PRIORITY.COMPARE_MEDIUM),
            new Operation("<", PRIORITY.COMPARE_MEDIUM),
            new Operation("<=", PRIORITY.COMPARE_MEDIUM),
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
                throw new Exception("Undefined operation \"" + symbol + "\"");
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
        public static bool IsCompareOperation(string symbol)
        {
            Operation operation = Operations.Find(op => op.Symbol == symbol);
            if (operation == null)
            {
                return false;
            }
            if (operation.Priority == PRIORITY.COMPARE_LOW
                || operation.Priority == PRIORITY.COMPARE_MEDIUM)
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
                throw new Exception("Undefined operation \"" + token.Value + "\"");
            }

            if (token.Type == TOKEN_TYPE.UNARY_OPERATION && (operation.Symbol == "-" || operation.Symbol == "+")) // change priority for unary minus/plus
            {
                operation = new Operation(operation.Symbol, PRIORITY.ARITH_HIGH, OPERATION_TYPE.UNARY);
            }

            return operation;
        }
    }
}
