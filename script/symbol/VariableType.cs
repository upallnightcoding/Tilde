using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.script.symbol
{
    enum VariableType
    {
        INTEGER,
        FLOAT,
        STRING,
        CHARACTER,  // TODO : Remove the character type
        BOOLEAN,

        SYMBOL,

        UNKNOWN
    }
}
