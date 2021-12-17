using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Tilde.render
{
    class Render2DScene : Render
    {
        //private readonly float[] _vertices =
        //{
        //    // Position         Texture coordinates
        //     0.5f,  0.5f, 0.0f, 1.0f, 1.0f, // top right
        //     0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // bottom right
        //    -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // bottom left
        //    -0.5f,  0.5f, 0.0f, 0.0f, 1.0f  // top left
        //};

        //private readonly uint[] _indices =
        //{
        //    0, 1, 3,
        //    1, 2, 3
        //};

        //private int _elementBufferObject;

        //private int _vertexBufferObject;

        //private int _vertexArrayObject;

        private Shader shader;

        private Texture _texture1;

        private Texture _texture2;

        private VAO vao = null;
        private double time = 0.0f;

        public void Display(Camera camera)
        {
            //time += 50.0 * e.Time;

            vao.Use();

            _texture1.Use(TextureUnit.Texture0);
            _texture2.Use(TextureUnit.Texture1);
            shader.Use();

            var model = Matrix4.Identity * Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(time+=0.1));
            shader.SetMatrix4("model", model);
            shader.SetMatrix4("view", camera.GetViewMatrix());
            shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            vao.Display();
        }

        public void Initialize(int width, int height)
        {
            GL.Enable(EnableCap.DepthTest);

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);


            vao = new VAO();

            shader = new Shader();
            shader.Use();

            _texture1 = new Texture("D:/Projects/c#/OpenTkDemo/images/container.png");
            _texture1.Use(TextureUnit.Texture0);

            _texture2 = new Texture("D:/Projects/c#/OpenTkDemo/images/awesomeface.png");
            _texture2.Use(TextureUnit.Texture1);

            shader.SetInt("texture0", 0);
            shader.SetInt("texture1", 1);

            //camera = new Camera(Vector3.UnitZ * 1, width / (float)height);

            // We make the mouse cursor invisible and captured so we can have proper FPS-camera movement.
            //CursorGrabbed = false;
        }
    }
}
