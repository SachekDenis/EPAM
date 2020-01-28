using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    /// <summary>
    /// Class SqlCommadFormatter.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class SqlCommadFormatter<T>
    {
        /// <summary>
        /// The type
        /// </summary>
        private readonly Type _type = typeof(T);
        /// <summary>
        /// Forms the create SQL command.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException">Type haven't got ColumnAttribute</exception>
        public string FormCreateSqlCommand()
        {
            string sqlCommand;
            try
            {
                List<PropertyInfo> properties = _type.GetProperties().Where(column => !column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).ToList();

                string tableName = GetTableName();

                sqlCommand = $"CREATE TABLE {tableName} (";

                properties.ForEach(column =>
                {
                    sqlCommand = string.Concat(sqlCommand, column.GetCustomAttribute<ColumnAttribute>().Name, " ", GetSqlType(column.PropertyType), ",");
                });

                sqlCommand = sqlCommand.TrimEnd(',');

                sqlCommand = string.Concat(sqlCommand, ")");

            }
            catch (Exception)
            {
                throw new InvalidOperationException("Type haven't got ColumnAttribute");
            }

            return sqlCommand;
        }
        /// <summary>
        /// Forms the insert SQL command.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException">Type haven't got ColumnAttribute</exception>
        public string FormInsertSqlCommand(T item)
        {
            string sqlCommand;
            try
            {
                List<PropertyInfo> properties = _type.GetProperties().Where(column => !column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).ToList();

                string tableName = GetTableName();

                sqlCommand = $"INSERT INTO {tableName} (";

                properties.ForEach(column =>
                {
                    sqlCommand = string.Concat(sqlCommand, column.GetCustomAttribute<ColumnAttribute>().Name, ",");
                });

                sqlCommand = sqlCommand.TrimEnd(',');

                sqlCommand = string.Concat(sqlCommand, ") VALUES(");

                properties.ForEach(column =>
                {
                    sqlCommand = string.Concat(sqlCommand, "@", column.GetCustomAttribute<ColumnAttribute>().Name, ",");
                });

                sqlCommand = sqlCommand.TrimEnd(',');

                sqlCommand = string.Concat(sqlCommand, ");");

            }
            catch (Exception)
            {
                throw new InvalidOperationException("Type haven't got ColumnAttribute");
            }

            return sqlCommand;
        }

        /// <summary>
        /// Forms the update SQL command.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException">Type haven't got ColumnAttribute</exception>
        public string FormUpdateSqlCommand(string id)
        {
            string sqlCommand;
            try
            {
                List<PropertyInfo> properties = _type.GetProperties().Where(column => !column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).ToList();

                string tableName = GetTableName();

                sqlCommand = $"UPDATE {tableName} SET ";

                properties.ForEach(column =>
                {
                    sqlCommand = string.Concat(sqlCommand, column.GetCustomAttribute<ColumnAttribute>().Name, "=@", column.GetCustomAttribute<ColumnAttribute>().Name, ",");
                });

                sqlCommand = sqlCommand.TrimEnd(',');

                sqlCommand = string.Concat(sqlCommand, $" WHERE {id}");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Type haven't got ColumnAttribute");
            }

            return sqlCommand;
        }

        /// <summary>
        /// Forms the primary key.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException">Type haven't got ColumnAttribute</exception>
        public string FormPrimaryKey(T item)
        {
            string primaryKey = string.Empty;
            try
            {
                List<PropertyInfo> keys = _type.GetProperties().Where(column => column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).ToList();

                keys.ForEach(key => primaryKey = string.Concat(primaryKey, key.GetCustomAttribute<ColumnAttribute>().Name, " = ", key.GetValue(item, null), ","));

                primaryKey = primaryKey.TrimEnd(',');
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Type haven't got ColumnAttribute");
            }

            return primaryKey;
        }

        /// <summary>
        /// Gets the SQL parameters.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>List&lt;SqlParameter&gt;.</returns>
        /// <exception cref="InvalidOperationException">Type haven't got ColumnAttribute</exception>
        public List<SqlParameter> GetSqlParameters(T item)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                List<PropertyInfo> properties = _type.GetProperties().Where(column => column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey != true).ToList();

                properties.ForEach(column =>
                {
                    sqlParameters.Add(new SqlParameter(column.GetCustomAttribute<ColumnAttribute>().Name, column.GetValue(item, null)));
                });
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Type haven't got ColumnAttribute");
            }

            return sqlParameters;
        }

        /// <summary>
        /// Gets the OLE database parameters.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>List&lt;OleDbParameter&gt;.</returns>
        /// <exception cref="InvalidOperationException">Type haven't got ColumnAttribute</exception>
        public List<OleDbParameter> GetOleDbParameters(T item)
        {
            List<OleDbParameter> oleDbParameters = new List<OleDbParameter>();
            try
            {
                List<PropertyInfo> columns = _type.GetProperties().Where(column => !column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).ToList();

                columns.ForEach(column =>
                {
                    oleDbParameters.Add(new OleDbParameter(column.GetCustomAttribute<ColumnAttribute>().Name, column.GetValue(item, null)));
                });
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Type haven't got ColumnAttribute");
            }

            return oleDbParameters;
        }
        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="InvalidOperationException">Type haven't got TableAttribute</exception>
        public string GetTableName()
        {
            string tableName;
            try
            {
                tableName = typeof(T).GetCustomAttribute<TableAttribute>().Name;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Type haven't got TableAttribute");
            }
            return tableName;
        }


        /// <summary>
        /// Gets the SQL type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="columnSize">Size of the column.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="Exception"></exception>
        private string GetSqlType(object type, int columnSize = -1)
        {

            switch (type.ToString())
            {

                case "System.String":
                    return "VARCHAR(" + ((columnSize == -1) ? 255 : columnSize) + ")";
                case "System.Decimal":
                    return "DECIMAL";
                case "System.Double":
                case "System.Single":
                    return "FLOAT";
                case "System.Int64":
                    return "BIGINT";
                case "System.Int16":
                case "System.Int32":
                    return "INT";
                case "System.DateTime":
                    return "DATETIME";
                case "System.Boolean":
                    return "BIT";
                default:
                    throw new Exception(type.ToString() + " not implemented.");
            }
        }
    }
}
