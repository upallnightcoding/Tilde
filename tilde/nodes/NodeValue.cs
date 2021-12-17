using Tilde.tilde.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde.nodes
{
    /// <summary>
    /// NodeValue - This class defines the computational values calculated
    /// during execution of the program node tree.  It does not execute 
    /// a command, but is used by other commands when values are needed.
    /// </summary>
    class NodeValue : Node
    {
        private long lValue = 0;
        private string sValue = null;
        private double dValue = 0;
        private char cValue = ' ';
        private bool bValue = false;

        VariableType type = VariableType.UNKNOWN;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeValue(long lValue)
        {
            this.lValue = lValue;
            this.type = VariableType.INTEGER;
        }

        public NodeValue(string sValue)
        {
            this.sValue = sValue;
            this.type = VariableType.STRING;
        }

        public NodeValue(double dValue)
        {
            this.dValue = dValue;
            this.type = VariableType.FLOAT;    
        }

        /****************************/
        /*** Conversion Functions ***/
        /****************************/

        /*
         * Conversion Functions - The following functions are used to convert
         * the current node type to any require destination type.
         */

        public string GetString()
        {
            string value = null;

            switch(type)
            {
                case VariableType.CHARACTER:
                    value = char.ToString(cValue);
                    break;
                case VariableType.STRING:
                    value = sValue;
                    break;
                case VariableType.INTEGER:
                    value = lValue.ToString();
                    break;
                case VariableType.FLOAT:
                    value = dValue.ToString();
                    break;
                case VariableType.BOOLEAN:
                    value = (bValue) ? "true" : "false";
                    break;
            }

            return (value);
        }

        public double GetFloat()
        {
            double value = 0;

            switch(type)
            {
                case VariableType.FLOAT:
                    value = dValue;
                    break;
                case VariableType.INTEGER:
                    value = lValue;
                    break;
            }

            return (value);
        }

        public override NodeValue Execute()
        {
            return (null);
        }
    }
}
