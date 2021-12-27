using Leo.script.commands;
using System;
using Tilde.script;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Leo.script.nodes
{
    class NodeDeclareVar : Node
    {
        private string variable = null;

        private VariableType type = VariableType.UNKNOWN;

        private Node initialize = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeDeclareVar(VariableType type, Token variable) : this(type, variable, null)
        {
            
        }

        public NodeDeclareVar(VariableType type, Token variable, Node initialize)
        {
            this.type = type;
            this.variable = variable.GetVariable();
            this.initialize = initialize;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Execute() - 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override NodeValue Execute(Context context)
        {
            Console.WriteLine("Type: " + type + " - Variable: " + variable);

            context.GetSymbolTable().Declare(type, variable, 1);

            if (initialize != null)
            {
                NodeValue value = initialize.Execute(context);

                context.GetSymbolTable().Assign(variable, 0, value);
            }

            return (null);
        }
    }
}
