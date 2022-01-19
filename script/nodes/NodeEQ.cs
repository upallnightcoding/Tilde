using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Leo.script.nodes
{
    class NodeEQ : Node
    {
        public NodeEQ(Node vLeft, Node vRight)
        {
            Add(vLeft);
            Add(vRight);
        }

        public override NodeValue Evaluate(Context context)
        {
            NodeValue value = null;

            NodeValue vLeft = (NodeValue)(GetNode(0).Evaluate(context));
            NodeValue vRight = (NodeValue)(GetNode(1).Evaluate(context));

            if (vLeft.IsFloat() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() == vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetInteger() == vRight.GetInteger());
            }
            else if (vLeft.IsFloat() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetFloat() == vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() == vRight.GetFloat());
            }
            else if (vLeft.IsChar() && vRight.IsChar())
            {
                value = new NodeValue(vLeft.GetChar() == vRight.GetChar());
            }
            else if (vLeft.IsString() && vRight.IsString())
            {
                value = new NodeValue(vLeft.GetString() == vRight.GetString());
            }

            return (value);
        }
    }
}
