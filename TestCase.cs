using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde;

namespace Leo
{
    class TestCase
    {
        public static SourceCode Case01()
        {
            SourceCode source = new SourceCode();

            source.Add("program test {");
            source.Add("    print (1 + 2.2), \" \", (11 * 23.32) ;");
            source.Add("}");

            return (source);
        }

        public static SourceCode Case02()
        {
            SourceCode source = new SourceCode();

            source.Add("program test {");
            source.Add("    integer a = (1 + 2.2), b = 2.67, c = 3.01;");
            source.Add("    float x = (1 + 2.2), y = 2.67, z = 3.01;");
            source.Add("    print a, \" \", b, \" \", c ;");
            source.Add("    print x, \" \", y, \" \", z ;");
            source.Add("}");

            return (source);
        }
    }
}
