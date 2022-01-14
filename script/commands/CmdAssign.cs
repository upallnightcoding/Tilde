using Leo.script.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
using Tilde.script.nodes;

namespace Leo.script.commands
{
    /// <summary>
    /// CmdAssign - 
    /// </summary>
    class CmdAssign : Cmd
    {
        // Variable name property for assignment
        public Token Variable { get; set; }

        private const string COMMAND = "ASSIGN";

        private Expression expression = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public CmdAssign() : base(COMMAND)
        {
            expression = new Expression();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public override Node Translate(Parser parser)
        {
            // Skip assignment token
            parser.GetToken();

            NodeAssign nodeAssign = new NodeAssign(Variable);

            nodeAssign.Add(expression.Translate(parser));

            return (nodeAssign);
        }
    }
}
