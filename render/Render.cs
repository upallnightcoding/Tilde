using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilde.render
{
    public interface Render
    {
        void Initialize(int width, int height);

        void Display(Camera camera);
    }
}
