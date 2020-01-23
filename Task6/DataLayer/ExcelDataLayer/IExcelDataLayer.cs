using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    /// <summary>
    /// Interface IExcelDataLayer
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IExcelDataLayer<T> where T:class
    {
        /// <summary>
        /// Inserts the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Insert(T item);
        /// <summary>
        /// Creates the sheet.
        /// </summary>
        void CreateSheet();
    }
}
