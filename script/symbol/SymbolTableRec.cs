using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;

namespace Leo.script.symbol
{
    /// <summary>
    /// SymbolTableRec - This class represents an instance of a variable that
    /// has been declared in the symbol table.  This variable can be a user
    /// define variable, function, constant etc.
    /// </summary>
    class SymbolTableRec
    {
        // Variable Name, all entries require a name
        private string variable = null;

        // Variable Type
        private VariableType type = VariableType.UNKNOWN;

        // Variable Size, number of variable elements
        private int size = -1;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public SymbolTableRec(VariableType type, string variable, int size = 1)
        {
            this.type = type;
            this.variable = variable;
        }

        /// <summary>
        /// Find() - Determines if the variable in question is equal to the
        /// variable declare in the record.  This function is mainly used
        /// when attempting find if a variable has been declared.
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public bool Find(string variable) => (variable == this.variable);
    }
}
