using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public interface ISqlServerDataLayer<T> where T:class
    {
        void Insert(T item);
        T Get(int id);
        List<T> GetAll();
        void Update(T item);
        void Delete(int id);
    }
}
