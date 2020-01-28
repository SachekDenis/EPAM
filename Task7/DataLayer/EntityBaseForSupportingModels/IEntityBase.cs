using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    /// <summary>
    /// Interface IEntityBase
    /// </summary>
    public interface IEntityBase
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        int Id { get;set; }
    }
}
