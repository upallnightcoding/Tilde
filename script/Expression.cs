using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.commands;

namespace Tilde.script
{
    class Expression
    {
        private Stack<Node> varStack = null;
        private Stack<Token> operStack = null;

        public Token LastToken { get; set; } = null;

        public Expression()
        {
            
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public Node Translate(Parser parser)
        {
            Initialize();

            Token token = parser.GetToken();

            while(!EndOfExpression(token))
            {
                if (token.IsAConstant())
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

        private void PopOperStack()
        {
            Node rValue = varStack.Pop();
            Node lValue = varStack.Pop();

            Token oper = operStack.Pop();

            varStack.Push(oper.CreateNodeOperator(lValue, rValue));
        }

        private void PushVarStack(Token token)
        {
            varStack.Push(token.CreateNodeValue());
        }

        private bool EndOfExpression(Token token)
        {
            return (token.IsComma() || token.IsEOS());
        }
    }
}
