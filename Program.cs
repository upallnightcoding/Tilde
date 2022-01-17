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
            SourceCode source = TestCase.ArrayTest();

            TildeScript tilde = new TildeScript(source);

            tilde.Execute();
        }
    }
}
