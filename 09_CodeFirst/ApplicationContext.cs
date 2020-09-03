using _09_CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CodeFirst
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("name=defaultConnection")
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
