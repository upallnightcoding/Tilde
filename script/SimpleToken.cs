using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;

namespace Leo.script
{
    /// <summary>
    /// SimpleToken - This class
    /// </summary>
    class SimpleToken
    {
        private char firstToken;
        private char secondToken;

        public TokenType FirstTokenType { get; }

        public TokenType SecondTokenType { get; }

        public SimpleToken(
            char firstToken, 
            char secondToken, 
            TokenType firstTokenType, 
            TokenType secondTokenType
        )
        {
            this.firstToken = firstToken;
            this.secondToken = secondToken;
            this.FirstTokenType = firstTokenType;
            this.SecondTokenType = secondTokenType;
        }

        public bool isFirstNoToken() => (FirstTokenType == TokenType.NO_TOKEN);

        public bool isSecondNoToken() => (SecondTokenType == TokenType.NO_TOKEN);

        public bool isEqualSecondToken(char character) => (character == secondToken);
    }
}
