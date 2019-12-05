using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIo
{
    interface IDataIo
    {
        void WriteFile(List<IShape> data, string file);
        List<IShape> ReadFile();
    }
}
