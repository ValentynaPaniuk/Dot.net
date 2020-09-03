using _09_CodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Інсталюємо EF
            //2. Створюємо Entities (All tables+ApplicationContext)
            //3. ApplicationContext must have :DbContext+Ctor+DbSets from all Entities
            //4. Правка - Інші вікна - Консоль диспетчера пакетів
            //  -enable-migrations   ==>Підключаємо міграції
            //  -add-migration "Name migration"  ==>Додаємо міграцію
            //  -update-database  ==> Оновлюємо базу після міграції
            //5. Створюємо ApplicationContext


            ApplicationContext context = new ApplicationContext();
            context.Database.Log = Logger;

            //Add new product
            Address _AudiAG = new Address { Country = "Germany", City = "Ingolstadt", Street = "Godstreet", Builder = 1 };
            Address _Sony = new Address { Country = "USA", City = "California", Street = "GoldStreet", Builder = 5 };
            context.Addresses.Add(_AudiAG);
            context.Addresses.Add(_Sony);
            context.SaveChanges();


            Category auto = new Category { NameCategory = "Car" };
            Category comp = new Category { NameCategory = "Computer and Audi" };
            context.Categories.Add(auto);
            context.Categories.Add(comp);
            context.SaveChanges();



            Manufacture manufacture_Germany = new Manufacture { NameManufacture = "Audi AG", Address=_AudiAG };
            Manufacture manufacture_USA = new Manufacture { NameManufacture = "Sony"};
            //context.Manufactures.Add(manufacture_Germany);
            //context.Manufactures.Add(manufacture_USA);
            //context.SaveChanges();

            Product product = new Product { NameProduct = "Audi", Price = 30000, Category = auto, IsLegal = true, Manufacture = manufacture_Germany };
            //Product product = new Product { NameProduct = "Leptop", Price = 12000, Category = comp, IsLegal = false, Manufacture = manufacture_USA };

            //context.Products.Add(product);
            //context.SaveChanges();
            PrintProducts(context.Products.ToList());

            //Add Client
            var clients = new List<Client>()
            {
                    new Client {NameClient="Ivan Petrov"},
                    new Client {NameClient="Olga Kolosova"},
                    new Client {NameClient="Sergiy Kozliuk"},
                    new Client {NameClient="Kostia Sahaychuk"}
            };
            //context.Clients.AddRange(clients);
            //context.SaveChanges();
            PrintClients(context.Clients.ToList());

            Address address_cl1 = new Address { Country = "Ukraine", City = "Rivne", Street = "Soborna", Builder = 202 };
            //Address address_cl1 = new Address { Country = "Ukraine", City = "Kyiv", Street = "Nezalejnosti", Builder = 15 };
            //context.Addresses.Add(address_cl1);
            //context.SaveChanges();

            //Order order = new Order { Date= new DateTime(2008, 3, 15), Client= context.Clients.FirstOrDefault(x => x.NameClient.Equals("Ivan Petrov")), Address=context.Addresses.FirstOrDefault(x=>x.City.Equals("Ukraine") && x.City=="Rivne"), Product=context.Products.FirstOrDefault(x=>x.NameProduct.Equals("Leptop")), Count =3 };
            Order order = new Order { Date= new DateTime(2020, 3, 15), Client= context.Clients.FirstOrDefault(x => x.NameClient.Equals("Olga Kolosova")), Address = context.Addresses.FirstOrDefault(x => x.City.Equals("Ukraine") && x.City == "Rivne"), Product=context.Products.FirstOrDefault(x=>x.NameProduct.Equals("Audi")), Count =1 };
            //Order order = new Order { Date= new DateTime(2018, 2, 22), Client= context.Clients.FirstOrDefault(x => x.NameClient.Equals("Sergiy Kozliuk")), Address=address_cl1, Product=context.Products.FirstOrDefault(x=>x.NameProduct.Equals("Leptop")), Count =1 };
           context.Orders.Add(order);
            //context.SaveChanges();
           order.TotalPrice = order.Count * order.Product.Price;
           context.Orders.Add(order);
           context.SaveChanges();

            //PrintOrders(context.Orders.ToList());

        }


        private static void Logger(string obj)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(obj);
            Console.ForegroundColor = ConsoleColor.White;
        }


        private static void PrintProducts(ICollection<Product> products)
        {
            foreach (var item in products)
            {
                try
                {
                    Console.WriteLine($"{item.NameProduct}, {item.Price}," +
                        $" Manufacture - {item.Manufacture.NameManufacture}, IsLegal - {item.IsLegal}");
                }
                catch { }
            }
        }

        private static void PrintClients(ICollection<Client> clients)
        {
            foreach (var item in clients)
            {
                try
                {
                    Console.WriteLine($"{item.NameClient}");
                }
                catch { }
            }
        }

        private static void PrintOrders(ICollection<Order> orders)
        {
            foreach (var item in orders)
            {
                try
                {
                    Console.WriteLine($"{item.Date}, {item.Client}," +
                        $" Count - {item.Count} {item.Product}");
                }
                catch { }
            }
        }




    }
}
