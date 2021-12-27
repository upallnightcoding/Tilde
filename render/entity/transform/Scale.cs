using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.render.entity.transform
{
    class Scale
    {
        private float x = 1.0f;
        private float y = 1.0f;
        private float z = 1.0f;

        public Matrix4 Calculate()
        {
            return (Matrix4.CreateScale(x, y, z));
        }
    }
}
