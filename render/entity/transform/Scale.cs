using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.render.entity.transform
{
    /// <summary>
    /// Scale - This class contains the scaling components of and object's 
    /// matrix transform.
    /// </summary>
    class Scale
    {
        // X Scale Attribute
        private float x = 1.0f;

        // Y Scale Attribute
        private float y = 1.0f;

        // Z Scale Attribute
        private float z = 1.0f;

        public void Size(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Calculate() - Calculates the scale matrix component, used when 
        /// calculating an object's transform.
        /// </summary>
        /// <returns></returns>
        public Matrix4 Calculate()
        {
            return (Matrix4.CreateScale(x, y, z));
        }
    }
}
