using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table(Name = "Credits")]
    public class Credit
    {
        [Column(Name = "Id")]
        public int Id { get; set; }

        [Column(Name = "StudentId")]
        public int StudentId { get; set; }

        [Column(Name = "ExamId")]
        public int SubjectId { get; set; }

        [Column(Name = "Mark")]
        public int Mark { get; set; }
    }
}
