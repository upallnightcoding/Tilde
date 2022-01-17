﻿using Tilde.script.commands;

namespace Tilde.script.nodes
{
    class NodeAdd : Node
    {
        public NodeAdd(Node vLeft, Node vRight)
        {
            Add(vLeft);
            Add(vRight);
        }

        public override NodeValue Execute(Context context)
        {
            NodeValue value = null;

            NodeValue vLeft = GetNode(0).Execute(context);
            NodeValue vRight = GetNode(1).Execute(context);

            if (vLeft.IsFloat() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() + vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetInteger() + vRight.GetInteger());
            }
            else if (vLeft.IsFloat() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetFloat() + vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() + vRight.GetFloat());
            }

            return (value);
        }
    }
}
