namespace ADO_EF_StoreLib.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ADO_EF_StoreLib.Configuration;

    public class StoreContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ContextConfiguration());
        }
        public StoreContext()
            : base("name=StoreContext")
        {
            Database.SetInitializer<StoreContext>(new CreateDatabaseIfNotExists<StoreContext>());
        }
    }
}