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
