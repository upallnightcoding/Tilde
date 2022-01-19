using Tilde.script.commands;

namespace Tilde.script.nodes
{
    class NodeCodeBlock : Node
    {
        public override NodeValue Evaluate(Context context)
        {
            foreach (Node node in GetNodeList()) {
                node.Evaluate(context);
            }

            return (null);
        }
    }
}
