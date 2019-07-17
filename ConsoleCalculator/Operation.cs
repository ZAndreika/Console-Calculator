namespace ConsoleCalculator
{
    public enum PRIORITY { LOW, MEDIUM, HIGH }
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
