using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    /// <summary>
    /// Class StatisticByYear.
    /// </summary>
    [Table(Name = "StatisticByYear")]
    public class StatisticByYear
    {
        /// <summary>
        /// Gets or sets the name of the subject.
        /// </summary>
        /// <value>The name of the subject.</value>
        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }

        /// <summary>
        /// Gets or sets the year.
        /// </summary>
        /// <value>The year.</value>
        [Column(Name = "SessionYear")]
        public double Year { get; set; }

        /// <summary>
        /// Gets or sets the middle mark.
        /// </summary>
        /// <value>The middle mark.</value>
        [Column(Name = "MiddleMark")]
        public double MiddleMark { get; set; }
    }
}
