using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.nodes;
using Tilde.script.parser;

namespace Leo.script.parser
{
    class ParserTools
    {
        public Node GetExpression(Parser parser, out Token LastExpToken)
        {
            ParseExpression expression = new ParseExpression();

            Node node = expression.Translate(parser);

            LastExpToken = expression.LastToken;

            return (node);
        }

        public ArrayElement GetArrayElements(Parser parser, out Token NextLeadingToken)
        {
            ParseArrayElements parseArrayElements = new ParseArrayElements();

            ArrayElement arrayElement = parseArrayElements.Translate(parser);

            NextLeadingToken = parseArrayElements.LeadingToken();

            return (arrayElement);
        }
    }
}
