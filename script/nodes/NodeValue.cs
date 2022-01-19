using Leo.script;
using Tilde.script.commands;
using Tilde.script.symbol;

namespace Tilde.script.nodes
{
    /// <summary>
    /// NodeValue - This class defines the computational values calculated
    /// during execution of the program node tree.  It does not execute 
    /// a command, but is used by other commands when values are needed.
    /// </summary>
    class NodeValue : Node
    {
        public ArrayElement ArrayElements { get; set; } = null;

        // Containers for each Tilde primitive type
        //-----------------------------------------
        private long iValue = 0;
        private string sValue = null;
        private double fValue = 0;
        private char cValue = ' ';
        private bool bValue = false;

        // Default NodeValue Type
        //-----------------------
        private VariableType type = VariableType.UNKNOWN;


        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeValue(long iValue)
        {
            this.iValue = iValue;
            this.type = VariableType.INTEGER;
        }

        public NodeValue(string sValue, VariableType type)
        {
            this.sValue = sValue;

            switch(type)
            {
                case VariableType.STRING:
                    this.type = type;
                    break;
                case VariableType.SYMBOL:
                    this.type = type;
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

        public bool IsChar() => (type == VariableType.CHARACTER);

        public bool IsBoolean() => (type == VariableType.BOOLEAN);

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
        /// GetFloat() - Returns the value of the NodeValue as a Tilde Float.
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
                    value = (long) fValue;
                    break;
                case VariableType.INTEGER:
                    value = iValue;
                    break;
            }

            return (value);
        }

        public char GetChar()
        {
            return (cValue);
        }

        public bool GetBoolean()
        {
            return (bValue);
        }

        public override NodeValue Evaluate(Context context)
        {
            NodeValue value = this;

            if (type == VariableType.SYMBOL)
            {
                SymbolTableRec record = context.GetSymbolTable().Find(sValue);

                if (record != null)
                {
                    int index = (ArrayElements == null) ? 0 : ArrayElements.CalcIndex(context);

                    type = record.VarType;

                    switch (type)
                    {
                        case VariableType.CHARACTER:
                            cValue = record.GetChar(index);
                            break;
                        case VariableType.STRING:
                            sValue = record.GetString(index);
                            break;
                        case VariableType.INTEGER:
                            iValue = record.GetInteger(index);
                            break;
                        case VariableType.FLOAT:
                            fValue = record.GetFloat(index);
                            break;
                        case VariableType.BOOLEAN:
                            bValue = record.GetBool(index);
                            break;
                    }
                }
            }

            return (value);
        }
    }
}
