using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class SqlServerDataLayer<T> : IDataLayer<T> where T : class
    {
        private readonly string _connectionString;

        public SqlServerDataLayer(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public void Delete(int id)
        {
            string tableName = GetTableName();

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

            string tableName = GetTableName();

            string sqlCommand = $"SELECT * FROM {tableName} WHERE Id = {id}";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // Create command object
                using (SqlCommand cmd = new SqlCommand(sqlCommand, connection))
                {
                    connection.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        entity = ToList(dr).FirstOrDefault();
                    }
                }
            }

            return entity;
        }

        public List<T> GetAll()
        {
            List<T> returnedList = new List<T>();

            string tableName = GetTableName();

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
                        returnedList = ToList(dr);
                    }
                }
            }

            return returnedList;
        }

        private List<T> ToList(IDataReader rdr)
        {
            List<T> listOfEntities = new List<T>();
            Type type = typeof(T);

            PropertyInfo[] columns = type.GetProperties();

            // Get all the properties in Entity Class
            ColumnAttribute[] props = type.GetCustomAttributes<ColumnAttribute>().ToArray();

            T entity;

            // Loop through all records
            while (rdr.Read())
            {
                // Create new instance of Entity
                entity = Activator.CreateInstance<T>();

                // Loop through columns to assign data
                for (int i = 0; i < columns.Length; i++)
                {
                    if (rdr[columns[i].Name].Equals(DBNull.Value))
                    {
                        columns[i].SetValue(entity, null, null);
                    }
                    else
                    {
                        columns[i].SetValue(entity, rdr[props[i].Name], null);
                    }
                }

                listOfEntities.Add(entity);
            }

            return listOfEntities;
        }

        public void Insert(T item)
        {
            List<SqlParameter> sqlParameters = GetSqlParameters(item);

            string sqlCommand = FormInsertSqlCommand(item);

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

        private string FormInsertSqlCommand(T item)
        {
            Type type = typeof(T);

            List<PropertyInfo> columns = type.GetProperties().ToList();

            string tableName = GetTableName();

            string sqlCommand = $"INSERT INTO {tableName} (";

            columns.ForEach(column =>
            {
                sqlCommand = string.Concat(sqlCommand, column.GetCustomAttribute<ColumnAttribute>().Name, ",");
            });

            sqlCommand = string.Concat(sqlCommand, ") VALUES(");

            columns.ForEach(column =>
            {
                sqlCommand = string.Concat(sqlCommand, "@", column.GetCustomAttribute<ColumnAttribute>().Name, ",");
            });

            sqlCommand = string.Concat(sqlCommand, ")");

            return sqlCommand;
        }

        private string FormUpdateSqlCommand(int id)
        {
            Type type = typeof(T);

            List<PropertyInfo> columns = type.GetProperties().ToList();

            string tableName = GetTableName();

            string sqlCommand = $"UPDATE {tableName} SET";

            columns.ForEach(column =>
            {
                sqlCommand = string.Concat(sqlCommand, column.GetCustomAttribute<ColumnAttribute>().Name, "=@", column.GetCustomAttribute<ColumnAttribute>().Name);
            });

            sqlCommand = string.Concat(sqlCommand, $"WHERE Id = {id}");

            return sqlCommand;
        }

        private List<SqlParameter> GetSqlParameters(T item)
        {
            Type type = typeof(T);
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            List<PropertyInfo> columns = type.GetProperties().ToList();

            columns.ForEach(column =>
            {
                sqlParameters.Add(new SqlParameter(column.GetCustomAttribute<ColumnAttribute>().Name, column.GetValue(item, null)));
            });

            return sqlParameters;
        }
        private string GetTableName()
        {
            return typeof(T).GetCustomAttribute<TableAttribute>().Name;
        }

        public void Update(T item)
        {
            Type type = typeof(T);

            List<SqlParameter> sqlParameters = GetSqlParameters(item);

            int id = (int)type.GetProperties()
                              .Where(property => property.GetCustomAttribute<ColumnAttribute>().Name == "Id")
                              .FirstOrDefault()
                              .GetValue(item,null);

            string sqlCommand = FormUpdateSqlCommand(id);

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
