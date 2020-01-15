using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public class DataLayerFactory<T> where T:class
    {
        DbSqlConnection _connection;

        public DataLayerFactory(DbSqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public ISqlServerDataLayer<T> GetSqlServerDataLayer()
        {
            return new SqlServerDataLayer<T>(_connection.ConnectionString);
        }

        public IExcelDataLayer<T> GetExcelDataLayer()
        {
            return new ExcelDataLayer<T>(_connection.ConnectionString);
        }
    }
}
