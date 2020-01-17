using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    [Table(Name = "Session results")]
    public class ExamResults : GroupsSessionResults
    {
        [Column(Name = "Mark")]
        public int Mark { get; set; }
    }
}
