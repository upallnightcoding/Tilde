
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using System.Windows.Forms;
using System;
using Tilde.render;
using Tilde.render.entity;
using Tilde.render.behavior.action;
using Leo.render.behavior.action;

namespace Tilde.render.scene
{
    class RenderWindow : OpenTK.GLControl
    {
        private Camera camera = null;

        private bool firstTime = true;

        private Render render = new Render2DScene();

        private long lastTime;

        private Scene scene = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public RenderWindow()
        {
            Sprite s1 = new Sprite();
            s1.Add(new ActionMove(0.00005f, 0.0f, 0.0f));
            s1.Add(new ActionTurn(0.0f, 0.0f, 0.01f));

            Sprite s2 = new Sprite();
            s2.Add(new ActionMove(-0.00005f, 0.0f, 0.0f));

            Scene scene = new Scene();
            scene.Add(s1);
            scene.Add(s2);

            Set(scene);
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Set(Scene scene)
        {
            if (scene != null)
            {
                this.scene = scene;
            }
        }

        public void Setup()
        {
            Resize += new EventHandler(GlControlResize);
            Paint += new PaintEventHandler(GlControlPaint);

            Application.Idle += ApplicationIdle;

            VSync = false;

            lastTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        private void ApplicationIdle(object sender, EventArgs eventArgs)
        {
            while (IsIdle)
            {
                Display();
            }
        }

        /// <summary>
        /// GlControlResize() - 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void GlControlResize(object sender, EventArgs eventArgs)
        {
            if (Height == 0)
            {
                OpenTK.GLControl glControl = sender as OpenTK.GLControl;

                glControl.ClientSize = new System.Drawing.Size(glControl.ClientSize.Width, 1);
            }

            GL.Viewport(0, 0, Width, Height);
            
            if (camera != null)
            {
                camera.AspectRatio = (float)Width / (float)Height;
            }
        }

        /// <summary>
        /// GlControlPaint() - 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GlControlPaint(object sender, PaintEventArgs e)
        {
            Display();
        }

        private void Display()
        {
            long current = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("Time: " + (current - lastTime));

            System.Threading.Thread.Sleep(1);  // Force some time to elaspe

            if (firstTime)
            {
                firstTime = false;
                camera = new Camera(Vector3.UnitZ * 1, Size.Width / (float)Size.Height);
                render.Initialize(Size.Width, Size.Height);

                render.Set(scene);

                scene.Initialize();
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            render.Update();

            render.Display(camera);

            SwapBuffers();

            lastTime = current;
        }
    }
}
