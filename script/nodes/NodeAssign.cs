using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
using Tilde.script.commands;
using Tilde.script.nodes;
using Tilde.script.parser;

namespace Leo.script.nodes
{
    class NodeAssign : Node
    {
        private string variable = null;

        public ArrayElement ArrayElements { get; set; } = null;

        public NodeAssign(Token variable)
        {
            this.variable = variable.GetVariable();
        }

        public override NodeValue Evaluate(Context context)
        {
            NodeValue expression = GetNode(0).Evaluate(context);

            int index = ArrayElements.CalcIndex(context);

            context.GetSymbolTable().Assign(variable, index, expression);

            return (null);
        }
    }
}
