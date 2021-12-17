using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde
{
    class CmdFactory
    {
        public static CmdFactory INSTANCE = new CmdFactory();

        private Dictionary<string, Cmd> commandMap = null;

        private CmdFactory()
        {
            commandMap = new Dictionary<string, Cmd>();

            InstallCmd(new CmdPrint());
        }

        public Cmd GetCommand(Token keyword)
        {
            Cmd cmd = null;

            if (commandMap.TryGetValue(keyword.getKeyword().ToUpper(), out cmd))
            {
                // Do nothing ...
            }

            return (cmd);
        }

        private void InstallCmd(Cmd command)
        {
            commandMap.Add(command.GetCommand(), command);
        }


    }
}
