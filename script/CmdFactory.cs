using Leo.script.commands;
using Leo.script.commands.declare;
using System.Collections.Generic;

namespace Tilde.script
{
    class CmdFactory
    {
        public static CmdFactory INSTANCE = new CmdFactory();

        private Dictionary<string, Cmd> commandMap = null;

        private CmdFactory()
        {
            commandMap = new Dictionary<string, Cmd>();

            InstallCmd();
        }

        public Cmd GetCommand(Token keyword)
        {
            Cmd cmd = null;

            if (commandMap.TryGetValue(keyword.GetKeyword().ToUpper(), out cmd))
            {
                // Do nothing ...
            }

            return (cmd);
        }

        private void InstallCmd()
        {
            InstallCmd(new CmdPrint());
            InstallCmd(new CmdInteger());
            InstallCmd(new CmdBoolean());
            InstallCmd(new CmdCharacter());
            InstallCmd(new CmdFloat());
            InstallCmd(new CmdString());
        }

        private void InstallCmd(Cmd command)
        {
            commandMap.Add(command.GetCommand(), command);
        }


    }
}
