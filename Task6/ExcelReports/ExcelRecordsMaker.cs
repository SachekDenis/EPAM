using Model;
using Model.ExcelReportsModels;
using Model.SingletonContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Factory;

namespace ExcelReports
{
    /// <summary>
    /// Class ExcelRecordsMaker.
    /// </summary>
    public class ExcelRecordsMaker
    {
        /// <summary>
        /// The database conxtext
        /// </summary>
        private readonly DbContext _dbConxtext;

        /// <summary>
        /// The excel context
        /// </summary>
        private readonly ExcelContext _excelContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExcelRecordsMaker"/> class.
        /// </summary>
        /// <param name="dbConxtext">The database conxtext.</param>
        /// <param name="excelContext">The excel context.</param>
        /// <exception cref="ArgumentNullException">
        /// dbConxtext
        /// or
        /// excelContext
        /// </exception>
        public ExcelRecordsMaker(DbContext dbConxtext, ExcelContext excelContext)
        {
            _dbConxtext = dbConxtext ?? throw new ArgumentNullException(nameof(dbConxtext));
            _excelContext = excelContext ?? throw new ArgumentNullException(nameof(excelContext));


        }

        /// <summary>
        /// Forms the session exams report.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <param name="path">The path.</param>
        public void FormSessionExamsReport(IComparer<ExamResults> comparer, string path)
        {
            var excelContext = _excelContext.GetExamResultsDataLayer();

            var groupContext = _dbConxtext.GetGroupDataLayer();
            var studentContext = _dbConxtext.GetStudentDataLayer();
            var subjectContext = _dbConxtext.GetSubjectDataLayer();
            var examContext = _dbConxtext.GetExamDataLayer();
            var sessionContext = _dbConxtext.GetSessionDataLayer();

            List<Group> groups = groupContext.GetAll();
            List<Student> students = studentContext.GetAll();
            List<Subject> subjects = subjectContext.GetAll();
            List<Exam> exams = examContext.GetAll();
            List<Session> sessions = sessionContext.GetAll();

            var groupsSessionResultsQuery = from groupItem in groups
                                            join student in students on groupItem.Id equals student.GroupId
                                            join session in sessions on groupItem.Id equals session.GroupId
                                            join exam in exams on student.Id equals exam.StudentId
                                            join subject in subjects on exam.SubjectId equals subject.Id
                                            select new ExamResults()
                                            {
                                                ExamDate = subject.Date,
                                                GroupName = groupItem.Name,
                                                Mark = exam.Mark,
                                                SessionEndDate = session.EndDate,
                                                SessionStartDate = session.StartDate,
                                                StudentFullName = student.FullName,
                                                SubjectName = subject.Name
                                            };
            PrepareFile(path);

            excelContext.CreateSheet();

            groupsSessionResultsQuery.OrderBy(item => item, comparer).ToList().ForEach(item => excelContext.Insert(item));

        }

        /// <summary>
        /// Forms the session credits report.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <param name="path">The path.</param>
        public void FormSessionCreditsReport(IComparer<CreditResults> comparer, string path)
        {
            var excelContext = _excelContext.GetCreditResultsDataLayer();

            var groupContext = _dbConxtext.GetGroupDataLayer();
            var studentContext = _dbConxtext.GetStudentDataLayer();
            var subjectContext = _dbConxtext.GetSubjectDataLayer();
            var creditContext = _dbConxtext.GetCreditDataLayer();
            var sessionContext = _dbConxtext.GetSessionDataLayer();

            List<Group> groups = groupContext.GetAll();
            List<Student> students = studentContext.GetAll();
            List<Subject> subjects = subjectContext.GetAll();
            List<Credit> credits = creditContext.GetAll();
            List<Session> sessions = sessionContext.GetAll();

            var groupsSessionResultsQuery = from groupItem in groups
                                            join student in students on groupItem.Id equals student.GroupId
                                            join session in sessions on groupItem.Id equals session.GroupId
                                            join credit in credits on student.Id equals credit.StudentId
                                            join subject in subjects on credit.SubjectId equals subject.Id
                                            select new CreditResults()
                                            {
                                                ExamDate = subject.Date,
                                                GroupName = groupItem.Name,
                                                isPassed = credit.IsPassed,
                                                SessionEndDate = session.EndDate,
                                                SessionStartDate = session.StartDate,
                                                StudentFullName = student.FullName,
                                                SubjectName = subject.Name
                                            };

            PrepareFile(path);

            excelContext.CreateSheet();

            groupsSessionResultsQuery.OrderBy(item => item, comparer).ToList().ForEach(item => excelContext.Insert(item));

        }

        /// <summary>
        /// Forms the statistic report.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <param name="path">The path.</param>
        public void FormStatisticReport(IComparer<StatisticResults> comparer, string path)
        {
            var excelContext = _excelContext.GetStatisticResultsDataLayer();

            var groupContext = _dbConxtext.GetGroupDataLayer();
            var sessionContext = _dbConxtext.GetSessionDataLayer();
            var subjectContext = _dbConxtext.GetSubjectDataLayer();
            var examContext = _dbConxtext.GetExamDataLayer();

            List<Group> groups = groupContext.GetAll();
            List<Session> sessions = sessionContext.GetAll();
            List<Subject> subjects = subjectContext.GetAll();
            List<Exam> exams = examContext.GetAll();

            var statisticQuery = from groupItem in groups
                                 join session in sessions on groupItem.Id equals session.GroupId
                                 join subject in subjects on session.Id equals subject.SessionId
                                 join exam in exams on subject.Id equals exam.SubjectId
                                 group new { groupItem, session, subject, exam } by session.Id into item
                                 select new StatisticResults()
                                 {
                                     GroupName = item.FirstOrDefault().groupItem.Name,
                                     SessionEndDate = item.FirstOrDefault().session.EndDate,
                                     SessionStartDate = item.FirstOrDefault().session.StartDate,
                                     MinMark = item.Min(e => e.exam.Mark),
                                     MaxMark = item.Max(e => e.exam.Mark),
                                     MiddleMark = item.Average(e => e.exam.Mark),
                                 };

            PrepareFile(path);

            excelContext.CreateSheet();

            statisticQuery.OrderBy(item => item, comparer).ToList().ForEach(item => excelContext.Insert(item));
        }

        /// <summary>
        /// Forms the expell report.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <param name="path">The path.</param>
        public void FormExpellReport(IComparer<ExpellResults> comparer, string path)
        {
            var excelContext = _excelContext.GetExpellResultsDataLayer();

            var groupContext = _dbConxtext.GetGroupDataLayer();
            var studentContext = _dbConxtext.GetStudentDataLayer();
            var sessionContext = _dbConxtext.GetSessionDataLayer();
            var subjectContext = _dbConxtext.GetSubjectDataLayer();
            var examContext = _dbConxtext.GetExamDataLayer();

            List<Group> groups = groupContext.GetAll();
            List<Student> students = studentContext.GetAll();
            List<Session> sessions = sessionContext.GetAll();
            List<Subject> subjects = subjectContext.GetAll();
            List<Exam> exams = examContext.GetAll();

            var statisticQuery = from groupItem in groups
                                 join session in sessions on groupItem.Id equals session.GroupId
                                 join student in students on groupItem.Id equals student.GroupId
                                 join subject in subjects on session.Id equals subject.SessionId
                                 join exam in exams on subject.Id equals exam.SubjectId
                                 where exam.Mark < 4
                                 select new ExpellResults()
                                 {
                                     GroupName = groupItem.Name,
                                     StudentFullName = student.FullName,
                                     SessionEndDate = session.StartDate,
                                     SessionStartDate = session.EndDate,
                                     SubjectName = subject.Name,
                                     Mark = exam.Mark
                                 };

            PrepareFile(path);

            excelContext.CreateSheet();

            statisticQuery.OrderBy(item => item, comparer).ToList().ForEach(item => excelContext.Insert(item));
        }

        /// <summary>
        /// Files the delete.
        /// </summary>
        /// <param name="path">The path.</param>
        private void FileDelete(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// Prepares the file.
        /// </summary>
        /// <param name="path">The path.</param>
        private void PrepareFile(string path)
        {
            FileDelete(path);

            _excelContext.SetFilePath(path);

        }
    }
}
