using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public abstract class SqlServerDataLayerFactory
    {
        protected DbSqlConnection _connection;

        public SqlServerDataLayerFactory(DbSqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public abstract ISqlServerDataLayer<T> GetSqlServerDataLayer<T>() where T : class;

    }
}
