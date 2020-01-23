using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Connections
{
    /// <summary>
    /// Class ExcelConnection.
    /// </summary>
    public class ExcelConnection
    {
        /// <summary>
        /// The path
        /// </summary>
        private string _path;
        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetFilePath(string path)
        {
            _path = path;
        }
        /// <summary>
        /// Gets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString
        {
            get
            {
                return $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={_path};Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"";
            }
        }
    }
}
