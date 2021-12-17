using Tilde.tilde.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde.nodes
{
    class NodeCodeBlock : Node
    {
        public override NodeValue Execute()
        {
            foreach (Node node in GetNodeList()) {
                node.Execute();
            }

            return (null);
        }
    }
}
