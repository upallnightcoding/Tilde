using OpenTK.Graphics.OpenGL4;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilde;
using Tilde.render.scene;

namespace Leo.render.scene
{
    class MainLoop
    {
        private static double FPS_RATE = 60.0d;

        private double updateRateInSecs = 1.0d / FPS_RATE;

        private Camera camera = null;

        private bool firstTime = true;

        private Render render = new Render2DScene();

        //private long lastTime;

        private Scene scene = null;

        private double accumulatorSec = 0;
        private long currentTimeMs;
        private long lastUpdateMs;
        private long nextStatTime;

        int fps = 0;
        int ups = 0;

        public MainLoop()
        {
            Scene scene = TestCase.Case04();

            Set(scene);

            var kb = OpenTK.Input.Keyboard.GetState();
        }

        private long GetSystemMs() => DateTimeOffset.Now.ToUnixTimeMilliseconds();

        public void Set(Scene scene)
        {
            if (scene != null)
            {
                this.scene = scene;
            }
        }

        public void Setup()
        {
            //lastTime = GetSystemMs();

            accumulatorSec = 0;
            currentTimeMs = GetSystemMs();
            lastUpdateMs = currentTimeMs;
        }

        public void ReSize(int Width, int Height)
        {
            GL.Viewport(0, 0, Width, Height);

            if (camera != null)
            {
                camera.AspectRatio = (float)Width / (float)Height;
            }
        }

        public void Display(int Width, int Height)
        {
            if (firstTime)
            {
                firstTime = false;
                camera = new Camera(Vector3.UnitZ * 1, Width / (float)Height);
                render.Initialize(Width, Height);

                render.Set(scene);

                scene.Initialize();

                nextStatTime = GetSystemMs() + 1000;
            }

            currentTimeMs = GetSystemMs();
            double lastRenderTimeInSecs = (currentTimeMs - lastUpdateMs) / 1000d;
            accumulatorSec += lastRenderTimeInSecs;
            lastUpdateMs = currentTimeMs;

            while (accumulatorSec > updateRateInSecs)
            {
                render.Update();
                ups++;
                accumulatorSec -= updateRateInSecs;
            }

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            render.Display(camera);

            fps++;

            PrintStats();
        }

        private void PrintStats()
        {
            long nowTime = GetSystemMs();

            if (nowTime > nextStatTime)
            {
                string msg = string.Format("FPS/UPS: {0}/{1}", fps, ups);
                Console.WriteLine(msg);
                nextStatTime = GetSystemMs() + 1000;
                fps = 0;
                ups = 0;
            }
        }
    }
}
