using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.render.behavior.stateevent
{
    interface StateEvent
    {
        void StartEvent();

        bool OnEvent();

        string NextState();
    }
}
