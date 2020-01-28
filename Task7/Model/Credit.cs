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
    /// Class Credit.
    /// </summary>
    [Table(Name = "CreditRecord")]
    public class Credit:IEntityBase
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        [Column(Name = "Id", IsPrimaryKey = true,IsDbGenerated = true)]
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
        [Column(Name = "CreditId")]
        public int SubjectId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is passed.
        /// </summary>
        /// <value><c>true</c> if this instance is passed; otherwise, <c>false</c>.</value>
        [Column(Name = "Passed")]
        public bool IsPassed { get; set; }
    }
}
