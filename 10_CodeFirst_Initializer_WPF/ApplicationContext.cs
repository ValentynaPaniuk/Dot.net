namespace _10_CodeFirst_Initializer_WPF
{
    using _10_CodeFirst_Initializer_WPF.Entities;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationContext : DbContext
    {
        // Контекст настроен для использования строки подключения "ApplicationContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "_10_CodeFirst_Initializer_WPF.ApplicationContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "ApplicationContext" 
        // в файле конфигурации приложения.
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
            Database.SetInitializer(new ShopInitializer());
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }


        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}