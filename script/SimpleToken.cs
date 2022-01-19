﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script;
using Tilde.script.parser;

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

        public bool IsFirstNoToken() => (FirstTokenType == TokenType.NO_TOKEN);

        public bool IsSecondNoToken() => (SecondTokenType == TokenType.NO_TOKEN);

        public bool IsEqualSecondToken(char character) => (character == secondToken);
    }
}
