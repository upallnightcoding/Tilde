using Tilde.render.scene;
using OpenTK.Graphics.OpenGL4;
using System.Collections.Generic;
using Tilde.render.entity;

namespace Tilde.render.scene
{
    class Render2DScene : Render
    {
        private double time = 0.0f;

        private Scene scene = null;

        /************************/
        /*** Public Functions ***/
        /************************/

        /// <summary>
        /// Set() - Sets the scene to be rendered.  If the scene is null it is
        /// not used.
        /// </summary>
        /// <param name="scene"></param>
        public void Set(Scene scene)
        {
            if (scene != null)
            {
                this.scene = scene;
            }
        }

        /// <summary>
        /// Update() - Allows for the entities within a scene to be updated.  
        /// The entities can only be updated if action have been applied to
        /// the entity.
        /// </summary>
        public void Update()
        {
            scene.Update();     // Apply all updates to the scene
        }

        /// <summary>
        /// Display() - 
        /// </summary>
        /// <param name="camera"></param>
        public void Display(Camera camera)
        {
            time += 0.0001;

            scene.Display(time, camera);
        }

        /// <summary>
        /// Initialize() - 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void Initialize(int width, int height)
        {
            GL.Enable(EnableCap.DepthTest);

            GL.ClearColor(0.4f, 0.3f, 0.6f, 1.0f);
        }
    }
}
