using DataLayer.DbDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6;
using Task6.Factory;

namespace DataLayer.Factory
{
    /// <summary>
    /// Class LinqToSqlDataLayerFactory.
    /// Implements the <see cref="Task6.Factory.SqlServerDataLayerFactory" />
    /// </summary>
    /// <seealso cref="Task6.Factory.SqlServerDataLayerFactory" />
    public class LinqToSqlDataLayerFactory : SqlServerDataLayerFactory
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LinqToSqlDataLayerFactory"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        public LinqToSqlDataLayerFactory(DbSqlConnection connection) : base(connection)
        {}

        /// <summary>
        /// Gets the SQL server data layer.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>ISqlServerDataLayer&lt;T&gt;.</returns>
        public override ISqlServerDataLayer<T> GetSqlServerDataLayer<T>()
        {
            return new LinqSqlServerDataLayer<T>(_connection);
        }
    }
}
