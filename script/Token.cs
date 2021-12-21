using Tilde.script.commands;
using Tilde.script.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leo.script.nodes;

namespace Tilde.script
{
    class Token
    {
        // Default Token Type
        //-------------------
        private TokenType type = TokenType.UNKNOWN;

        // Containers for each of the possible token types
        //------------------------------------------------
        private long iValue = 0;
        private string sValue = null;
        private double fValue = 0;
        private char cValue = ' ';
        private bool bValue = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Token()
        {
            this.type = TokenType.UNKNOWN;
        }

        public Token(long iValue)
        {
            this.type = TokenType.INTEGER;
            this.iValue = iValue;
        }

        public Token(double fValue)
        {
            this.type = TokenType.FLOAT;
            this.fValue = fValue;
        }

        public Token(TokenType type)
        {
            this.type = type;
        }

        private Token(TokenType type, string text)
        {
            this.type = type;
            this.sValue = text;
        }

        private Token(char cValue)
        {
            this.type = TokenType.CHARACTER;
            this.cValue = cValue;
        }

        /// <summary>
        /// GetKeyword() - Returns the string as a Script keyword
        /// </summary>
        /// <returns></returns>
        public string GetKeyword()
        {
            return (sValue.ToUpper());
        }

        /// <summary>
        /// GetVariable() - 
        /// </summary>
        /// <returns></returns>
        public string GetVariable()
        {
            return (sValue);
        }

        /*******************************/
        /*** Public Static Functions ***/
        /*******************************/

        public static Token CreateEOCToken() => (new Token(TokenType.EOC));

        public static Token CreateStringToken(string text) => (new Token(TokenType.STRING, text));

        public static Token CreateKeyWordToken(string text) => (new Token(TokenType.KEYWORD, text));

        public static Token CreateCharToken(char character) => (new Token(character));

        public static Token CreateOperStackMarker() => (new Token(TokenType.OPER_STACK_MARKER));

        public static Token CreateBeginExpMarker() => (new Token(TokenType.BEGIN_EXP_MARKER));

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// GetVariableType() - 
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public VariableType GetVariableType()
        {
            VariableType type = VariableType.UNKNOWN;

            switch (sValue.ToUpper())
            {
                case "INTEGER":
                    type = VariableType.INTEGER;
                    break;
                case "FLOAT":
                    type = VariableType.FLOAT;
                    break;
                case "BOOLEAN":
                    type = VariableType.BOOLEAN;
                    break;
                case "STRING":
                    type = VariableType.STRING;
                    break;
                case "CHARACTER":
                    type = VariableType.CHARACTER;
                    break;
            }

            return (type);
        }

        /// <summary>
        /// CreateNodeOperator() - 
        /// </summary>
        /// <param name="leftValue"></param>
        /// <param name="rightValue"></param>
        /// <returns></returns>
        public Node CreateNodeOperator(Node leftValue, Node rightValue)
        {
            Node node = null;

            switch(type)
            {
                case TokenType.ADD:
                    node = new NodeAdd(leftValue, rightValue);
                    break;
                case TokenType.SUBTRACT:
                    node = new NodeSubtract(leftValue, rightValue);
                    break;
                case TokenType.MULTIPLY:
                    node = new NodeMultiply(leftValue, rightValue);
                    break;
                case TokenType.DIVIDE:
                    break;
            }

            return (node);
        }

        /// <summary>
        /// CreateNodeValue() - 
        /// </summary>
        /// <returns></returns>
        public Node CreateNodeValue()
        {
            Node node = null;

            switch(type)
            {
                case TokenType.FLOAT:
                    node = new NodeValue(fValue);
                    break;
                case TokenType.INTEGER:
                    node = new NodeValue(iValue);
                    break;
                case TokenType.STRING:
                    node = new NodeValue(sValue);
                    break;
            }

            return (node);
        }

        public int Rank()
        {
            int value = -1;

            switch(type)
            {
                case TokenType.MULTIPLY:
                case TokenType.DIVIDE:
                    value = 20;
                    break;
                case TokenType.ADD:
                case TokenType.SUBTRACT:
                    value = 10;
                    break;
                case TokenType.LEFT_PAREN:
                    value = 1;
                    break;
                case TokenType.OPER_STACK_MARKER:
                    value = 0;
                    break;
            }

            return (value);
        }

        /***************************/
        /*** Predicate Functions ***/
        /***************************/

        public bool IsEOC() => (type == TokenType.EOC);

        public bool IsEOS() => (type == TokenType.EOS);

        public bool IsComma() => (type == TokenType.FIELD_SEPARATOR);

        public bool IsEndOperStack() => (type == TokenType.OPER_STACK_MARKER);

        public bool IsRightBrace() => (type == TokenType.RIGHT_BRACE);

        public bool IsLeftBrace() => (type == TokenType.LEFT_BRACE);

        public bool IsLeftParen() => (type == TokenType.LEFT_PAREN);

        public bool IsRightParen() => (type == TokenType.RIGHT_PAREN);

        public bool IsOperator()
        {
            bool value = false;

            switch(type)
            {
                case TokenType.MULTIPLY:
                case TokenType.DIVIDE:
                case TokenType.SUBTRACT:
                case TokenType.ADD:
                    value = true;
                    break;
            }

            return (value);
        }

        public bool IsAConstant()
        {
            bool value = false;

            switch(type)
            {
                case TokenType.FLOAT:
                case TokenType.INTEGER:
                case TokenType.STRING:
                    value = true;
                    break;
            }

            return (value);
        }

        public void Debug()
        {
            switch(type)
            {
                case TokenType.FLOAT:
                    Console.WriteLine($"Type: {type} Value: {fValue}");
                    break;
                case TokenType.INTEGER:
                    Console.WriteLine($"Type: {type} Value: {iValue}");
                    break;
                case TokenType.STRING:
                    Console.WriteLine($"Type: {type} Value: {sValue}");
                    break;
                case TokenType.FIELD_SEPARATOR:
                    Console.WriteLine($"Type: {type}");
                    break;
            }
        }
    }
}
