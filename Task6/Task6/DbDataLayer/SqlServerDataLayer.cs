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
using Task6.Connections;

namespace Task6
{
    internal class SqlServerDataLayer<T> : ISqlServerDataLayer<T> where T : class
    {
        private readonly DbSqlConnection _connection;

        private readonly SqlCommadFormatter<T> _formatter;
        public SqlServerDataLayer(DbSqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));

            _formatter = new SqlCommadFormatter<T>();
        }

        public void Delete(int id)
        {
            string tableName;
            try
            {
                tableName = _formatter.GetTableName();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            string sqlCommand = $"DELETE FROM {tableName} WHERE Id = {id}";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Get(int id)
        {
            T entity;

            string tableName;
            try
            {
                tableName = _formatter.GetTableName();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            string sqlCommand = $"SELECT * FROM {tableName} WHERE Id = {id}";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return entity;
        }

        public List<T> GetAll()
        {
            List<T> returnedList = new List<T>();

            string tableName;
            try
            {
                tableName = _formatter.GetTableName();
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }

            string sqlCommand = $"SELECT * FROM {tableName}";

            try
            {
                // Create a connection
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
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
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return returnedList;
        }

        public int Insert(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            List<SqlParameter> sqlParameters;
            int id = 0;
            string sqlCommand;

            try
            {
                sqlParameters = _formatter.GetSqlParameters(item).ToList();

                sqlCommand = _formatter.FormInsertSqlCommand(item);

                sqlCommand = string.Concat(sqlCommand,  "SELECT SCOPE_IDENTITY()");
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }


            try
            {
                // Create a connection
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        sqlParameters.ForEach(sqlParameter => cmd.Parameters.Add(sqlParameter));
                        id = (int)(decimal)cmd.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return id;

        }


        public void Update(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            List<SqlParameter> sqlParameters;
            string id;
            string sqlCommand;

            try
            {
                sqlParameters = _formatter.GetSqlParameters(item).ToList();
                id = _formatter.FormPrimaryKey(item);
                sqlCommand = _formatter.FormUpdateSqlCommand(id);
            }
            catch (InvalidOperationException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
            try
            {
                // Create a connection
                using (SqlConnection connection = new SqlConnection(_connection.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                    {
                        sqlParameters.ForEach(sqlParameter => cmd.Parameters.Add(sqlParameter));
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
