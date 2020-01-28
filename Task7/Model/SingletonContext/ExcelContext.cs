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
    /// <summary>
    /// Class ExcelContext.
    /// </summary>
    public class ExcelContext
    {
        /// <summary>
        /// The excel data layer factory
        /// </summary>
        private readonly ExcelDataLayerFactory _excelDataLayerFactory;

        /// <summary>
        /// The exam results data layer
        /// </summary>
        private IExcelDataLayer<ExamResults> _examResultsDataLayer;
        /// <summary>
        /// The credit results data layer
        /// </summary>
        private IExcelDataLayer<CreditResults> _creditResultsDataLayer;
        /// <summary>
        /// The statistic results data layer
        /// </summary>
        private IExcelDataLayer<StatisticResults> _statisticResultsDataLayer;
        /// <summary>
        /// The expell results data layer
        /// </summary>
        private IExcelDataLayer<ExpellResults> _expellResultsDataLayer;
        /// <summary>
        /// The statistic on specialty data layer
        /// </summary>
        private IExcelDataLayer<StatisticOnSpecialty> _statisticOnSpecialtyDataLayer;

        /// <summary>
        /// The statistic on examiner data layer
        /// </summary>
        private IExcelDataLayer<StatisticOnExaminer> _statisticOnExaminerDataLayer;

        /// <summary>
        /// The statistic by yesr data layer
        /// </summary>
        private IExcelDataLayer<StatisticByYear> _statisticByYesrDataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelContext" /> class.
        /// </summary>
        /// <param name="sqlServerDataLayerFactory">The SQL server data layer factory.</param>
        /// <exception cref="ArgumentNullException">sqlServerDataLayerFactory</exception>
        public ExcelContext(ExcelDataLayerFactory sqlServerDataLayerFactory)
        {
            _excelDataLayerFactory = sqlServerDataLayerFactory ?? throw new ArgumentNullException(nameof(sqlServerDataLayerFactory));
        }

        /// <summary>
        /// Gets the exam results data layer.
        /// </summary>
        /// <returns>IExcelDataLayer&lt;ExamResults&gt;.</returns>
        public IExcelDataLayer<ExamResults> GetExamResultsDataLayer()
        {
            return CreateInstance(ref _examResultsDataLayer);
        }

        /// <summary>
        /// Gets the credit results data layer.
        /// </summary>
        /// <returns>IExcelDataLayer&lt;CreditResults&gt;.</returns>
        public IExcelDataLayer<CreditResults> GetCreditResultsDataLayer()
        {
            return CreateInstance(ref _creditResultsDataLayer);
        }

        /// <summary>
        /// Gets the statistic results data layer.
        /// </summary>
        /// <returns>IExcelDataLayer&lt;StatisticResults&gt;.</returns>
        public IExcelDataLayer<StatisticResults> GetStatisticResultsDataLayer()
        {
            return CreateInstance(ref _statisticResultsDataLayer);
        }

        /// <summary>
        /// Gets the statistic results data layer.
        /// </summary>
        /// <returns>IExcelDataLayer&lt;StatisticResults&gt;.</returns>
        public IExcelDataLayer<StatisticOnSpecialty> GetStatisticOnSpecialtyResultsDataLayer()
        {
            return CreateInstance(ref _statisticOnSpecialtyDataLayer);
        }

        /// <summary>
        /// Gets the expell results data layer.
        /// </summary>
        /// <returns>IExcelDataLayer&lt;ExpellResults&gt;.</returns>
        public IExcelDataLayer<ExpellResults> GetExpellResultsDataLayer()
        {
            return CreateInstance(ref _expellResultsDataLayer);
        }

        /// <summary>
        /// Gets the statistic on examiner data layer.
        /// </summary>
        /// <returns>IExcelDataLayer&lt;StatisticOnExaminer&gt;.</returns>
        public IExcelDataLayer<StatisticOnExaminer> GetStatisticOnExaminerDataLayer()
        {
            return CreateInstance(ref _statisticOnExaminerDataLayer);
        }

        /// <summary>
        /// Gets the statistic by year data layer.
        /// </summary>
        /// <returns>IExcelDataLayer&lt;StatisticByYear&gt;.</returns>
        public IExcelDataLayer<StatisticByYear> GetStatisticByYearDataLayer()
        {
            return CreateInstance(ref _statisticByYesrDataLayer);
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataLayer">The data layer.</param>
        /// <returns>IExcelDataLayer&lt;T&gt;.</returns>
        private IExcelDataLayer<T> CreateInstance<T>(ref IExcelDataLayer<T> dataLayer) where T : class
        {
            if (dataLayer == null)
            {
                dataLayer = _excelDataLayerFactory.GetExcelDataLayer<T>();
            }
            return dataLayer;
        }

        /// <summary>
        /// Sets the file path.
        /// </summary>
        /// <param name="path">The path.</param>
        public void SetFilePath(string path)
        {
            _excelDataLayerFactory.SetFilePath(path);
        }
    }
}
