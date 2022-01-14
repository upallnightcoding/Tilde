using System.Windows.Forms;
using System;
using Leo.render.scene;

namespace Tilde.render.scene
{
    class RenderWindow : OpenTK.GLControl
    {
        private MainLoop mainLoop = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public RenderWindow()
        {
            mainLoop = new MainLoop();

            Resize += new EventHandler(GlControlResize);
            Paint += new PaintEventHandler(GlControlPaint);

            Application.Idle += ApplicationIdle;

            VSync = false;

            mainLoop.Setup();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// ApplicationIdle() - 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void ApplicationIdle(object sender, EventArgs eventArgs)
        {
            while (IsIdle)
            {
                Display();
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

        /// <summary>
        /// GlControlResize() - Is called in the event of a screen resize.
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

            mainLoop.ReSize(Width, Height);
        }

        /// <summary>
        /// Display() - Represents a frame display.  Each time the screen is 
        /// determined to be idle or a resize is done to the screen this 
        /// function is called for the resize or idle event.  A SwapBuffer
        /// is done at the end of the display to allow for double buffering
        /// animation.  If OpenGl is configured as single buffer, this swap
        /// has no effect.  The Width and Height are passed are the current
        /// size of the control.
        /// </summary>
        private void Display()
        {
            mainLoop.Display(Width, Height);

            SwapBuffers();
        }
    }
}
