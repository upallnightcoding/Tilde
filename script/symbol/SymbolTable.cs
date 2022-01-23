using Leo.script;
using Leo.script.symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Tilde.script.symbol
{
    /// <summary>
    /// SymbolTable - 
    /// </summary>
    class SymbolTable
    {
        private ScopeLevels[] scopeLevels = null;

        private int scopeLevelPtr = -1;

        public SymbolTable()
        {
            scopeLevels = new ScopeLevels[10];

            CreateNewScopeLevel();
        }

        /// <summary>
        /// CreateNewScopeLevel() - 
        /// </summary>
        public void CreateNewScopeLevel()
        {
            scopeLevels[++scopeLevelPtr] = new ScopeLevels();
        }

        /// <summary>
        /// RemoveScopeLevel() - 
        /// </summary>
        public void RemoveScopeLevel()
        {
            scopeLevels[scopeLevelPtr--] = null;
        }

        /// <summary>
        /// Declare() - Allows for the declaration of an variable as a scalar
        /// or an array.  If the variable is a scalar the arrayElements
        /// parameter should be set to null.  If the variable is an array,
        /// the arrayElements object should contain the Nodes that represent
        /// the array elements.
        /// </summary>
        /// <param name="varType"></param>
        /// <param name="variable"></param>
        /// <param name="arrayElement"></param>
        /// <param name="context"></param>
        public void Declare(
            VariableType varType,
            string variable,
            ArrayElements arrayElements,
            Context context
        )
        {
            Add(new SymbolTableRec(varType, variable, arrayElements, context));
        }

        /// <summary>
        /// Assign() - Finds the variable record in the symbol table and 
        /// assigns the value at the element position.  The context object
        /// is needed the calculate the actual element values.
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="elements"></param>
        /// <param name="value"></param>
        /// <param name="context"></param>
        public void Assign(string variable, ArrayElements elements, NodeValue value, Context context)
        {
            SymbolTableRec record = Find(variable);

            if (record != null)
            {
                record.Assign(elements, value, context);
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

            for (int scope = scopeLevelPtr; (scope >= 0) && (record == null); scope--)
            {
                record = scopeLevels[scope].Find(variable);
            }

            return (record);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        /// <summary>
        /// Add() - Addres a symbol table record to the current scope level.
        /// Null symbol table records are not added to the scope levels.
        /// </summary>
        /// <param name="record"></param>
        private void Add(SymbolTableRec record)
        {
            if (record != null)
            {
                scopeLevels[scopeLevelPtr].Add(record);
            }
        }
    }
}
