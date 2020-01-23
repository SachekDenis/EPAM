using System;
using System.Collections.Generic;
using System.IO;
using ExcelReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.ExcelReportsModels;
using Model.SingletonContext;
using Task6;
using Task6.Connections;
using Task6.Factory;

namespace DataLayerTest
{
    [TestClass]
    public class ExcelReportsTest
    {
        DbContext _dbContext;
        ExcelContext _excelContext;

        public ExcelReportsTest()
        {
            DbSqlConnection connection = new DbSqlConnection();
            ExcelConnection excelConnection = new ExcelConnection();
            AdoSqlServerDataLayerFactory factory = new AdoSqlServerDataLayerFactory(connection);
            AdoExcelDataLayerFactory excelFactory = new AdoExcelDataLayerFactory(excelConnection);
            _dbContext = new DbContext(factory);
            _excelContext = new ExcelContext(excelFactory);
        }

        [TestMethod]
        [DataRow("ExamsReport.xlsx")]
        public void SessionExamsReportTest(string path)
        {
            ExcelRecordsMaker excelRecordsMaker = new ExcelRecordsMaker(_dbContext,_excelContext);

            var comparerForSorting = Comparer<ExamResults>.Create((x,y)=>x.StudentFullName.CompareTo(y.StudentFullName));

            excelRecordsMaker.FormSessionExamsReport(comparerForSorting, path);

            File.Exists(path);
        }

        [TestMethod]
        [DataRow("CreditsReport.xlsx")]
        public void SessionCreditsReportTest(string path)
        {
            ExcelRecordsMaker excelRecordsMaker = new ExcelRecordsMaker(_dbContext,_excelContext);

            var comparerForSorting = Comparer<CreditResults>.Create((x,y)=>x.StudentFullName.CompareTo(y.StudentFullName));

            excelRecordsMaker.FormSessionCreditsReport(comparerForSorting, path);

            File.Exists(path);
        }

        [TestMethod]
        [DataRow("StatisticsReport.xlsx")]
        public void StatisticsReportTest(string path)
        {
            ExcelRecordsMaker excelRecordsMaker = new ExcelRecordsMaker(_dbContext,_excelContext);

            var comparerForSorting = Comparer<StatisticResults>.Create((x,y)=>x.MiddleMark.CompareTo(y.MiddleMark));

            excelRecordsMaker.FormStatisticReport(comparerForSorting, path);

            File.Exists(path);
        }

        [TestMethod]
        [DataRow("ExpellReport.xlsx")]
        public void ExpellReportTest(string path)
        {
            ExcelRecordsMaker excelRecordsMaker = new ExcelRecordsMaker(_dbContext,_excelContext);

            var comparerForSorting = Comparer<ExpellResults>.Create((x,y)=>x.StudentFullName.CompareTo(y.StudentFullName));

            excelRecordsMaker.FormExpellReport(comparerForSorting, path);

            File.Exists(path);
        }
    }
}
