using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class Student.
    /// </summary>
    [Table(Name = "Students")]
    public class Student
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Column(Name = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        [Column(Name = "FullName")]
        public string FullName { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>The gender.</value>
        [Column(Name = "Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the birth date.
        /// </summary>
        /// <value>The birth date.</value>
        [Column(Name = "BirthDate")]
        public DateTime BirthDate {get;set;}

        /// <summary>
        /// Gets or sets the group identifier.
        /// </summary>
        /// <value>The group identifier.</value>
        [Column(Name = "GroupId")]
        public int GroupId {get;set;}
    }
}
