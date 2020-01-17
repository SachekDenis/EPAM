using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6;
using Task6.Factory;

namespace Model.SingletonContext
{
    public class DbContext
    {
        private readonly SqlServerDataLayerFactory _sqlServerDataLayerFactory;

        private ISqlServerDataLayer<Exam> _examDataLayer;
        private ISqlServerDataLayer<Credit> _creditDataLayer;
        private ISqlServerDataLayer<Group> _groupDataLayer;
        private ISqlServerDataLayer<Session> _sessionDataLayer;
        private ISqlServerDataLayer<Student> _studentDataLayer;
        private ISqlServerDataLayer<Subject> _subjectDataLayer;

        public DbContext(SqlServerDataLayerFactory sqlServerDataLayerFactory)
        {
            _sqlServerDataLayerFactory = sqlServerDataLayerFactory ?? throw new ArgumentNullException(nameof(sqlServerDataLayerFactory));
        }

        public ISqlServerDataLayer<Exam> GetExamDataLayer()
        {
            return CreateInstance(ref _examDataLayer);
        }

        public ISqlServerDataLayer<Credit> GetCreditDataLayer()
        {
            return CreateInstance(ref _creditDataLayer);
        }

        public ISqlServerDataLayer<Session> GetSessionDataLayer()
        {
            return CreateInstance(ref _sessionDataLayer);
        }

        public ISqlServerDataLayer<Student> GetStudentDataLayer()
        {
            return CreateInstance(ref _studentDataLayer);
        }

        public ISqlServerDataLayer<Group> GetGroupDataLayer()
        {
            return CreateInstance(ref _groupDataLayer);
        }

        public ISqlServerDataLayer<Subject> GetSubjectDataLayer()
        {
            return CreateInstance(ref _subjectDataLayer);
        }

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
