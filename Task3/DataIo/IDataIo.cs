using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataIo
{
    /// <summary>
    /// Interface IDataIo
    /// </summary>
    public interface IDataIo
    {
        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="file">The file.</param>
        void WriteFile(IEnumerable<IShape> data, string file);
        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>List&lt;IShape&gt;.</returns>
        List<IShape> ReadFile(string file);
    }
}
