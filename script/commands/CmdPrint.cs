using Tilde.script.commands;
using Tilde.script.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.script
{
    /// <summary>
    /// CmdPrint - 
    /// </summary>
    class CmdPrint : Cmd
    {
        private const string COMMAND = "PRINT";

        private Expression expression = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public CmdPrint() : base(COMMAND)
        {
            expression = new Expression();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public override Node Translate(Parser parser)
        {
            Token lastExpToken = Token.CreateBeginExpMarker();

            NodePrint printNode = new NodePrint();

            while (!lastExpToken.IsEOS())
            {
                Node node = expression.Translate(parser);

                printNode.Add(node);

                lastExpToken = expression.LastToken;
            }

            return (printNode);
        }
    }
}
