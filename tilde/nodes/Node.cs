using Tilde.tilde.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde.commands
{
    abstract class Node
    {
        private List<Node> nodeList = null;

        public abstract NodeValue Execute();

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Node()
        {
            nodeList = new List<Node>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Add(Node node)
        {
            if (node != null)
            {
                nodeList.Add(node);
            }
        }

        /***************************/
        /*** Protected Functions ***/
        /***************************/

        protected List<Node> GetNodeList()
        {
            return (nodeList);
        }
    }
}
