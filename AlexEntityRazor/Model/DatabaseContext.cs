using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlexEntityRazor.Model
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Service> services { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Contact> Contact { get; set; }

    }
}
