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
    class NodeAssign : Node
    {
        private string variable = null;

        public NodeAssign(Token variable)
        {
            this.variable = variable.GetVariable();
        }

        public override NodeValue Execute(Context context)
        {
            NodeValue expression = (NodeValue)(GetNode(0).Execute(context));

            context.GetSymbolTable().Assign(variable, 0, expression);

            return (null);
        }
    }
}
