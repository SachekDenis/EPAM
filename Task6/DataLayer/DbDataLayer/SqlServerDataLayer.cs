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
    /// <summary>
    /// Class SqlServerDataLayer.
    /// Implements the <see cref="Task6.ISqlServerDataLayer{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Task6.ISqlServerDataLayer{T}" />
    internal class SqlServerDataLayer<T> : ISqlServerDataLayer<T> where T : class
    {
        /// <summary>
        /// The connection
        /// </summary>
        private readonly DbSqlConnection _connection;

        /// <summary>
        /// The formatter
        /// </summary>
        private readonly SqlCommadFormatter<T> _formatter;
        /// <summary>
        /// Initializes a new instance of the <see cref="SqlServerDataLayer{T}"/> class.
        /// </summary>
        /// <param name="connection">The connection.</param>
        /// <exception cref="ArgumentNullException">connection</exception>
        public SqlServerDataLayer(DbSqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));

            _formatter = new SqlCommadFormatter<T>();
        }

        /// <summary>
        /// Deletes by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Gets by the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
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

                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            entity = reader.ToList<T>().FirstOrDefault();
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

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>List&lt;T&gt;.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        /// <!-- Badly formed XML comment ignored for member "M:Task6.ISqlServerDataLayer`1.GetAll" -->
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

                        using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            returnedList = reader.ToList<T>();
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

        /// <summary>
        /// Inserts the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="ArgumentNullException">item</exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
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

                        //BIGINT in sql
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


        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <exception cref="ArgumentNullException">item</exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
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
