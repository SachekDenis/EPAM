using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    /// <summary>
    /// Class ExamResults.
    /// Implements the <see cref="Model.ExcelReportsModels.GroupsSessionResults" />
    /// </summary>
    /// <seealso cref="Model.ExcelReportsModels.GroupsSessionResults" />
    [Table(Name = "SessionResults")]
    public class ExamResults : GroupsSessionResults
    {
        /// <summary>
        /// Gets or sets the mark.
        /// </summary>
        /// <value>The mark.</value>
        [Column(Name = "Mark")]
        public double Mark { get; set; }
    }
}
