using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class SqlServerDataLayer<T> : ISqlServerDataLayer<T> where T : class
    {
        private readonly string _connectionString;

        private SqlCommadFormatter<T> formatter;
        public SqlServerDataLayer(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

            formatter = new SqlCommadFormatter<T>();
        }

        public void Delete(int id)
        {
            string tableName = formatter.GetTableName();

            string sqlCommand = $"DELETE FROM {tableName} WHERE Id = {id}";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public T Get(int id)
        {
            T entity;

            string tableName = formatter.GetTableName();

            string sqlCommand = $"SELECT * FROM {tableName} WHERE Id = {id}";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create command object
                using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        entity = dr.ToList<T>().FirstOrDefault();
                    }
                }
            }

            return entity;
        }

        public List<T> GetAll()
        {
            List<T> returnedList = new List<T>();

            string tableName = formatter.GetTableName();

            string sqlCommand = $"SELECT * FROM {tableName}";
            // Create a connection
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create command object
                using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                {
                    // Open the connection
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        returnedList = dr.ToList<T>();
                    }
                }
            }

            return returnedList;
        }

        public void Insert(T item)
        {
            List<SqlParameter> sqlParameters = formatter.GetSqlParameters(item).Cast<SqlParameter>().ToList();

            string sqlCommand = formatter.FormInsertSqlCommand(item);

            // Create a connection
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                {
                    sqlParameters.ForEach(sqlParameter => cmd.Parameters.Add(sqlParameter));
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public void Update(T item)
        {
            Type type = typeof(T);

            List<SqlParameter> sqlParameters = formatter.GetSqlParameters(item).Cast<SqlParameter>().ToList();

            int id = (int)type.GetProperties()
                              .Where(property => property.GetCustomAttribute<ColumnAttribute>().Name == "Id")
                              .FirstOrDefault()
                              .GetValue(item,null);

            string sqlCommand = formatter.FormUpdateSqlCommand(id);

            // Create a connection
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                {
                    sqlParameters.ForEach(sqlParameter => cmd.Parameters.Add(sqlParameter));
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
