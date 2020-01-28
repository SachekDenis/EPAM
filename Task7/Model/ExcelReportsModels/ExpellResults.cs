﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    /// <summary>
    /// Class ExpellResults.
    /// </summary>
    [Table(Name = "ExpellResults")]
    public class ExpellResults
    {
        /// <summary>
        /// Gets or sets the name of the group.
        /// </summary>
        /// <value>The name of the group.</value>
        [Column(Name = "GroupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the full name of the student.
        /// </summary>
        /// <value>The full name of the student.</value>
        [Column(Name = "StudentFullName")]
        public string StudentFullName { get; set; }

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
        /// Gets or sets the name of the subject.
        /// </summary>
        /// <value>The name of the subject.</value>
        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }

        /// <summary>
        /// Gets or sets the mark.
        /// </summary>
        /// <value>The mark.</value>
        [Column(Name = "Mark")]
        public double Mark { get; set; }
    }
}
