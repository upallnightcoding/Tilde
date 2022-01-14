using Tilde.script.commands;

namespace Tilde.script.nodes
{
    class NodeDeclare : Node
    {
        private VariableType type = VariableType.UNKNOWN;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeDeclare(VariableType type)
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
