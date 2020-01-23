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
        private IExcelDataLayer<ExpellResults> _expellResultsDataLayer;

        public ExcelContext(ExcelDataLayerFactory sqlServerDataLayerFactory)
        {
            _excelDataLayerFactory = sqlServerDataLayerFactory ?? throw new ArgumentNullException(nameof(sqlServerDataLayerFactory));
        }

        public IExcelDataLayer<ExamResults> GetExamResultsDataLayer()
        {
            return CreateInstance(ref _examResultsDataLayer);
        }

        public IExcelDataLayer<CreditResults> GetCreditResultsDataLayer()
        {
            return CreateInstance(ref _creditResultsDataLayer);
        }

        public IExcelDataLayer<StatisticResults> GetStatisticResultsDataLayer()
        {
            return CreateInstance(ref _statisticResultsDataLayer);
        }

        public IExcelDataLayer<ExpellResults> GetExpellResultsDataLayer()
        {
            return CreateInstance(ref _expellResultsDataLayer);
        }

        private IExcelDataLayer<T> CreateInstance<T>(ref IExcelDataLayer<T> dataLayer) where T : class
        {
            if (dataLayer == null)
            {
                dataLayer = _excelDataLayerFactory.GetExcelDataLayer<T>();
            }
            return dataLayer;
        }

        public void SetFilePath(string path)
        {
            _excelDataLayerFactory.SetFilePath(path);
        }
    }
}
