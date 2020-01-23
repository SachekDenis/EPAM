using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.ExcelReportsModels;
using Model.SingletonContext;
using Task6.Connections;
using Task6.Factory;

namespace DataLayerTest
{
    /// <summary>
    /// Defines test class ExcelDataLayerTest.
    /// </summary>
    [TestClass]
    public class ExcelDataLayerTest
    {
        /// <summary>
        /// The context
        /// </summary>
        ExcelContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelDataLayerTest"/> class.
        /// </summary>
        public ExcelDataLayerTest()
        {
            ExcelConnection connection = new ExcelConnection();
            AdoExcelDataLayerFactory factory = new AdoExcelDataLayerFactory(connection);
            _context = new ExcelContext(factory);
        }

        /// <summary>
        /// Defines the test method TestExcelExporting.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="groupName">Name of the group.</param>
        /// <param name="mark">The mark.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="studentFullName">Full name of the student.</param>
        [TestMethod]
        [DataRow("test.xlsx", "TT-12", 10, "Math", "Kravchov Ivan Viktorovich")]
        public void TestExcelExporting(string path, string groupName, int mark, string subject,string studentFullName)
        {
            ExamResults examResults = new ExamResults() { ExamDate = DateTime.Now, 
                                                          GroupName = groupName, 
                                                          Mark = mark, 
                                                          SubjectName = subject, 
                                                          SessionStartDate = DateTime.Now,
                                                          SessionEndDate = DateTime.Now, 
                                                          StudentFullName = studentFullName};

            var examContext = _context.GetExamResultsDataLayer();

            _context.SetFilePath(path);

            examContext.CreateSheet();

            examContext.Insert(examResults);

            Assert.IsTrue(File.Exists(path));

            File.Delete(path);
        }

        /// <summary>
        /// Defines the test method InsertNullMustThrowsException.
        /// </summary>
        [TestMethod]
        public void InsertNullMustThrowsException()
        {
            var examContext = _context.GetExamResultsDataLayer();

            Assert.ThrowsException<ArgumentNullException>(()=>examContext.Insert(null));
        }
    }
}
