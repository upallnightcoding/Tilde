using Tilde.render.entity;

namespace Tilde.render.behavior.action
{
    class ActionMove : Action
    {
        private float X { get; set; }

        private float Y { get; set; }

        private float Z { get; set; }

        public ActionMove(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override void Update(Entity entity)
        {
            entity.Move(X, Y, Z);
        }
    }
}
