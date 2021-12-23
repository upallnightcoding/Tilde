using Leo.script.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
using Tilde.script.commands;

namespace Leo.script.commands.declare
{
    /// <summary>
    /// CmdDeclare - 
    /// </summary>
    class CmdDeclare : Cmd
    {
        private VariableType type = VariableType.UNKNOWN;

        public CmdDeclare(string command) : base(command)
        {
            Token token = Token.CreateKeyWordToken(command);

            type = token.GetVariableType();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public override Node Translate(Parser parser)
        {
            NodeDeclare nodeDeclare = new NodeDeclare(type);

            Token variable = parser.GetToken();

            while (!variable.IsEOS())
            {
                nodeDeclare.Add(new NodeDeclareVar(type, variable));

                variable = ReadNextToken(parser); 
            }

            return (nodeDeclare);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private Token ReadNextToken(Parser parser)
        {
            Token token = parser.GetToken();

            if (token.IsComma())
            {
                token = parser.GetToken();
            }

            return (token);
        }
    }
}
