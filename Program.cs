using System.Windows.Forms;
using Tilde.tilde;

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
            TestParse();
        }

        static void TestGUI()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static void TestParse()
        {
            SourceCode source = new SourceCode();
            
            source.Add(" program test {");
            source.Add("    print 87, \" \",456, \" \",789.987;");
            source.Add("    {");
            source.Add("        print \"Line 1 \", 987.765 ;");
            source.Add("        print 1, \" \", 2, \" \",3, \" \",4 ;");
            source.Add("    }");
            source.Add("    print 0.098, \" Line 2 \", 987.765 ;");
            source.Add("}");

            TildeScript tilde = new TildeScript(source);

            tilde.Execute();
        }
    }
}
