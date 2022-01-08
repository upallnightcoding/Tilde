using OpenTK;

namespace Tilde.render.entity.transform
{
    /// <summary>
    /// Rotate - This class contains the rotation component of an object's 
    /// matrix transform.
    /// </summary>
    class Rotate
    {
        // X Rotate Attribute
        private float x = 0.0f;

        // Y Rotate Attribute
        private float y = 0.0f;

        // Z Rotate Attribute
        private float z = 0.0f;

        /// <summary>
        /// Set() - Sets the x, y, z - attributes of an objects rotation
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Set(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Turn() - Adds or substracts from the rotation components to turn
        /// the object on any axis.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Turn(float x, float y, float z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
        }

        /// <summary>
        /// Calculate() - Calculates the rotate matrix component, used when
        /// calculating an objects transform.
        /// </summary>
        /// <returns></returns>
        public Matrix4 Calculate()
        {
            Matrix4 rotate =
                Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(x)) *
                Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(y)) *
                Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(z));

            return (rotate);
        }
    }
}
