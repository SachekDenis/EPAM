using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Connections;

namespace Task6.Factory
{
    /// <summary>
    /// Class ExcelDataLayerFactory.
    /// </summary>
    public abstract class ExcelDataLayerFactory
    {
        /// <summary>
        /// The connection
        /// </summary>
        protected ExcelConnection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelDataLayerFactory"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <exception cref="ArgumentNullException">connection</exception>
        public ExcelDataLayerFactory(ExcelConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        /// <summary>
        /// Gets the excel data layer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IExcelDataLayer&lt;T&gt;.</returns>
        public abstract IExcelDataLayer<T> GetExcelDataLayer<T>() where T : class;

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetFilePath(string path)
        {
            _connection.SetFilePath(path);
        }
    }
}
