﻿using Leo.script;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Tilde.script.symbol
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
        public VariableType VarType { get; set; } = VariableType.UNKNOWN;

        // Variable Designation Type
        public DesignationType DesigType { get; set; } = DesignationType.UNKNOWN;

        // Variable Size, number of variable elements
        private int Size { get; set; } = -1;

        // Variable Values
        private long[] iValue = null;
        private string[] sValue = null;
        private double[] fValue = null;
        private char[] cValue = null;
        private bool[] bValue = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public SymbolTableRec(
            VariableType varType, 
            string variable, 
            ArrayElement arrayElement, 
            Context context
        )
        {
            this.VarType = varType;
            this.Variable = variable;

            if (arrayElement == null)
            {
                this.DesigType = DesignationType.VARIABLE;
                this.Size = 1;
            } else
            {
                this.DesigType = DesignationType.ARRAY;
                this.Size = arrayElement.CalcSize(context);
            }

            switch (VarType)
            {
                case VariableType.INTEGER:
                    iValue = new long[Size];
                    break;
                case VariableType.STRING:
                    sValue = new string[Size];
                    break;
                case VariableType.FLOAT:
                    fValue = new double[Size];
                    break;
                case VariableType.CHARACTER:
                    cValue = new char[Size];
                    break;
                case VariableType.BOOLEAN:
                    bValue = new bool[Size];
                    break;
            }
        }

        /// <summary>
        /// Assign() - 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="value"></param>
        public void Assign(int offset, NodeValue value)
        {
            switch (VarType)
            {
                case VariableType.INTEGER:
                    iValue[offset] = value.GetInteger();
                    break;
                case VariableType.STRING:
                    sValue[offset] = value.GetString();
                    break;
                case VariableType.FLOAT:
                    fValue[offset] = value.GetFloat();
                    break;
                case VariableType.CHARACTER:
                    cValue[offset] = value.GetChar();
                    break;
                case VariableType.BOOLEAN:
                    bValue[offset] = value.GetBoolean();
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
