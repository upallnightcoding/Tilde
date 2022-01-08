using Tilde.script.symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.script.commands
{
    class Context
    {
        private SymbolTable symbolTable = null;

        public Context()
        {
            symbolTable = new SymbolTable();
        }

        public SymbolTable GetSymbolTable()
        {
            return (symbolTable);
        }
    }
}
