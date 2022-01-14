using Leo.render.behavior;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde.render.behavior.action;
using Tilde.render.entity;

namespace Tilde.render.behavior
{
    public class State
    {
        // Name of the state
        public string Name { get; set; } = null;

        // Determines the behavior of a state
        private Behavior behavior = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public State(string name)
        {
            Name = name;

            this.behavior = new Behavior(); 
        }

        public void Add(Action action)
        {
            if (action != null)
            {
                behavior.Add(action);
            }
        }

        public void Update(Entity entity)
        {
            behavior.Update(entity);
        }
    }
}
