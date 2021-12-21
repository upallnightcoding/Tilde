using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.script
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

        OPER_STACK_MARKER,          // Used to mark the end of the expression operator stack
        BEGIN_EXP_MARKER,

        EOE,
        MULTIPLY,
        DIVIDE,
        SUBTRACT,
        ADD,

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
