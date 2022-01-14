using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.render.behavior.stateevent;

namespace Leo.render.behavior.stateevent
{
    class StateEventTimer : StateEvent
    {
        private readonly double waitTimeSec = 0.0d;

        private readonly string nextState = null;

        private double startTimeMs = 0.0d;

        public StateEventTimer(double waitTimeSec, string nextState)
        {
            this.waitTimeSec = waitTimeSec;
            this.nextState = nextState;
        }

        public string NextState()
        {
            return (nextState);
        }

        public bool OnEvent()
        {
            double elapseSec = (DateTimeOffset.Now.ToUnixTimeMilliseconds() - startTimeMs) / 1000;

            return (elapseSec > waitTimeSec);
        }

        public void StartEvent()
        {
            startTimeMs = DateTimeOffset.Now.ToUnixTimeMilliseconds(); 
        }
    }
}
