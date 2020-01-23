using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    [Table(Name = "ExpellResults")]
    public class ExpellResults
    {
        [Column(Name = "GroupName")]
        public string GroupName { get; set; }

        [Column(Name = "StudentFullName")]
        public string StudentFullName { get; set; }

        [Column(Name = "SessionStartDate")]
        public DateTime SessionStartDate { get; set; }

        [Column(Name = "SessionEndDate")]
        public DateTime SessionEndDate { get; set; }

        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }

        [Column(Name = "Mark")]
        public int Mark { get; set; }
    }
}
