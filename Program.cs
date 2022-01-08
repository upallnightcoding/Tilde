using Tilde;
using System.Windows.Forms;
using Tilde.script;

namespace Tilde
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        static void Main()
        {
            TestGUI();
        }

        static void TestGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void TestParse()
        {
            SourceCode source = TestCase.Case02();

            //source.Add("program test {");
            //source.Add("    integer a, b, c , x, y, z;");
            //source.Add("    float n, m;");
            //source.Add("    print (a + (6 + b)), \" \", 87.001 + 50.56 ;");
            //source.Add("    print (32 - (6 - 3)), \" \", 87.001 - 50.56 ;");
            //source.Add("    print (32 * (6 * 3)), \" \", 87.001 * 50.56 ;");
            //source.Add("    {");
            //source.Add("        print \"Line 1 \", 987.765 ;");
            //source.Add("        print 1, \" \", 2, \" \",3, \" \",4 ;");
            //source.Add("    }");
            //source.Add("    print 0.098, \" Line 2 \", 987.765 ;");
            //source.Add("}");

            TildeScript tilde = new TildeScript(source);

            tilde.Execute();
        }
    }
}
