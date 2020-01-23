using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    /// <summary>
    /// Class IDataReaderToList.
    /// </summary>
    internal static class IDataReaderToList
    {
        /// <summary>
        /// Converts to list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="reader">The reader.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public static List<T> ToList<T>(this IDataReader reader)
        {
            List<T> listOfEntities = new List<T>();
            Type type = typeof(T);

            PropertyInfo[] columns = type.GetProperties();

            // Get all the properties in Entity Class
            ColumnAttribute[] props = columns.Select(item=>item.GetCustomAttribute<ColumnAttribute>()).ToArray();

            T entity;

            // Loop through all records
            while (reader.Read())
            {
                // Create new instance of Entity
                entity = Activator.CreateInstance<T>();

                // Loop through columns to assign data
                for (int i = 0; i < columns.Length; i++)
                {
                    if (reader[props[i].Name].Equals(DBNull.Value))
                    {
                        columns[i].SetValue(entity, null, null);
                    }
                    else
                    {
                        columns[i].SetValue(entity, reader[props[i].Name], null);
                    }
                }

                listOfEntities.Add(entity);
            }

            return listOfEntities;
        }
    }
}
