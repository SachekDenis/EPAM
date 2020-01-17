using Model.ExcelReportsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6;
using Task6.Factory;

namespace Model.SingletonContext
{
    public class ExcelContext
    {
        private readonly ExcelDataLayerFactory _excelDataLayerFactory;

        private IExcelDataLayer<ExamResults> _examResultsDataLayer;
        private IExcelDataLayer<CreditResults> _creditResultsDataLayer;
        private IExcelDataLayer<StatisticResults> _statisticResultsDataLayer;

        public ExcelContext(ExcelDataLayerFactory sqlServerDataLayerFactory)
        {
            _excelDataLayerFactory = sqlServerDataLayerFactory ?? throw new ArgumentNullException(nameof(sqlServerDataLayerFactory));
        }

        public IExcelDataLayer<ExamResults> GetExamResultsDataLayer()
        {
            return CreateInstance(_examResultsDataLayer);
        }

        public IExcelDataLayer<CreditResults> GetCreditResultsDataLayer()
        {
            return CreateInstance(_creditResultsDataLayer);
        }

        public IExcelDataLayer<StatisticResults> GetStatisticResultsDataLayer()
        {
            return CreateInstance(_statisticResultsDataLayer);
        }

        private IExcelDataLayer<T> CreateInstance<T>(IExcelDataLayer<T> dataLayer) where T : class
        {
            if (dataLayer == null)
            {
                dataLayer = _excelDataLayerFactory.GetExcelDataLayer<T>();
            }
            return dataLayer;
        }
    }
}
