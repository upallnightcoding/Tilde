using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
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
        /// Declare() - 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="variable"></param>
        /// <param name="size"></param>
        public void Declare(VariableType type, string variable, int size)
        {
            Add(new SymbolTableRec(type, variable, size));
        }

        /// <summary>
        /// Assign() - 
        /// </summary>
        /// <param name="variable"></param>
        /// <param name="offset"></param>
        /// <param name="value"></param>
        public void Assign(string variable, int offset, NodeValue value)
        {
            SymbolTableRec record = Find(variable);

            if (record != null)
            {
                record.Assign(offset, value);
            }
        }

        public SymbolTableRec Find(string variable)
        {
            SymbolTableRec record = null;

            for (int scope = scopeLevelPtr; (scope >= 0) && (record == null); scope--)
            {
                record = scopeLevels[scope].Find(variable);
            }

            return (record);
        }

        /**************************/
        /*** Parivate Functions ***/
        /**************************/

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
