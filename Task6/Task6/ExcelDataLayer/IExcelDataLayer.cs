using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public interface IExcelDataLayer<T> where T:class
    {
        void Insert(T item);
        List<T> GetAll();
        void CreateSheet();
    }
}
