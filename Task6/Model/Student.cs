using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table(Name = "Students")]
    public class Student
    {
        [Column(Name = "Id")]
        public int Id { get; set; }

        [Column(Name = "FullName")]
        public string FullName { get; set; }

        [Column(Name = "Gender")]
        public string Gender { get; set; }

        [Column(Name = "BirthDate")]
        public DateTime BirthDate {get;set;}

        [Column(Name = "GroupId")]
        public int GroupId {get;set;}
    }
}
