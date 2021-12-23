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

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeDeclareVar(VariableType type, Token variable)
        {
            this.type = type;
            this.variable = variable.GetVariable();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public override NodeValue Execute(Context context)
        {
            context.GetSymbolTable().Declare(type, variable, 1);

            Console.WriteLine("Type: " + type + " - Variable: " + variable);

            return (null);
        }
    }
}
