using Tilde.tilde.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde
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

            node.Execute();
        }
    }
}
