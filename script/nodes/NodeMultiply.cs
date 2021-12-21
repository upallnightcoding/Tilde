using Leo.script.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Leo.script.nodes
{
    class NodeMultiply : Node
    {
        public NodeMultiply(Node vLeft, Node vRight)
        {
            Add(vLeft);
            Add(vRight);
        }

        public override NodeValue Execute(Context context)
        {
            NodeValue value = null;

            NodeValue vLeft = (NodeValue)(GetNode(0).Execute(context));
            NodeValue vRight = (NodeValue)(GetNode(1).Execute(context));

            if (vLeft.IsFloat() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() * vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetInteger() * vRight.GetInteger());
            }
            else if (vLeft.IsFloat() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetFloat() * vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() * vRight.GetFloat());
            }

            return (value);
        }
    }
}
