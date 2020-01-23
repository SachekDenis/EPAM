﻿using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    [Table(Name = "StatisticResults")]
    public class StatisticResults
    {
        [Column(Name = "GroupName")]
        public string GroupName { get; set; }

        [Column(Name = "SessionStartDate")]
        public DateTime SessionStartDate { get; set; }

        [Column(Name = "SessionEndDate")]
        public DateTime SessionEndDate { get; set; }

        [Column(Name = "MinMark")]
        public int MinMark { get; set; }

        [Column(Name = "MaxMark")]
        public int MaxMark { get; set; }

        [Column(Name = "MiddleMark")]
        public double MiddleMark { get; set; }

    }
}
