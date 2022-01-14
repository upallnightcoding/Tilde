using Tilde.script.commands;

namespace Tilde.script.nodes
{
    class NodeDivide : Node
    {
        public NodeDivide(Node vLeft, Node vRight)
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
                value = new NodeValue(vLeft.GetFloat() / vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetInteger() / vRight.GetInteger());
            }
            else if (vLeft.IsFloat() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetFloat() / vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() / vRight.GetFloat());
            }

            return (value);
        }
    }
}
