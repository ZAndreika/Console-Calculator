namespace ConsoleCalculator
{
    public enum TOKEN_TYPE { VARIABLE, BINARY_OPERATION, UNARY_OPERATION, OPENING_BRACKET, CLOSING_BRACKET };
    public class Token
    {
        public TOKEN_TYPE Type { get; set; }
        public string Value { get; set; }
        public Token()
        {
            Type = TOKEN_TYPE.BINARY_OPERATION;
        }

        public Token(TOKEN_TYPE Type, string Value)
        {
            this.Type = Type;
            this.Value = Value;
        }
    }
}
