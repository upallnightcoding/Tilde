using Tilde.tilde.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde.nodes
{
    class NodePrint : Node
    {
        /// <summary>
        /// Execute() - 
        /// </summary>
        public override NodeValue Execute()
        {
            foreach(Node node in GetNodeList())
            {
                Console.WriteLine("Value: " + ((NodeValue)node).GetString());
            }

            Console.WriteLine("-------------");

            return (null);
        }
    }
}
