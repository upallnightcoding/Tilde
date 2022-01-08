using Tilde.render.behavior.action;
using Tilde.render.entity;

namespace Leo.render.behavior.action
{
    class ActionTurn : Action
    {
        private float X { get; set; }

        private float Y { get; set; }

        private float Z { get; set; }

        public ActionTurn(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override void Update(Entity entity)
        {
            entity.Turn(X, Y, Z);
        }
    }
}
