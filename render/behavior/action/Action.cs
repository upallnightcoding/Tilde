using Tilde.render.entity;

namespace Tilde.render.behavior.action
{
    public abstract class Action
    {
        protected string Name { get; set; } = null;

        public abstract void Update(Entity entity);
    }
}
