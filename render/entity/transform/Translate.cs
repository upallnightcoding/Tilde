using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.render.entity.transform
{
    class Translate
    {
        private float x = 0.0f;
        private float y = 0.0f;
        private float z = 0.0f;

        public void Move(float x, float y, float z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
        }

        public Matrix4 Calculate()
        {
            return (Matrix4.CreateTranslation(x, y, z));
        }
    }
}
