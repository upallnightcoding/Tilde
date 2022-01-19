using Tilde.script.commands;
using System;
using Leo.script;
using Tilde.script.symbol;
using Tilde.script.parser;

namespace Tilde.script.nodes
{
    /// <summary>
    /// NodeDeclareVar - 
    /// </summary>
    class NodeDeclareVar : Node
    {
        private string variable = null;

        private VariableType type = VariableType.UNKNOWN;

        private Node initialize = null;

        private ArrayElement arrayElement = null;

        /********************/
        /*** Constructors ***/
        /********************/

        public NodeDeclareVar(VariableType type, Token variable, ArrayElement arrayElement, Node initialize)
        {
            this.type = type;
            this.variable = variable.GetVariable();
            this.initialize = initialize;
            this.arrayElement = arrayElement;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Execute() - 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override NodeValue Evaluate(Context context)
        {
            int size = (arrayElement == null) ? 1 : arrayElement.CalcSize(context);

            Console.WriteLine("Type: " + type + " - Variable: " + variable + " Size: " + size);

            context.GetSymbolTable().Declare(type, variable, arrayElement, context);

            if (initialize != null)
            {
                NodeValue value = initialize.Evaluate(context);

                context.GetSymbolTable().Assign(variable, 0, value);
            }

            return (null);
        }
    }
}
