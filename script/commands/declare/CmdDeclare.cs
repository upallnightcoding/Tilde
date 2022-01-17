using Leo.script;
using System.Collections.Generic;
using Tilde.script.nodes;
using Tilde.script.symbol;

namespace Tilde.script.commands.declare
{
    /// <summary>
    /// CmdDeclare - 
    /// </summary>
    class CmdDeclare : Cmd
    {
        private VariableType type = VariableType.UNKNOWN;

        private Expression expression = null;

        public CmdDeclare(string command) : base(command)
        {
            Token token = Token.CreateSymbolToken(command);

            this.type = token.GetVariableType();
            this.expression = new Expression();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public override Node Translate(Parser parser)
        {
            NodeDeclare nodeDeclare = new NodeDeclare(type);

            Token variable = new Token();

            while (!variable.IsEOS())
            {
                Node initialize = null;

                ArrayElement arrayElement = null;

                variable = parser.GetToken(); 

                Token token = parser.GetToken();

                if (token.IsLeftBracket())
                {
                    arrayElement = new ArrayElement();

                    while (!token.IsRightBracket())
                    {
                        arrayElement.Add(expression.Translate(parser));

                        token = expression.LastToken;
                    }

                    token = parser.GetToken();
                }

                if (token.IsAssign())
                {
                    initialize = expression.Translate(parser);

                    token = expression.LastToken;
                } 
                
                nodeDeclare.Add(new NodeDeclareVar(type, variable, arrayElement, initialize));

                variable = token;
            }

            return (nodeDeclare);
        }
    }
}
