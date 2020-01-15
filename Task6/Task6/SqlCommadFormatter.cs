using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class SqlCommadFormatter<T>
    {
        public string FormInsertSqlCommand(T item)
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

        public string FormUpdateSqlCommand(int id)
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

        public List<DbParameter> GetSqlParameters(T item)
        {
            Type type = typeof(T);
            List<DbParameter> sqlParameters = new List<DbParameter>();
            List<PropertyInfo> columns = type.GetProperties().ToList();

            columns.ForEach(column =>
            {
                sqlParameters.Add(new SqlParameter(column.GetCustomAttribute<ColumnAttribute>().Name, column.GetValue(item, null)));
            });

            return sqlParameters;
        }
        public string GetTableName()
        {
            return typeof(T).GetCustomAttribute<TableAttribute>().Name;
        }
    }
}
