using Tilde.script.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.script.nodes;
using Tilde.script.parser;

namespace Tilde.script
{
    abstract class Cmd
    {
        private string command = null;

        public abstract Node Translate(Parser parser);

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Cmd(string command)
        {
            this.command = command;
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public string GetCommand()
        {
            return (command);
        }
    }
}
