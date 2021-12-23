using Leo.script.commands;
using Leo.script.symbol;
using System;
using Tilde.script.commands;

namespace Tilde.script.nodes
{
    /// <summary>
    /// NodeValue - This class defines the computational values calculated
    /// during execution of the program node tree.  It does not execute 
    /// a command, but is used by other commands when values are needed.
    /// </summary>
    class NodeValue : Node
    {
        // Containers for each Tilde primitive type
        //-----------------------------------------
        private long iValue = 0;
        private string sValue = null;
        private double fValue = 0;
        private char cValue = ' ';
        private bool bValue = false;

        private bool isAVariable = false;

        // Default NodeValue Type
        //-----------------------
        VariableType type = VariableType.UNKNOWN;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeValue(long iValue)
        {
            this.iValue = iValue;
            this.type = VariableType.INTEGER;
        }

        public NodeValue(string sValue, VariableType type = VariableType.STRING)
        {
            this.sValue = sValue;

            switch(type)
            {
                case VariableType.STRING:
                    this.type = type;
                    this.isAVariable = false;
                    break;
                case VariableType.VARIABLE:
                    this.type = VariableType.UNKNOWN;
                    this.isAVariable = true;
                    break;
            }
        }

        public NodeValue(double fValue)
        {
            this.fValue = fValue;
            this.type = VariableType.FLOAT;    
        }

        public NodeValue(char cValue)
        {
            this.cValue = cValue;
            this.type = VariableType.CHARACTER;
        }

        public NodeValue(bool bValue)
        {
            this.bValue = bValue;
            this.type = VariableType.BOOLEAN;
        }

        /***************************/
        /*** Predicate Functions ***/
        /***************************/

        public bool IsFloat() => (type == VariableType.FLOAT);

        public bool IsInteger() => (type == VariableType.INTEGER);

        public bool IsString() => (type == VariableType.STRING);

        /****************************/
        /*** Conversion Functions ***/
        /****************************/

        /// <summary>
        /// GetString() - Returns the value of th NodeValue as a Tilde String.
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            string value = null;

            // Determine the type of the NodeValue
            //------------------------------------
            switch (type)
            {
                case VariableType.CHARACTER:
                    value = char.ToString(cValue);
                    break;
                case VariableType.STRING:
                    value = sValue;
                    break;
                case VariableType.INTEGER:
                    value = iValue.ToString();
                    break;
                case VariableType.FLOAT:
                    value = fValue.ToString();
                    break;
                case VariableType.BOOLEAN:
                    value = (bValue) ? "true" : "false";
                    break;
            }

            return (value);
        }

        /// <summary>
        /// GetFloat() - Returns the value of th NodeValue as a Tilde Float.
        /// </summary>
        /// <returns></returns>
        public double GetFloat()
        {
            double value = 0;

            // Determine the type of the NodeValue
            //------------------------------------
            switch(type)
            {
                case VariableType.FLOAT:
                    value = fValue;
                    break;
                case VariableType.INTEGER:
                    value = iValue;
                    break;
            }

            return (value);
        }

        /// <summary>
        /// GetIntger() - Returns the value of NodeValue as a Tilde Integer.
        /// </summary>
        /// <returns></returns>
        public long GetInteger()
        {
            long value = 0;

            // Determine the type of the NodeValue
            //------------------------------------
            switch (type)
            {
                case VariableType.FLOAT:
                    value = Convert.ToInt64(fValue);
                    break;
                case VariableType.INTEGER:
                    value = iValue;
                    break;
            }

            return (value);
        }

        public override NodeValue Execute(Context context)
        {
            NodeValue value = this;

            if (isAVariable)
            {
                SymbolTableRec record = context.GetSymbolTable().Find(sValue);

                int offset = 0;

                if (record != null)
                {
                    switch (record.Type)
                    {
                        case VariableType.CHARACTER:
                            cValue = record.GetChar(offset);
                            break;
                        case VariableType.STRING:
                            sValue = record.GetString(offset);
                            break;
                        case VariableType.INTEGER:
                            iValue = record.GetInteger(offset);
                            break;
                        case VariableType.FLOAT:
                            fValue = record.GetFloat(offset);
                            break;
                        case VariableType.BOOLEAN:
                            bValue = record.GetBool(offset);
                            break;
                    }
                }
            }

            return (value);
        }
    }
}
