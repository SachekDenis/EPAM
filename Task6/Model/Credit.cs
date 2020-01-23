using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table(Name = "CreditRecord")]
    public class Credit
    {
        [Column(Name = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "StudentId")]
        public int StudentId { get; set; }

        [Column(Name = "CreditId")]
        public int SubjectId { get; set; }

        [Column(Name = "Passed")]
        public bool IsPassed { get; set; }
    }
}
