using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Factory
{
    public abstract class ExcelDataLayerFactory
    {
        protected DbSqlConnection _connection;

        public ExcelDataLayerFactory(DbSqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public abstract IExcelDataLayer<T> GetExcelDataLayer<T>() where T : class;
    }
}
