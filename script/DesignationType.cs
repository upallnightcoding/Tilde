using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.script
{
    enum DesignationType
    {
        VARIABLE,   // User defined scalar variable
        ARRAY,      // User defined multi-dimensional array
        CONSTANT,   // User defined constant example: 123, 3.145 ...

        UNKNOWN
    }
}
