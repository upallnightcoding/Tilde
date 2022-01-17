using Tilde.script.commands;
using Tilde.script.symbol;

namespace Tilde.script.nodes
{
    class NodeDeclare : Node
    {
        private VariableType type = VariableType.UNKNOWN;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeDeclare(VariableType type) // TODO : Remove this type parameter
        {
            this.type = type;
        }

        public override NodeValue Execute(Context context)
        {
            foreach (Node node in GetNodeList())
            {
                node.Execute(context);
            }

            return (null);
        }
    }
}
