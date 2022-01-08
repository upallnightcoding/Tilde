using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.render.entity.transform
{
    /// <summary>
    /// Translate - This class contains the translation components of an object's
    /// matrix transform.
    /// </summary>
    class Translate
    {
        // X Translate Attribute
        private float x = 0.0f;

        // Y Translate Attribute
        private float y = 0.0f;

        // Z Translate Attribute
        private float z = 0.0f;

        /// <summary>
        /// Move() - Translate the position of an object by off setting its
        /// x, y, z components.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Move(float x, float y, float z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
        }

        /// <summary>
        /// Calculate() - Calculates the translate matrix component, used when
        /// calculating an object's transform.
        /// </summary>
        /// <returns></returns>
        public Matrix4 Calculate()
        {
            return (Matrix4.CreateTranslation(x, y, z));
        }
    }
}
