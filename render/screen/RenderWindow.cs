
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using System.Windows.Forms;
using System;
using Tilde.render;

namespace Tilde.render.screen
{
    class RenderWindow : OpenTK.GLControl
    {
        private Camera camera = null;

        private bool firstTime = true;

        private Render render = new Render2DScene();

        public void Setup()
        {
            Resize += new EventHandler(GlControl_Resize);
            Paint += new PaintEventHandler(GlControl_Paint);

            Application.Idle += Application_Idle;

            VSync = false;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            while (IsIdle)
            {
                Display();
            }
        }

        private void GlControl_Resize(object sender, EventArgs e)
        {
            OpenTK.GLControl glControl = sender as OpenTK.GLControl;

            if (glControl.ClientSize.Height == 0)
            {
                glControl.ClientSize = new System.Drawing.Size(glControl.ClientSize.Width, 1);
            }

            float aspectRatio = (float)Width / (float)Height;

            GL.Viewport(0, 0, glControl.ClientSize.Width, glControl.ClientSize.Height);

            if (camera != null)
            {
                camera.AspectRatio = aspectRatio;
            }
        }

        private void GlControl_Paint(object sender, PaintEventArgs e)
        {
            Display();
        }

        private void Display()
        {
            if (firstTime)
            {
                firstTime = false;
                camera = new Camera(Vector3.UnitZ * 1, Size.Width / (float)Size.Height);
                render.Initialize(Size.Width, Size.Height);
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            render.Display(camera);

            SwapBuffers();
        }
    }
}
