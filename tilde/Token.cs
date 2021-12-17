using Tilde.tilde.commands;
using Tilde.tilde.nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde
{
    class Token
    {
        private TokenType type = TokenType.UNKNOWN;

        // Token Constant Values
        private long lValue = 0;
        private string sValue = null;
        private double dValue = 0;
        private char cValue = ' ';
        private bool bValue = false;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Token(long lValue)
        {
            this.type = TokenType.INTEGER;
            this.lValue = lValue;
        }

        public Token(double dValue)
        {
            this.type = TokenType.FLOAT;
            this.dValue = dValue;
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

        public string getKeyword()
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

        /************************/
        /*** Public Functions ***/
        /************************/

        public Node CreateNodeValue()
        {
            Node node = null;

            switch(type)
            {
                case TokenType.FLOAT:
                    node = new NodeValue(dValue);
                    break;
                case TokenType.INTEGER:
                    node = new NodeValue(lValue);
                    break;
                case TokenType.STRING:
                    node = new NodeValue(sValue);
                    break;
            }

            return (node);
        }

        public bool IsEOC() => (type == TokenType.EOC);

        public bool IsEOS() => (type == TokenType.EOS);

        public bool IsComma() => (type == TokenType.FIELD_SEPARATOR);

        public bool IsRightBrace() => (type == TokenType.RIGHT_BRACE);

        public bool IsLeftBrace() => (type == TokenType.LEFT_BRACE);

        public void Debug()
        {
            switch(type)
            {
                case TokenType.FLOAT:
                    Console.WriteLine($"Type: {type} Value: {dValue}");
                    break;
                case TokenType.INTEGER:
                    Console.WriteLine($"Type: {type} Value: {lValue}");
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
