using Tilde.script.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Tilde.script.nodes
{
    class NodeDeclare : Node
    {
        private VariableType type = VariableType.UNKNOWN;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeDeclare(VariableType type)
        {
            this.type = type;
        }

        public override NodeValue Execute(Context context)
        {
            foreach (Node node in GetNodeList())
            {
                node.Execute(context);
            }

            return (null);
        }
    }
}
