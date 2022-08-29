using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSK.Model;

namespace TSK.Data
{
    /// <summary>
    /// Data access context for acessing data entities.
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataContext"/> class.
        /// </summary>
        /// <param name="options">A <see cref="DbContextOptions{DataContext}"/> containing connection information.</param>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the collection that contains <see cref="User"/> entities.
        /// </summary>
        public DbSet<User> User
        {
            get;
            set;
        }
    }
}
