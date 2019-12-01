using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public interface IPaper:IMaterial
    {
        void Paint(Color color);
    }
}
