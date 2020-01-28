using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    /// <summary>
    /// Class CreditResults.
    /// Implements the <see cref="Model.ExcelReportsModels.GroupsSessionResults" />
    /// </summary>
    /// <seealso cref="Model.ExcelReportsModels.GroupsSessionResults" />
    [Table(Name = "SessionResults")]
    public class CreditResults : GroupsSessionResults
    {

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>The status.</value>
        [Column(Name = "Status")]
        public string Status { get; set; }
    }
}
