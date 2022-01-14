using Tilde.script.nodes;

namespace Tilde.script.commands.declare
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

            Expression expression = new Expression();

            Token variable = new Token();

            while (!variable.IsEOS())
            {
                variable = parser.GetToken(); 

                Token token = parser.GetToken();

                if (token.IsAssign())
                {
                    Node initialize = expression.Translate(parser);

                    nodeDeclare.Add(new NodeDeclareVar(type, variable, initialize));

                    if (expression.LastToken.IsEOS())
                    {
                        variable = expression.LastToken;
                    } 
                    else if (expression.LastToken.IsComma())
                    {
                        // Do Nothing
                    }
                } 
                else if (token.IsComma()) 
                {
                    nodeDeclare.Add(new NodeDeclareVar(type, variable));
                }
                else if (token.IsEOS())
                {
                    variable = token;
                }
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
