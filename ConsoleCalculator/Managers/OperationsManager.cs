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
            new Operation("+", PRIORITY.LOW),
            new Operation("-", PRIORITY.LOW),
            new Operation("*", PRIORITY.MEDIUM),
            new Operation("/", PRIORITY.MEDIUM),
            new Operation("^", PRIORITY.HIGH),
            new Operation("sqrt", PRIORITY.MEDIUM, OPERATION_TYPE.UNARY)
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

        public static Operation GetOperationBySymbol(string symbol)
        {
            Operation operation = Operations.FirstOrDefault(x => x.Symbol == symbol);
            if (operation == null)
            {
                throw new Exception("no such operation \"" + symbol + "\"");
            }
            return operation;
        }
    }
}
