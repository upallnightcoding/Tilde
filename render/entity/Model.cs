using Tilde.render.entity;
using OpenTK.Graphics.OpenGL4;
using OpenTK;
using Tilde;

namespace Leo.render.entity
{
    class Model
    {
        private Shader shader = null;

        private VAO vao = null;

        private Texture texture1 = null;

        private Texture texture2 = null;

        public void Initialize()
        {
            vao = new VAO();

            shader = new Shader();

            texture1 = new Texture("D:/Projects/c#/OpenTkDemo/images/container.png");
            texture1.Use(TextureUnit.Texture0);

            texture2 = new Texture("D:/Projects/c#/OpenTkDemo/images/awesomeface.png");
            texture2.Use(TextureUnit.Texture1);

            shader.SetInt("texture0", 0);
            shader.SetInt("texture1", 1);
        }

        public void Display(double time, Camera camera, Matrix4 transform)
        {
            vao.Use();

            texture1.Use(TextureUnit.Texture0);
            texture2.Use(TextureUnit.Texture1);

            shader.Use();

            shader.SetMatrix4("model", transform);
            shader.SetMatrix4("view", camera.GetViewMatrix());
            shader.SetMatrix4("projection", camera.GetProjectionMatrix());

            vao.Display();
        }
    }
}
