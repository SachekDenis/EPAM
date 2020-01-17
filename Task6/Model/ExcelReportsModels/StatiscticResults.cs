using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    public class StatisticResults
    {
        public string GroupName { get; set; }
        public DateTime SessionStartDate { get; set; }
        public DateTime SessionEndDate { get; set; }
        public int MinMark { get; set; }
        public int MaxMark { get; set; }
        public double MiddleMark { get; set; }

    }
}
