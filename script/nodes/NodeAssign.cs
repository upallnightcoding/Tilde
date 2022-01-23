using Leo.script.symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
using Tilde.script.commands;
using Tilde.script.nodes;
using Tilde.script.parser;

namespace Leo.script.nodes
{
    /// <summary>
    /// NodeAssign - This class is used to execute an assignment statement.  The
    /// variable contains the name of the variable that will recieve the 
    /// calculated expression.
    /// </summary>
    class NodeAssign : Node
    {
        private string variable = null;

        public ArrayElements Elements { get; set; } = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public NodeAssign(Token variable)
        {
            this.variable = variable.GetVariable();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Evaluate() - Evaluates the expression that will be assigned to
        /// the target variable.  The assign is done by the symbol table.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override NodeValue Evaluate(Context context)
        {
            NodeValue expression = GetNode(0).Evaluate(context);

            context.GetSymbolTable().Assign(variable, Elements, expression, context);

            return (null);
        }
    }
}
