using OpenTK;

namespace Leo.render.entity.transform
{
    /// <summary>
    /// Rotate - 
    /// </summary>
    class Rotate
    {
        private float x = 0.0f;
        private float y = 0.0f;
        private float z = 0.0f;

        /// <summary>
        /// Set() - 
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
        /// Calculate() - 
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
