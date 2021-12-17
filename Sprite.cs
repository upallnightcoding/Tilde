using OpenTK.Graphics.OpenGL4;

namespace Tilde.entity
{
    class Sprite : Entity
    {
        private string TEST_IMAGE = 
            "D:/Projects/c#/OpenTkDemo/images/container.png";

        protected override Texture CreateEntityTexture()
        {
            return (new Texture(TEST_IMAGE));
        }
    }
}
