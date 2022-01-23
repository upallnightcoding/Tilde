using Leo.script;
using Leo.script.symbol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Tilde.script.parser
{
    class ParseExpression 
    {
        public Token LastToken { get; set; } = null;

        private Stack<Node> varStack = null;
        private Stack<Token> operStack = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public ParseExpression()
        {
            
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Translate() - 
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        public Node Translate(Parser parser)
        {
            Initialize();

            Token token = parser.GetToken();

            while(!EndOfExpression(token))
            {
                if (token.IsAConstant())
                {
                    token = PushConstStack(parser, token);
                } 
                else if (token.IsASymbol())
                {
                    token = PushVarStack(parser, token);
                }
                else if (token.IsOperator())
                {
                    token = PushOperStack(parser, token, false);
                }
                else if (token.IsLeftParen())
                {
                    token = PushOperStack(parser, token, true);
                }
                else if (token.IsRightParen())
                {
                    token = PopParenStack(parser);
                }
            }

            EmptyOperStack();

            LastToken = token;

            return (varStack.Peek());
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private void Initialize()
        {
            varStack = new Stack<Node>();
            operStack = new Stack<Token>();

            operStack.Push(Token.CreateOperStackMarker());
        }

        /// <summary>
        /// EmptyOperStack() - Pops all of the operators off the operator stack
        /// as the last task to complete the expression translation.  The end 
        /// result of this function will have the final expression node as the
        /// only node left in the operator stack.
        /// </summary>
        private void EmptyOperStack()
        {
            while (!operStack.Peek().IsEndOperStack())
            {
                PopOperStack();
            }
        }

        /// <summary>
        /// PushOperStack() - Pushes an operator or a left paren on the operator
        /// stack.  If the token is a left paren, it is place on the stack
        /// without reguard to the current operator on top of the stack.  If
        /// the token is an operator, it is compared to the rank of the operator
        /// currently at the top of the stack.  
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="token"></param>
        /// <param name="leftParen"></param>
        /// <returns></returns>
        private Token PushOperStack(Parser parser, Token token, bool leftParen)
        {
            while (!leftParen && (token.Rank() <= operStack.Peek().Rank()))
            {
                PopOperStack();
            }

            operStack.Push(token);

            return (parser.GetToken());
        }

        /// <summary>
        /// PopParenStack() - 
        /// </summary>
        /// <param name="parser"></param>
        /// <returns></returns>
        private Token PopParenStack(Parser parser)
        {
            while(!operStack.Peek().IsLeftParen())
            {
                PopOperStack();
            }

            operStack.Pop();

            return (parser.GetToken());
        }

        /// <summary>
        /// PopOperStack() - 
        /// </summary>
        private void PopOperStack()
        {
            Node rValue = varStack.Pop();
            Node lValue = varStack.Pop();

            Token oper = operStack.Pop();

            varStack.Push(oper.CreateNodeOperator(lValue, rValue));
        }

        /// <summary>
        /// PushConstStack() - Places the constant token directly on the 
        /// </summary>
        /// <param name="parser"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        private Token PushConstStack(Parser parser, Token token)
        {
            varStack.Push(token.CreateNodeValue());

            return (parser.GetToken()); // Return Next Lead Token
        }

        /// <summary>
        /// PushVarStack() - 
        /// </summary>
        /// <param name="variable"></param>
        private Token PushVarStack(Parser parser, Token variable)
        {
            NodeValue value = variable.CreateNodeValue();

            Token token = parser.GetToken();

            if (token.IsLeftBracket())
            {
                ArrayElements arrayElements = new ArrayElements();

                ParseExpression expression = new ParseExpression();

                while (!token.IsRightBracket())
                {
                    arrayElements.Add(expression.Translate(parser));

                    token = expression.LastToken;
                }

                value.Elements = arrayElements;

                token = parser.GetToken();
            }

            varStack.Push(value);

            return (token); // Return Next Lead Token
        }

        /// <summary>
        /// EndOfExpression() - Defines the token that will mark the end of an
        /// expression.  If the token is one of the end of expression markers,
        /// a true is retuned.  If it is not, a false is returned.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool EndOfExpression(Token token)
        {
            return (token.IsComma() || token.IsEOS() || token.IsRightBracket());
        }
    }
}
