using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.tilde.commands;
using Tilde.tilde.nodes;

namespace Leo.tilde.nodes
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
        public override NodeValue Execute()
        {
            NodeValue value = null;

            NodeValue vLeft = ((NodeValue) GetNode(0)).Execute();
            NodeValue vRight = ((NodeValue) GetNode(1)).Execute();

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
