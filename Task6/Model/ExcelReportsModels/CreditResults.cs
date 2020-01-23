using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ExcelReportsModels
{
    [Table(Name = "SessionResults")]
    public class CreditResults : GroupsSessionResults
    {
        [Column(Name = "Passed")]
        public bool isPassed { get; set; }
    }
}
