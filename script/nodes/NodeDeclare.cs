using Leo.script.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Leo.script.nodes
{
    class NodeDeclare : Node
    {
        private VariableType type = VariableType.UNKNOWN;

        private string variable = null;

        private int size = -1;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeDeclare(VariableType type, string variable, int size = 1)
        {
            this.type = type;
            this.variable = variable;
            this.size = size;
        }

        public override NodeValue Execute(Context context)
        {
            Console.WriteLine("Type: " + type + " " + variable);

            return (null);
        }
    }
}
