using Tilde.script.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leo.script.commands;

namespace Tilde.script.nodes
{
    class NodePrint : Node
    {
        /// <summary>
        /// Execute() - 
        /// </summary>
        public override NodeValue Execute(Context context)
        {

            foreach(Node node in GetNodeList())
            {
                Node value = node.Execute(context);

                Console.Write(((NodeValue)value).GetString());
            }

            Console.WriteLine("");

            return (null);
        }
    }
}
