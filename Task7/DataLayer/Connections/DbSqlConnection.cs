using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    /// <summary>
    /// Class DbSqlConnection.
    /// </summary>
    public class DbSqlConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbSqlConnection"/> class.
        /// </summary>
        public DbSqlConnection()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;
        }

        /// <summary>
        /// Gets or sets the connection string.
        /// </summary>
        /// <value>The connection string.</value>
        public string ConnectionString { get; }
    }
}
