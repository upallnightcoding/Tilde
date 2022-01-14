using Tilde.script.commands;

namespace Tilde.script.nodes
{
    class NodeSubtract : Node
    {
        public NodeSubtract(Node vLeft, Node vRight)
        {
            Add(vLeft);
            Add(vRight);
        }

        /// <summary>
        /// Execute() - Grabs the two node values off of the node list and
        /// attempts to subtract the node values.  The subtraction is based
        /// on the type of the node values.
        /// </summary>
        /// <returns></returns>
        public override NodeValue Execute(Context context)
        {
            NodeValue value = null;

            NodeValue vLeft = (NodeValue) (GetNode(0).Execute(context));
            NodeValue vRight = (NodeValue) (GetNode(1).Execute(context));

            if (vLeft.IsFloat() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() - vRight.GetFloat());
            } 
            else if (vLeft.IsInteger() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetInteger() - vRight.GetInteger());
            }
            else if (vLeft.IsFloat() && vRight.IsInteger())
            {
                value = new NodeValue(vLeft.GetFloat() - vRight.GetFloat());
            }
            else if (vLeft.IsInteger() && vRight.IsFloat())
            {
                value = new NodeValue(vLeft.GetFloat() - vRight.GetFloat());
            }

            return (value);
        }
    }
}
