using Tilde.script.nodes;
using System.Collections.Generic;
using System.Linq;
using Leo.script.commands;

namespace Tilde.script.nodes
{
    abstract class Node
    {
        private List<Node> nodeList = null;

        public abstract NodeValue Execute(Context context);

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

        /// <summary>
        /// GetNode() - Return a node from a given index in the nodelist.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        protected Node GetNode(int index)
        {
            return (nodeList.ElementAt(index));
        }

        /// <summary>
        /// GetNodeList() - Return the entire node list, this is mainly 
        /// used for looping through each element in the node list.
        /// </summary>
        /// <returns></returns>
        protected List<Node> GetNodeList()
        {
            return (nodeList);
        }
    }
}
