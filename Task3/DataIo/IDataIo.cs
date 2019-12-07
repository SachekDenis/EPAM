using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIo
{
    public interface IDataIo
    {
        void WriteFile(IEnumerable<IShape> data, string file);
        List<IShape> ReadFile(string file);
    }
}
