using System.Collections.Generic;

namespace Leo.script.symbol
{
    class SymbolScope
    {
        // Variables declared in the current scope
        //----------------------------------------
        List<SymbolTableRec> variables = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public SymbolScope()
        {
            variables = new List<SymbolTableRec>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Add() - 
        /// </summary>
        /// <param name="record"></param>
        public void Add(SymbolTableRec record)
        {
            if (record != null)
            {
                variables.Add(record);
            }
        }

        /// <summary>
        /// Find() - 
        /// </summary>
        /// <param name="variable"></param>
        /// <returns></returns>
        public SymbolTableRec Find(string variable)
        {
            SymbolTableRec record = null;

            return (record);
        }
    }
}
