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
    /// Class Group.
    /// Implements the <see cref="DataLayer.IEntityBase" />
    /// </summary>
    /// <seealso cref="DataLayer.IEntityBase" />
    [Table(Name = "Groups")]
    public class Group : IEntityBase
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
        /// Gets or sets the specialty identifier.
        /// </summary>
        /// <value>The specialty identifier.</value>
        [Column(Name = "SpecialtyId")]
        public int SpecialtyId {get;set;}
    }
}
