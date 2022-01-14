using Tilde.render.scene;

namespace Tilde.render.scene
{
    /// <summary>
    /// Render - 
    /// </summary>
    public interface Render
    {
        /// <summary>
        /// Initialize() - This function is called once before any rendering
        /// begins.  It allows for all initialization of the scene.  It 
        /// provides the width and height to calculate any perspectives.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        void Initialize(int width, int height);

        /// <summary>
        /// Display() - This function is called to display the scene.  It is
        /// called based on the FPS set as the animation speed.
        /// </summary>
        /// <param name="camera"></param>
        void Display(Camera camera);

        /// <summary>
        /// Update() - This function is called to update the entities that
        /// are within the scene.  This function is called based on the setting
        /// of the FPS.
        /// </summary>
        void Update();

        /// <summary>
        /// Set() - This function allows for the changing of a scene.
        /// </summary>
        /// <param name="scene"></param>
        void Set(Scene scene);
    }
}
