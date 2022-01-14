using System.Collections.Generic;
using Tilde.render.behavior.action;
using Tilde.render.entity;

namespace Tilde.render.behavior
{
    /// <summary>
    /// FSM - 
    /// </summary>
    public class FSM
    {
        // Dictionary of all states in the FSM
        private Dictionary<string, State> fms = null;

        // Marks the state that is currently active
        private State activeState = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public FSM()
        {
            fms = new Dictionary<string, State>();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Add() - 
        /// </summary>
        /// <param name="state"></param>
        public void Add(State state)
        {
            if (state != null)
            {
                if (activeState == null)
                {
                    activeState = state;
                }

                fms.Add(state.Name, state);
            }
        }

        /// <summary>
        /// Add() - Adds an action to the currently active state.  If the 
        /// action is null it is not added to the active state.
        /// </summary>
        /// <param name="action"></param>
        public void Add(Action action)
        {
            if (action != null)
            {
                activeState.Add(action);
            }
        }

        public void Update(Entity entity)
        {
            activeState.Update(entity);
        }
    }
}
