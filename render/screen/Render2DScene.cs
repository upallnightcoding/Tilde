using OpenTK.Graphics.OpenGL4;
using Tilde.render.entity;

namespace Tilde.render.screen
{
    class Render2DScene : Render
    {
        private Sprite sprite = null;

        private double time = 0.0f;

        public void Display(Camera camera)
        {
            time += 0.0001;

            sprite.Display(time, camera);
        }

        public void Initialize(int width, int height)
        {
            GL.Enable(EnableCap.DepthTest);

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            sprite = new Sprite();
            sprite.Initialize();
        }
    }
}
