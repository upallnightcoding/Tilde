using Tilde.script.commands;
using Tilde.script.nodes;
using Tilde.script.parser;

namespace Tilde.script
{
    class TildeScript
    {
        private SourceCode source = null;

        public TildeScript(SourceCode source)
        {
            this.source = source;
        }

        public void Execute()
        {
            Parser parser = new Parser(source);

            Token program = parser.GetToken();

            Token programName = parser.GetToken();

            Cmd codeBlock = new CmdCodeBlock();

            Node node = codeBlock.Translate(parser);

            Context context = new Context();

            node.Evaluate(context);
        }
    }
}
