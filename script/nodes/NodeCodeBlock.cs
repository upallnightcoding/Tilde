using Tilde.script.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.commands;

namespace Tilde.script.nodes
{
    class NodeCodeBlock : Node
    {
        public override NodeValue Execute(Context context)
        {
            foreach (Node node in GetNodeList()) {
                node.Execute(context);
            }

            return (null);
        }
    }
}
