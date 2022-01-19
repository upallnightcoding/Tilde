using Leo.script.nodes;
using Leo.script.parser;
using Tilde.script;
using Tilde.script.nodes;
using Tilde.script.parser;

namespace Leo.script.commands
{
    /// <summary>
    /// CmdAssign - 
    /// </summary>
    class CmdAssign : Cmd
    {
        // Variable name property for assignment
        public Token Variable { get; set; }

        private const string COMMAND = "ASSIGN";

        private ParserTools parserTools = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public CmdAssign() : base(COMMAND)
        {
            parserTools = new ParserTools();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public override Node Translate(Parser parser)
        {
            Token token = null;

            NodeAssign nodeAssign = new NodeAssign(Variable);

            nodeAssign.ArrayElements = parserTools.GetArrayElements(parser, out token);

            nodeAssign.Add(parserTools.GetExpression(parser, out _));

            return (nodeAssign);
        }
    }
}
