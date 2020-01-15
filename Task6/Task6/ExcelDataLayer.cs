using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class ExcelDataLayer<T> : IExcelDataLayer<T> where T : class
    {

        private readonly string _connectionString;

        private SqlCommadFormatter<T> formatter;
        public ExcelDataLayer(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

            formatter = new SqlCommadFormatter<T>();
        }

        public List<T> GetAll()
        {
            List<T> returnedList = new List<T>();

            string tableName = formatter.GetTableName();

            string sqlCommand = $"SELECT * FROM {tableName}";
            // Create a connection
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                // Create command object
                using (OleDbCommand cmd = new OleDbCommand(sqlCommand, connection))
                {
                    // Open the connection
                    connection.Open();

                    using (OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        returnedList = dr.ToList<T>();
                    }
                }
            }

            return returnedList;
        }

        public void Insert(T item)
        {
            List<OleDbParameter> sqlParameters = formatter.GetSqlParameters(item).Cast<OleDbParameter>().ToList();

            string sqlCommand = formatter.FormInsertSqlCommand(item);

            // Create a connection
            using (OleDbConnection connection = new OleDbConnection(_connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand(sqlCommand, connection))
                {
                    sqlParameters.ForEach(sqlParameter => cmd.Parameters.Add(sqlParameter));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}