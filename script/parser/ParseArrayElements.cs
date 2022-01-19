using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.nodes;
using Tilde.script.parser;

namespace Leo.script.parser
{
    class ParseArrayElements
    {
        private Token token = null;
        private ArrayElement arrayElement = null;
        private ParseExpression expression = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ParseArrayElements()
        {
            this.expression = new ParseExpression();
        }

        /************************/
        /*** Public FUnctions ***/
        /************************/

        public ArrayElement Translate(Parser parser)
        {
            token = parser.GetToken();  

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

            return (arrayElement);
        }

        public Token LeadingToken()
        {
            return (token);
        }
    }
}
