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
        public string Variable { get; set; } = null;

        // Variable Type
        public VariableType Type { get; set; } = VariableType.UNKNOWN;

        // Variable Size, number of variable elements
        private int size = -1;

        // Variable Values
        private long[] iValue = null;
        private string[] sValue = null;
        private double[] fValue = null;
        private char[] cValue = null;
        private bool[] bValue = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public SymbolTableRec(VariableType type, string variable, int size = 1)
        {
            this.Type = type;
            this.Variable = variable;
            this.size = size;

            switch(type)
            {
                case VariableType.INTEGER:
                    iValue = new long[size];
                    break;
                case VariableType.STRING:
                    sValue = new string[size];
                    break;
                case VariableType.FLOAT:
                    fValue = new double[size];
                    break;
                case VariableType.CHARACTER:
                    cValue = new char[size];
                    break;
                case VariableType.BOOLEAN:
                    bValue = new bool[size];
                    break;
            }
        }

        /*********************/
        /*** Get Functions ***/
        /*********************/

        public long GetInteger(int offset) => iValue[offset];

        public string GetString(int offset) => sValue[offset];

        public double GetFloat(int offset) => fValue[offset];

        public char GetChar(int offset) => cValue[offset];

        public bool GetBool(int offset) => bValue[offset];
    }
}
