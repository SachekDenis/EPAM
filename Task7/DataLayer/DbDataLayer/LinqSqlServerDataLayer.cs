using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Task6;

namespace DataLayer.DbDataLayer
{
    class LinqSqlServerDataLayer<T> : ISqlServerDataLayer<T> where T : class, IEntityBase
    {
        private readonly DbSqlConnection _connection;


        public LinqSqlServerDataLayer(DbSqlConnection connection)
        {
            _connection = connection ?? throw new ArgumentNullException(nameof(connection));
        }

        public void Delete(int id)
        {
            using (DataContext dataContext = new DataContext(_connection.ConnectionString))
            {
                T item = dataContext.GetTable<T>().AsEnumerable().FirstOrDefault(e => e.Id == id);
                dataContext.GetTable<T>().DeleteOnSubmit(item);
                dataContext.SubmitChanges();
            }
        }

        public T Get(int id)
        {
            T item = null;
            using (DataContext dataContext = new DataContext(_connection.ConnectionString))
            {
                item = dataContext.GetTable<T>().AsEnumerable().First(e => e.Id == id);
            }
            return item;

        }

        public List<T> GetAll()
        {
            List<T> items;
            using (DataContext dataContext = new DataContext(_connection.ConnectionString))
            {
                items = dataContext.GetTable<T>().ToList();
            }
            return items;
        }

        public int Insert(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            using (DataContext dataContext = new DataContext(_connection.ConnectionString))
            {
                dataContext.GetTable<T>().InsertOnSubmit(item);
                dataContext.SubmitChanges();
            }
            return item.Id;
        }

        public void Update(T item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            using (DataContext dataContext = new DataContext(_connection.ConnectionString))
            {
                var updatingItem = dataContext.GetTable<T>().AsEnumerable().FirstOrDefault(e => e.Id == item.Id);

                if(updatingItem == null)
                    return;

                foreach (var property in typeof(T).GetProperties().Where(info => info.GetCustomAttribute<ColumnAttribute>() != null))
                {
                    property.SetValue(updatingItem, property.GetValue(item));
                }
                dataContext.SubmitChanges();
            }
        }
    }
}
