using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.commands;
using Tilde.script.nodes;

namespace Tilde.script
{
    class Expression
    {
        public Token LastToken { get; set; } = null;

        private Stack<Node> varStack = null;
        private Stack<Token> operStack = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Expression()
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
                if (token.IsAConstant() || token.IsAKeyWord())
                {
                    PushVarStack(token);
                } 
                else if (token.IsOperator())
                {
                    PushOperStack(token, false);
                }
                else if (token.IsLeftParen())
                {
                    PushOperStack(token, true);
                }
                else if (token.IsRightParen())
                {
                    PopParenStack();
                }

                token = parser.GetToken();
            }

            EmptyOperStack(token);            

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

        private void EmptyOperStack(Token token)
        {
            while (!operStack.Peek().IsEndOperStack())
            {
                PopOperStack();
            }

            LastToken = token;
        }

        private void PushOperStack(Token token, bool force)
        {
            while (!force && (token.Rank() <= operStack.Peek().Rank()))
            {
                PopOperStack();
            }

            operStack.Push(token);
        }

        private void PopParenStack()
        {
            while(!operStack.Peek().IsLeftParen())
            {
                PopOperStack();
            }

            operStack.Pop();
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
        /// PushVarStack() - 
        /// </summary>
        /// <param name="token"></param>
        private void PushVarStack(Token token)
        {
            varStack.Push(token.CreateNodeValue());
        }

        /// <summary>
        /// EndOfExpression() - 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private bool EndOfExpression(Token token)
        {
            return (token.IsComma() || token.IsEOS());
        }
    }
}
