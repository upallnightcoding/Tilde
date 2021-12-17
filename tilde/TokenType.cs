using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde
{
    public enum TokenType
    {
        // Variable Types
        //---------------
        FLOAT,
        INTEGER,
        STRING,
        BOOLEAN,
        CHARACTER,

        OPERATOR,
        KEYWORD,

        LEFT_PAREN,
        RIGHT_PAREN,
        LEFT_BRACE,
        RIGHT_BRACE,
        FIELD_SEPARATOR,    // Field separator with expressions

        EOS,                // End of Statement token

        EOC,                // End of Code token

        // Token type has not yet been determined
        UNKNOWN
    }
}
