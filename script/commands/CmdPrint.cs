using Tilde.script.commands;
using Tilde.script.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.script
{
    class CmdPrint : Cmd
    {
        private static string COMMAND = "PRINT";

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

            NodePrint nodePrint = new NodePrint();

            while (!lastExpToken.IsEOS())
            {
                Node node = expression.Translate(parser);

                nodePrint.Add(node);

                lastExpToken = expression.LastToken;
            }

            return (nodePrint);
        }
    }
}
