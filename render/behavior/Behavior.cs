using System.Collections.Generic;

namespace Tilde.render.behavior
{
    /// <summary>
    /// Behavior - 
    /// </summary>
    class Behavior
    {
        private Dictionary<string, State> fms = null;

        // Marks the starting state in the FSM
        private State starting = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Behavior()
        {
            fms = new Dictionary<string, State>();
        }

        /// <summary>
        /// Add() - 
        /// </summary>
        /// <param name="state"></param>
        public void Add(State state)
        {
            if (state != null)
            {
                if (starting == null)
                {
                    starting = state;
                }

                fms.Add(state.Name, state);
            }
        }
    }
}
