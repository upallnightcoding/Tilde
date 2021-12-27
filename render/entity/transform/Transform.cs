using Leo.render.entity.transform;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.render.entity.transform
{
    class Transform
    {
        private Translate translate = null;
        private Scale scale = null;
        private Rotate rotate = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Transform()
        {
            translate = new Translate();
            scale = new Scale();
            rotate = new Rotate();
        }

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Move(float x, float y, float z)
        {
            translate.Move(x, y, z);
        }

        public Matrix4 Calculate()
        {
            var transform =
                Matrix4.Identity *
                rotate.Calculate() *
                translate.Calculate() *
                scale.Calculate();

            return (transform);
        }
    }
}
