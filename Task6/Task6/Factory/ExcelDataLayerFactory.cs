using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Connections;

namespace Task6.Factory
{
    public abstract class ExcelDataLayerFactory
    {
        protected ExcelConnection _connection;

        public ExcelDataLayerFactory(ExcelConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public abstract IExcelDataLayer<T> GetExcelDataLayer<T>() where T : class;

        public void SetFilePath(string path)
        {
            _connection.SetFilePath(path);
        }
    }
}
