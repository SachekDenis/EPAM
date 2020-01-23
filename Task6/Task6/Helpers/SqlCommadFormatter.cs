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
    internal class SqlCommadFormatter<T>
    {
        private readonly Type _type = typeof(T);
        public string FormCreateSqlCommand()
        {
            string sqlCommand;
            try
            {
                List<PropertyInfo> columns = _type.GetProperties().Where(column => !column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).ToList();

                string tableName = GetTableName();

                sqlCommand = $"CREATE TABLE {tableName} (";

                columns.ForEach(column =>
                {
                    sqlCommand = string.Concat(sqlCommand, column.GetCustomAttribute<ColumnAttribute>().Name, " ", SQLGetType(column.PropertyType), ",");
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
        public string FormInsertSqlCommand(T item)
        {
            string sqlCommand;
            try
            {
                List<PropertyInfo> columns = _type.GetProperties().Where(column => !column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).ToList();

                string tableName = GetTableName();

                sqlCommand = $"INSERT INTO {tableName} (";

                columns.ForEach(column =>
                {
                    sqlCommand = string.Concat(sqlCommand, column.GetCustomAttribute<ColumnAttribute>().Name, ",");
                });

                sqlCommand = sqlCommand.TrimEnd(',');

                sqlCommand = string.Concat(sqlCommand, ") VALUES(");

                columns.ForEach(column =>
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

        public string FormUpdateSqlCommand(string id)
        {
            string sqlCommand;
            try
            {
                List<PropertyInfo> columns = _type.GetProperties().Where(column => !column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).ToList();

                string tableName = GetTableName();

                sqlCommand = $"UPDATE {tableName} SET ";

                columns.ForEach(column =>
                {
                    sqlCommand = string.Concat(sqlCommand, column.GetCustomAttribute<ColumnAttribute>().Name, "=@", column.GetCustomAttribute<ColumnAttribute>().Name);
                });

                sqlCommand = string.Concat(sqlCommand, $" WHERE {id}");
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Type haven't got ColumnAttribute");
            }

            return sqlCommand;
        }

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

        public List<SqlParameter> GetSqlParameters(T item)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            try
            {
                List<PropertyInfo> columns = _type.GetProperties().Where(column => column.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey != true).ToList();

                columns.ForEach(column =>
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

        private string SQLGetType(object type, int columnSize = -1)
        {

            switch (type.ToString())
            {

                case "System.String":
                    return "VARCHAR(" + ((columnSize == -1) ? 255 : columnSize) + ")";
                case "System.Decimal":
                    return "REAL";
                case "System.Double":
                case "System.Single":
                    return "REAL";
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
