using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Factory
{
    /// <summary>
    /// Class SqlServerDataLayerFactory.
    /// </summary>
    public abstract class SqlServerDataLayerFactory
    {
        /// <summary>
        /// The connection
        /// </summary>
        protected DbSqlConnection _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDataLayerFactory"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <exception cref="ArgumentNullException">connection</exception>
        public SqlServerDataLayerFactory(DbSqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        /// <summary>
        /// Gets the SQL server data layer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>ISqlServerDataLayer&lt;T&gt;.</returns>
        public abstract ISqlServerDataLayer<T> GetSqlServerDataLayer<T>() where T : class;

    }
}
