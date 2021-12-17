using OpenTK.Graphics.OpenGL4;

namespace Tilde
{
    public abstract class Entity
    {
        protected Shader shader = null;

        protected Texture texture = null;

        protected VAO vao = null;

        // Abstract Functions
        //-------------------
        protected abstract Texture CreateEntityTexture();

        public void Initialize()
        {
            vao = new VAO();

            shader = new Shader();

            texture = CreateEntityTexture();
        }

        public void Display()
        {
            vao.Use();

            texture.Use(TextureUnit.Texture0);

            shader.Use();

            vao.Display();
        }

       
    }
}
