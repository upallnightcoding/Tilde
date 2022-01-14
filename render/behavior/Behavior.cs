using System.Collections.Generic;
using Tilde.render.behavior.action;
using Tilde.render.entity;

namespace Leo.render.behavior
{
    class Behavior
    {
        private List<Action> actionList = null;

        public Behavior()
        {
            actionList = new List<Action>();
        }

        public void Add(Action action)
        {
            if (action != null)
            {
                actionList.Add(action);
            }
        }

        public void Update(Entity entity)
        {
            foreach (Action action in actionList)
            {
                action.Update(entity);
            }
        }
    }
}
