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
        private VariableType currentType = VariableType.UNKNOWN;

        public CmdDeclare(string command) : base(command)
        {
            Token token = Token.CreateKeyWordToken(command);

            currentType = token.GetVariableType();
        }

        public override Node Translate(Parser parser)
        {
            Node node = null;

            Token token = parser.GetToken();

            while (!token.IsEOS())
            {
                DeclareVariable(currentType, token);

                token = ReadNextToken(parser); 
            }

            return (node);
        }

        private Token ReadNextToken(Parser parser)
        {
            Token token = parser.GetToken();

            if (token.IsComma())
            {
                token = parser.GetToken();
            }

            return (token);
        }

        private void DeclareVariable(VariableType type, Token token)
        {
            Console.WriteLine("Type: " + type + " " + token.GetVariable());
        }

        private bool IsTokenAType(Token token)
        {
            VariableType newType = VariableType.UNKNOWN;

            switch(token.GetKeyword())
            {
                case "INTEGER":
                    newType = VariableType.INTEGER;
                    break;
                case "FLOAT":
                    newType = VariableType.FLOAT;
                    break;
                case "BOOLEAN":
                    newType = VariableType.BOOLEAN;
                    break;
                case "STRING":
                    newType = VariableType.STRING;
                    break;
                case "CHARACTER":
                    newType = VariableType.CHARACTER;
                    break;
            }

            bool setNewType = newType != VariableType.UNKNOWN;

            if (setNewType)
            {
                currentType = newType;
            }

            return (setNewType);
        }
    }
}
