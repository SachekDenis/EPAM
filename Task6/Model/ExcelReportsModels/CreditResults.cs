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
        /// Gets or sets a value indicating whether this instance is passed.
        /// </summary>
        /// <value><c>true</c> if this instance is passed; otherwise, <c>false</c>.</value>
        [Column(Name = "Passed")]
        public bool isPassed { get; set; }
    }
}
