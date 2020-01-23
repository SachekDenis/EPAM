using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    /// <summary>
    /// Class StatisticResults.
    /// </summary>
    [Table(Name = "StatisticResults")]
    public class StatisticResults
    {
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        [Column(Name = "GroupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the session start date.
        /// </summary>
        /// <value>The session start date.</value>
        [Column(Name = "SessionStartDate")]
        public DateTime SessionStartDate { get; set; }

        /// <summary>
        /// Gets or sets the session end date.
        /// </summary>
        /// <value>The session end date.</value>
        [Column(Name = "SessionEndDate")]
        public DateTime SessionEndDate { get; set; }

        /// <summary>
        /// Gets or sets the minimum mark.
        /// </summary>
        /// <value>The minimum mark.</value>
        [Column(Name = "MinMark")]
        public double MinMark { get; set; }

        /// <summary>
        /// Gets or sets the maximum mark.
        /// </summary>
        /// <value>The maximum mark.</value>
        [Column(Name = "MaxMark")]
        public double MaxMark { get; set; }

        /// <summary>
        /// Gets or sets the middle mark.
        /// </summary>
        /// <value>The middle mark.</value>
        [Column(Name = "MiddleMark")]
        public double MiddleMark { get; set; }

    }
}
