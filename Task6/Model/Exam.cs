using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Class Exam.
    /// </summary>
    [Table(Name = "ExamRecord")]
    public class Exam
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Column(Name = "Id", IsPrimaryKey = true)]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the student identifier.
        /// </summary>
        /// <value>The student identifier.</value>
        [Column(Name = "StudentId")]
        public int StudentId { get; set; }

        /// <summary>
        /// Gets or sets the subject identifier.
        /// </summary>
        /// <value>The subject identifier.</value>
        [Column(Name = "ExamId")]
        public int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets the mark.
        /// </summary>
        /// <value>The mark.</value>
        [Column(Name = "Mark")]
        public int Mark { get; set; }

    }
}
