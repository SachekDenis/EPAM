using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Connections;

namespace Task6.Factory
{
    /// <summary>
    /// Class AdoExcelDataLayerFactory.
    /// Implements the <see cref="Task6.Factory.ExcelDataLayerFactory" />
    /// </summary>
    /// <seealso cref="Task6.Factory.ExcelDataLayerFactory" />
    public class AdoExcelDataLayerFactory : ExcelDataLayerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdoExcelDataLayerFactory"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public AdoExcelDataLayerFactory(ExcelConnection connection) : base(connection)
        {}

        /// <summary>
        /// Gets the excel data layer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IExcelDataLayer&lt;T&gt;.</returns>
        public override IExcelDataLayer<T> GetExcelDataLayer<T>()
        {
            return new ExcelDataLayer<T>(_connection);
        }
    }
}
