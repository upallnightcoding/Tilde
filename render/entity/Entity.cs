using Leo.render.entity;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using Tilde.render.entity.transform;

namespace Tilde.render.entity
{
    public abstract class Entity
    {
        private Model model = null;

        private Transform transform = null;

        // Abstract Functions
        //-------------------
        protected abstract string CreateEntityTexture();

        public Entity()
        {
            model = new Model();

            transform = new Transform();
        }

        public void Initialize()
        {
            model.Initialize();
        }

        public void Display(double time, Camera camera)
        {
            transform.Move((float)time * 0.0001f, 0.0f, 0.0f);

            var t = transform.Calculate();

            model.Display(time, camera, t);
        }
    }
}
