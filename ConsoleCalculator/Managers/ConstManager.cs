using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCalculator.Managers
{
    public static class ConstManager
    {
        public static readonly List<Const> Constants = new List<Const>()
        {
            new Const("pi", Math.PI),
            new Const("e", Math.E)
        };

        public static bool IsConst(string symbol)
        {
            Const operation = Constants.FirstOrDefault(op => op.Symbol == symbol);
            if (operation == null)
            {
                return false;
            }
            return true;
        }

        public static Const GetConstByToken(Token token)
        {
            Const constant = Constants.FirstOrDefault(x => x.Symbol == token.Value);
            if (constant == null)
            {
                throw new Exception("Undefined constant \"" + token.Value + "\"");
            }
            return constant;
        }
    }
}
