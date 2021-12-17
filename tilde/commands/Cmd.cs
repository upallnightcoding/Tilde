using Tilde.tilde.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.tilde
{
    abstract class Cmd
    {
        public abstract Node Translate(Parser parser);
        public abstract string GetCommand();

        public Cmd()
        {

        }
    }
}
