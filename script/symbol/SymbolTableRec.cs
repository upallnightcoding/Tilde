using Leo.script;
using Leo.script.symbol;
using System.Collections.Generic;
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
        public string Variable { get; private set; } = null;

        // Variable Type
        public VariableType VarType { get; private set; } = VariableType.UNKNOWN;

        // Variable Designation Type
        private DesignationType desigType = DesignationType.UNKNOWN;

        // Array elements size defined during declaration
        private ArrayElements arraySize = null;

        // Calculated size of each array element if defined
        private List<int> arrayElementSize = null;

        // Size of data buffer used to hold variable values
        private int dataBufferSize = -1;

        // Data buffers to hold variable values
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
            ArrayElements arraySize, 
            Context context
        )
        {
            // Define the variable type and name
            //----------------------------------
            this.VarType = varType;
            this.Variable = variable;

            this.arraySize = arraySize;

            // Define the variable as either a scalar or array.
            //-------------------------------------------------
            if (variableIsScalar())
            {
                this.desigType = DesignationType.VARIABLE;
                this.dataBufferSize = 1;
            } else
            {
                this.desigType = DesignationType.ARRAY;
                CalcArraySize(context);
            }

            // Setup buffers for whatever type of data is being declared.
            //-----------------------------------------------------------
            switch (VarType)
            {
                case VariableType.INTEGER:
                    iValue = new long[dataBufferSize];
                    break;
                case VariableType.STRING:
                    sValue = new string[dataBufferSize];
                    break;
                case VariableType.FLOAT:
                    fValue = new double[dataBufferSize];
                    break;
                case VariableType.CHARACTER:
                    cValue = new char[dataBufferSize];
                    break;
                case VariableType.BOOLEAN:
                    bValue = new bool[dataBufferSize];
                    break;
            }
        }

        /// <summary>
        /// Assign() - Uses the array elements to determine the position to 
        /// assign the node value.  The context object is needed to calculate
        /// the actual element values.
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="value"></param>
        /// <param name="context"></param>
        public void Assign(ArrayElements elements, NodeValue value, Context context)
        {
            int index = CalcIndex(elements, context);

            switch (VarType)
            {
                case VariableType.INTEGER:
                    iValue[index] = value.GetInteger();
                    break;
                case VariableType.STRING:
                    sValue[index] = value.GetString();
                    break;
                case VariableType.FLOAT:
                    fValue[index] = value.GetFloat();
                    break;
                case VariableType.CHARACTER:
                    cValue[index] = value.GetChar();
                    break;
                case VariableType.BOOLEAN:
                    bValue[index] = value.GetBoolean();
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

        /// <summary>
        /// CalcIndex() - 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public int CalcIndex(ArrayElements elements, Context context)
        {
            int index = -1;

            if (variableIsScalar())
            {
                index = 0;
            }
            else
            {
                switch (elements.nOfElements())
                {
                    case 1:
                        {
                            index = (int)elements.AllElements[0].Evaluate(context).GetInteger();
                        }
                        break;
                    case 2:
                        {
                            int n = arrayElementSize[1];
                            int i = (int)elements.AllElements[0].Evaluate(context).GetInteger();
                            int j = (int)elements.AllElements[1].Evaluate(context).GetInteger();
                            index = i * n + j;
                        }
                        break;
                    case 3:
                        {
                            int p = arrayElementSize[2];
                            int n = arrayElementSize[1];
                            int i = (int)elements.AllElements[0].Evaluate(context).GetInteger();
                            int j = (int)elements.AllElements[1].Evaluate(context).GetInteger();
                            int k = (int)elements.AllElements[2].Evaluate(context).GetInteger();
                            index = i * n * p + j * p + k;
                        }
                        break;
                }
            }

            return (index);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private bool variableIsScalar()
        {
            return (arraySize == null);
        }

        /// <summary>
        /// CalcArraySize() - Calculates the size of the array based on the elements
        /// of the array declaration.  If the variable is a scalar, this 
        /// function should never be invoked.  The dataBufferSize will contain the
        /// total size of the array and the arrayElementSize list will contain the
        /// size of each element.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private void CalcArraySize(Context context)
        {
            dataBufferSize = 1;

            arrayElementSize = new List<int>();

            foreach (Node element in arraySize.AllElements)
            {
                int elementSize = (int)element.Evaluate(context).GetInteger();

                arrayElementSize.Add(elementSize);

                dataBufferSize *= elementSize;
            }
        }
    }
}
