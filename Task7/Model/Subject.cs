using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class Subject.
    /// Implements the <see cref="DataLayer.IEntityBase" />
    /// </summary>
    /// <seealso cref="DataLayer.IEntityBase" />
    [Table(Name = "Subjects")]
    public class Subject:IEntityBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Column(Name = "Id", IsPrimaryKey = true,IsDbGenerated = true)]
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [Column(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>The date.</value>
        [Column(Name = "Date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the session identifier.
        /// </summary>
        /// <value>The session identifier.</value>
        [Column(Name = "SessionId")]
        public int SessionId { get; set; }
        /// <summary>
        /// Gets or sets the full name of the examiner.
        /// </summary>
        /// <value>The full name of the examiner.</value>
        [Column(Name = "ExaminerFullName")]
        public string ExaminerFullName {get;set;}
    }
}
