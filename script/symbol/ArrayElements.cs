﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.nodes;

namespace Leo.script.symbol
{
    /// <summary>
    /// ArrayElements - This class is used as a base class to house all 
    /// array elements that are used to declare an array, return the
    /// value of an array or assign a value to an array.
    /// </summary>
    class ArrayElements
    {
        // List of array elements as nodes
        public List<Node> AllElements { get; private set; } = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ArrayElements()
        {
            AllElements = new List<Node>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// nOfElements() - 
        /// </summary>
        /// <returns></returns>
        public int nOfElements()
        {
            return (AllElements.Count);
        }

        /// <summary>
        /// Add() - Adds an array element as a node in the array element list.
        /// The elements of the array are translated from left to right.  The
        /// left most element is list position 0, the second element is list
        /// position 2 and so on.  If the node is null, it is not added to the
        /// array elements.
        /// 
        /// Example:
        ///     Array[n0, n1, n2] => List ... n0, n1, n2
        /// 
        /// </summary>
        /// <param name="node"></param>
        public void Add(Node node)
        {
            if (node != null)
            {
                AllElements.Add(node);
            }
        }

    }
}
