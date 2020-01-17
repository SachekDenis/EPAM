using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table(Name = "Sessions")]
    public class Session
    {
        [Column(Name = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "GroupId")]
        public int GroupId { get; set; }

        [Column(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [Column(Name = "EndDate")]
        public DateTime EndDate { get; set; }
    }
}
