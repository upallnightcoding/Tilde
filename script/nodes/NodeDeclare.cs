using Tilde.script.commands;
using Tilde.script.symbol;

namespace Tilde.script.nodes
{
    /// <summary>
    /// NodeDeclare
    /// </summary>
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

        /************************/
        /*** Public Functions ***/
        /************************/

        public override NodeValue Evaluate(Context context)
        {
            foreach (Node node in GetNodeList())
            {
                node.Evaluate(context);
            }

            return (null);
        }
    }
}
