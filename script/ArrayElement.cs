using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Leo.script
{
    /// <summary>
    /// ArrayElement - This class is used to contain the elements of an array
    /// as the array is being declared or using on the left or right side of
    /// an assignment statement.
    /// </summary>
    class ArrayElement
    {
        // List of array elements as nodes
        private List<Node> arrayElement = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ArrayElement()
        {
            arrayElement = new List<Node>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Add() - Adds an array element as a node in the array element list.
        /// The elements of the array are translated from left to right.  The
        /// left most element is list position 0, the second element is list
        /// position 2 and so on.  If the node is null, it is not added to the
        /// array elements.
        /// 
        /// Example:
        ///     Array[n1, n2, n3] => List ... n1, n2, n3
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node node)
        {
            if (node != null)
            {
                arrayElement.Add(node);
            }
        }

        /// <summary>
        /// CalcSize() - Calculates the size of the array based on the elements
        /// of the array declaration.  If the variable is a scalar, this 
        /// function should never be invoked.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public int CalcSize(Context context)
        {
            int size = 1;

            foreach (Node element in arrayElement)
            {
                size *= (int) element.Evaluate(context).GetInteger();
            }

            return (size);
        }

        /// <summary>
        /// CalcIndex() - 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public int CalcIndex(Context context)
        {
            int index = -1;

            switch(arrayElement.Count())
            {
                case 1:
                    index = (int) arrayElement.ElementAt<Node>(0).Evaluate(context).GetInteger();
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }

            return (index);
        }
    }
}
