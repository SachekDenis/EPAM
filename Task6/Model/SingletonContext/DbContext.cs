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
    /// Class DbContext.
    /// </summary>
    public class DbContext
    {
        /// <summary>
        /// The SQL server data layer factory
        /// </summary>
        private readonly SqlServerDataLayerFactory _sqlServerDataLayerFactory;

        /// <summary>
        /// The exam data layer
        /// </summary>
        private ISqlServerDataLayer<Exam> _examDataLayer;
        /// <summary>
        /// The credit data layer
        /// </summary>
        private ISqlServerDataLayer<Credit> _creditDataLayer;
        /// <summary>
        /// The group data layer
        /// </summary>
        private ISqlServerDataLayer<Group> _groupDataLayer;
        /// <summary>
        /// The session data layer
        /// </summary>
        private ISqlServerDataLayer<Session> _sessionDataLayer;
        /// <summary>
        /// The student data layer
        /// </summary>
        private ISqlServerDataLayer<Student> _studentDataLayer;
        /// <summary>
        /// The subject data layer
        /// </summary>
        private ISqlServerDataLayer<Subject> _subjectDataLayer;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContext"/> class.
        /// </summary>
        /// <param name="sqlServerDataLayerFactory">The SQL server data layer factory.</param>
        /// <exception cref="ArgumentNullException">sqlServerDataLayerFactory</exception>
        public DbContext(SqlServerDataLayerFactory sqlServerDataLayerFactory)
        {
            _sqlServerDataLayerFactory = sqlServerDataLayerFactory ?? throw new ArgumentNullException(nameof(sqlServerDataLayerFactory));
        }

        /// <summary>
        /// Gets the exam data layer.
        /// </summary>
        /// <returns>ISqlServerDataLayer&lt;Exam&gt;.</returns>
        public ISqlServerDataLayer<Exam> GetExamDataLayer()
        {
            return CreateInstance(ref _examDataLayer);
        }

        /// <summary>
        /// Gets the credit data layer.
        /// </summary>
        /// <returns>ISqlServerDataLayer&lt;Credit&gt;.</returns>
        public ISqlServerDataLayer<Credit> GetCreditDataLayer()
        {
            return CreateInstance(ref _creditDataLayer);
        }

        /// <summary>
        /// Gets the session data layer.
        /// </summary>
        /// <returns>ISqlServerDataLayer&lt;Session&gt;.</returns>
        public ISqlServerDataLayer<Session> GetSessionDataLayer()
        {
            return CreateInstance(ref _sessionDataLayer);
        }

        /// <summary>
        /// Gets the student data layer.
        /// </summary>
        /// <returns>ISqlServerDataLayer&lt;Student&gt;.</returns>
        public ISqlServerDataLayer<Student> GetStudentDataLayer()
        {
            return CreateInstance(ref _studentDataLayer);
        }

        /// <summary>
        /// Gets the group data layer.
        /// </summary>
        /// <returns>ISqlServerDataLayer&lt;Group&gt;.</returns>
        public ISqlServerDataLayer<Group> GetGroupDataLayer()
        {
            return CreateInstance(ref _groupDataLayer);
        }

        /// <summary>
        /// Gets the subject data layer.
        /// </summary>
        /// <returns>ISqlServerDataLayer&lt;Subject&gt;.</returns>
        public ISqlServerDataLayer<Subject> GetSubjectDataLayer()
        {
            return CreateInstance(ref _subjectDataLayer);
        }

        /// <summary>
        /// Creates the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataLayer">The data layer.</param>
        /// <returns>ISqlServerDataLayer&lt;T&gt;.</returns>
        private ISqlServerDataLayer<T> CreateInstance<T>(ref ISqlServerDataLayer<T> dataLayer) where T:class
        {
            if (dataLayer == null)
            {
                dataLayer = _sqlServerDataLayerFactory.GetSqlServerDataLayer<T>();
            }
            return dataLayer;
        }
    }
}
