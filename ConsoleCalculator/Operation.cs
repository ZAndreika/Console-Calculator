namespace ConsoleCalculator
{
    public enum PRIORITY { LOGIC_LOW, LOGIC_MEDIUM, BIT_LOWEST, BIT_LOW, BIT_MEDIUM, EQUAL_LOW, EQUAL_MEDIUM, BIT_HIGH, ARITH_LOW, ARITH_MEDIUM, ARITH_HIGH, LOGIC_HIGH = ARITH_HIGH }
    public enum OPERATION_TYPE { UNARY, BINARY }
    public class Operation
    {
        public readonly string Symbol;
        public readonly PRIORITY Priority;
        public readonly OPERATION_TYPE Type;

        public Operation(string Symbol, PRIORITY Priority, OPERATION_TYPE Type = OPERATION_TYPE.BINARY)
        {
            this.Symbol = Symbol;
            this.Priority = Priority;
            this.Type = Type;
        }
    }
}
