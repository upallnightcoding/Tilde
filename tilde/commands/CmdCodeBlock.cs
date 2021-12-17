using Tilde.tilde.nodes;

namespace Tilde.tilde.commands
{
    /// <summary>
    /// CmdCodeBlock - 
    /// </summary>
    class CmdCodeBlock : Cmd
    {
        /// <summary>
        /// GetCommand() - 
        /// </summary>
        /// <returns></returns>
        public override string GetCommand()
        {
            return (null);
        }

        /// <summary>
        /// Interpret() - 
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public override Node Translate(Parser parser)
        {

            Token leftBrace = parser.GetToken();

            return (ParseCodeBlock(parser));
        }

        /// <summary>
        /// ParseCodeBlock() - Translates a code block that starts with a "{"
        /// and ends with a "}".  Each command inside the coding block is 
        /// translated as long as it is part of the command factory.  If the
        /// code block are nested the code block nodes are also nested.
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        private Node xxParseCodeBlock(Parser parser)
        {
            NodeCodeBlock codeBlock = new NodeCodeBlock();

            Token token = parser.GetToken();

            do
            {
                Cmd command = CmdFactory.INSTANCE.GetCommand(token);

                Node node = command.Translate(parser);

                codeBlock.Add(node);

                token = parser.GetToken();

                if (token.IsLeftBrace())
                {
                    codeBlock.Add(ParseCodeBlock(parser));
                    token = parser.GetToken();
                }
                else if (!token.IsEOC() && !token.IsRightBrace())
                {
                    command = CmdFactory.INSTANCE.GetCommand(token);
                }

            } while (!token.IsEOC() && !token.IsRightBrace());

            return (codeBlock);
        }

        private Node ParseCodeBlock(Parser parser)
        {
            NodeCodeBlock codeBlock = new NodeCodeBlock();

            Token keyWord = parser.GetToken();

            Cmd command = CmdFactory.INSTANCE.GetCommand(keyWord);

            while (!keyWord.IsEOC() && !keyWord.IsRightBrace())
            {
                Node node = command.Translate(parser);

                codeBlock.Add(node);

                keyWord = parser.GetToken();

                if (keyWord.IsLeftBrace())
                {
                    codeBlock.Add(ParseCodeBlock(parser));
                }
                else if (!keyWord.IsEOC() && !keyWord.IsRightBrace())
                {
                    command = CmdFactory.INSTANCE.GetCommand(keyWord);
                }
            }

            return (codeBlock);
        }
    }
}
