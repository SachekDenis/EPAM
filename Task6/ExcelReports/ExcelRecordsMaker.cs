using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Factory;

namespace ExcelReports
{
    public class ExcelRecordsMaker
    {
        private readonly ExcelDataLayerFactory _dataLayerFactory;

        public ExcelRecordsMaker(ExcelDataLayerFactory dataLayerFactory)
        {
            _dataLayerFactory = dataLayerFactory ?? throw new ArgumentNullException(nameof(dataLayerFactory));
        }
    }
}
