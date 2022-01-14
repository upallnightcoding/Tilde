using Tilde.script.commands;
using Tilde.script.nodes;

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

            node.Execute(context);
        }
    }
}
