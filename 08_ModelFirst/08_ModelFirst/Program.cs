using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Model1Container context = new Model1Container())
            {
                //==========Client
                var clients = new List<Client>()
                {
                    new Client {FullNameClient="Ivan"},
                    new Client {FullNameClient="Olga"},
                    new Client {FullNameClient="Sergiy"},
                    new Client {FullNameClient="Kostia"}
                };

                context.Clients.AddRange(clients);
                context.SaveChanges();


                foreach (var item in context.Clients)
                {
                    Console.WriteLine($"{item.FullNameClient}");
                }

                //==========Category
                var categories = new List<Category>()
                { new Category {Id = 1, NameCategory= "Food and Spirits"},
                  new Category {Id = 2, NameCategory= "Health and Beauty"},
                  new Category {Id = 3, NameCategory=  "Home and Hobby"}
                };

                context.Categories.AddRange(categories);
                context.SaveChanges();

                foreach (var item in context.Categories)
                {
                    Console.WriteLine($"{item.NameCategory}");
                }


                //Products
                var products = new List<Product>()
               {
                new Product{Id = 1, NameProduct="Water"},
                new Product{Id = 2, NameProduct = "Apple"},
                new Product{Id = 3, NameProduct = "Water"},
                new Product{Id = 4, NameProduct = "Bread"},
                new Product{Id = 5, NameProduct = "Shampoo"},
                new Product{Id = 6, NameProduct = "Soap"},

               };

                context.Products.AddRange(products);
                context.SaveChanges();
                

                //Orders
                //var orders = new List<Order>()
                //{
                //    new Order {Id = 1, Date = "2020-08-10", ClientId=1, Products=1},
                //    new Order {Id = 2, Date = "2020-08-11", ClientId=2, Products = 2},
                //    new Order {Id = 3, Date = "2020-08-12", ClientId=3, Products = 3},
                //    new Order {Id = 4, Date = "2020-08-13", ClientId=4, Products = 4},
                //    new Order {Id = 5, Date = "2020-08-14", ClientId=1, Products = 5},
                //    new Order {Id = 6, Date = "2020-08-14", ClientId=2, Products = 4},
                //};

                //context.Orders.AddRange(orders);
                //context.SaveChanges();

                
            

                
            }
        }
    }
}
