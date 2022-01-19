using Tilde.script.commands;
using System;

namespace Tilde.script.nodes
{
    class NodePrint : Node
    {
        /// <summary>
        /// Execute() - 
        /// </summary>
        public override NodeValue Evaluate(Context context)
        {

            foreach(Node node in GetNodeList())
            {
                Node value = node.Evaluate(context);

                Console.Write(((NodeValue)value).GetString());
            }

            Console.WriteLine("");

            return (null);
        }
    }
}
