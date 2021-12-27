using OpenTK.Graphics.OpenGL4;
using Tilde.render.entity;

namespace Tilde.render.entity
{
    class Sprite : Entity
    {
        private string TEST_IMAGE = 
            "D:/Projects/c#/OpenTkDemo/images/container.png";

        protected override string CreateEntityTexture()
        {
            return (TEST_IMAGE);
        }
    }
}
