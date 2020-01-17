using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Factory;

namespace Task6
{
    public class AdoSqlServerDataLayerFactory : SqlServerDataLayerFactory
    {
        public AdoSqlServerDataLayerFactory(DbSqlConnection connection) : base(connection)
        {
        }

        public override ISqlServerDataLayer<T> GetSqlServerDataLayer<T>()
        {
            return new SqlServerDataLayer<T>(_connection.ConnectionString);
        }
    }
}
