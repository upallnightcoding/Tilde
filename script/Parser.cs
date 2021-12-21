using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.script
{
    class Parser
    {
        private static readonly char FLOATING_POINT_MARK = '.';
        private static readonly char STRING_INDICATOR = '\"';
        private static readonly char ZERO_CHAR = '0';

        // Reference to source code object
        private SourceCode source = null;

        private Dictionary<char, TokenType> simpleTokens = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Parser(SourceCode source)
        {
            this.source = source;

            CreateSimpleTokens();

            this.source.Reset();

            SkipBlanks();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public Token GetToken()
        {
            Token token = null;

            if (NotEoc())
            {
                char character = PeekChar();

                if (IsDigit(character) || (character == FLOATING_POINT_MARK))
                {
                    token = GetNumber();
                } else if (IsLetter(character))
                {
                    token = GetKeyWord();
                } else if (IsSimpleToken(character))
                {
                    token = GetSimpleToken();

                } else if (character == STRING_INDICATOR)
                {
                    token = GetString();
                } else if (character == '\'')
                {
                    token = GetChar();
                }

                SkipBlanks();
            } else
            {
                token = Token.CreateEOCToken();
            }

            return (token);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        private Token GetChar()
        {
            char character = GetNextChar();

            MoveNextChar();
            MoveNextChar();

            return (Token.CreateCharToken(character));
        }

        /// <summary>
        /// CreateSimpleTokens() - Creates the simple one character tokens that
        /// are used by the scripting language.  If these tokens are used in 
        /// combination with any other token, then it is NOT considered
        /// simple.
        /// </summary>
        private void CreateSimpleTokens()
        {
            simpleTokens = new Dictionary<char, TokenType>
            {
                [','] = TokenType.FIELD_SEPARATOR,

                // Operator Tokens
                //----------------
                ['+'] = TokenType.ADD,
                ['-'] = TokenType.SUBTRACT,
                ['*'] = TokenType.MULTIPLY,
                ['/'] = TokenType.DIVIDE,

                [';'] = TokenType.EOS,
                ['('] = TokenType.LEFT_PAREN,
                [')'] = TokenType.RIGHT_PAREN,
                ['{'] = TokenType.LEFT_BRACE,
                ['}'] = TokenType.RIGHT_BRACE
            };
        }

        private bool IsSimpleToken(char character)
        {
            return (simpleTokens.ContainsKey(character));
        }

        private Token GetSimpleToken()
        {
            TokenType type;
            Token token = null;
            char character = PeekChar();

            if (simpleTokens.TryGetValue(character, out type))
            {
                token = new Token(type);
                MoveNextChar();
            }

            return (token);
        }

        /// <summary>
        /// GetKeyWord() - 
        /// </summary>
        /// <returns></returns>
        private Token GetKeyWord()
        {
            StringBuilder value = new StringBuilder();

            char character = PeekChar();

            while (NotEoc() && IsLetter(character)) 
            {
                value.Append(character);

                character = GetNextChar();
            }

            return (Token.CreateKeyWordToken(value.ToString()));
        }

        /// <summary>
        /// GetInteger() - 
        /// </summary>
        /// <returns></returns>
        private Token GetNumber()
        {
            Token token = null;

            long lValue = GetInteger();

            if (NotEoc() && IsPeek(FLOATING_POINT_MARK))
            {
                token = new Token(GetFloat(lValue));
            } else
            {
                token = new Token(lValue);
            }

            return (token);
        }

        private Token GetString()
        {
            StringBuilder value = new StringBuilder();

            char character = GetNextChar();

            while (NotEoc() && (character != STRING_INDICATOR))
            {
                value.Append(character);

                character = GetNextChar();
            }

            MoveNextChar();

            return (Token.CreateStringToken(value.ToString()));
        }

        /// <summary>
        /// GetInteger() - Reads the next integer values from the active source
        /// code.  The actual calculaed value of the integer is returned.  The 
        /// first non-digit character will stop the parsing. 
        /// </summary>
        /// <returns></returns>
        private long GetInteger()
        {
            long value = 0;
            char character = PeekChar();

            while (NotEoc() && IsDigit(character))
            {
                value = value * 10 + (character - ZERO_CHAR);

                character = GetNextChar();
            }

            return (value);
        }

        /// <summary>
        /// GetFloat() - Reads the floating point value of a 
        /// </summary>
        /// <param name="whole"></param>
        /// <returns></returns>
        private double GetFloat(long whole)
        {
            double value = whole;
            double factor = 0.1;
            char character = PeekChar();

            while (NotEoc() && (character == ZERO_CHAR))
            {
                factor /= 10.0;

                character = GetNextChar();
            }

            while (NotEoc() && IsDigit(character))
            {
                value = value + factor * (character - ZERO_CHAR);
                factor /= 10.0;

                character = GetNextChar();
            }

            return (value);
        }

        /// <summary>
        /// SkipBlanks() - Skips all blanks
        /// </summary>
        private void SkipBlanks()
        {
            bool skipping = true;

            while(NotEoc() && skipping)
            {
                char character = PeekChar();

                if (IsWhiteSpace(character))
                {
                    MoveNextChar();
                } else
                {
                    skipping = false;
                }
            }
        }

        /// <summary>
        /// IsPeek() - Investigates the active source code character to
        /// determine its value.  If the value is a specific character, the
        /// character is skipped and a true is returned.  If the character
        /// is not specific, this function returns false.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        private bool IsPeek(char character)
        {
            // Check the value of the current active source character
            //-------------------------------------------------------
            bool skip = (character == PeekChar());

            // Skip the charater if it exists
            //-------------------------------
            if (skip)
            {
                MoveNextChar();
            }

            return (skip);
        }

        /// <summary>
        /// PeekChar() - 
        /// </summary>
        /// <returns></returns>
        private char PeekChar()
        {
            char character = (char) 200;

            if (NotEoc())
            {
                character = source.PeekChar();
            }

            return (character);
        }

        /// <summary>
        /// MoveNextChar() - Moves to the next active character but checks to
        /// make sure the EOC has not been reached.  If the EOC is true, the 
        /// pointer is not moved.
        /// </summary>
        private void MoveNextChar()
        {
            if (NotEoc())
            {
                source.MoveNextChar();
            }
        }

        /// <summary>
        /// GetNextChar() - 
        /// </summary>
        /// <returns></returns>
        private char GetNextChar()
        {
            MoveNextChar();

            return (PeekChar());
        }

        private bool IsWhiteSpace(char character) => char.IsWhiteSpace(character);

        private bool IsDigit(char character) => char.IsDigit(character);

        private bool IsLetter(char character) => char.IsLetter(character);

        private bool NotEoc() => !source.Eoc();

    }
}
