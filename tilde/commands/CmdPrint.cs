using Tilde.tilde.commands;
using Tilde.tilde.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde
{
    class CmdPrint : Cmd
    {
        private static string COMMAND = "PRINT";

        public override string GetCommand()
        {
            return (COMMAND);
        }

        public override Node Translate(Parser parser)
        {
            NodePrint nodePrint = new NodePrint();

            Token token = parser.GetToken();

            while (!token.IsEOS())
            {
                nodePrint.Add(token.CreateNodeValue());

                token = parser.GetToken();

                if (token.IsComma())
                {
                    token = parser.GetToken();
                }
            }

            return (nodePrint);
        }
    }
}
