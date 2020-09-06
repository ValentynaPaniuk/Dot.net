using _10_CodeFirst_.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CodeFirst_.Initializer
{
    public class ShopInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        //Запускається коли ми робимо міграцію
        protected override void Seed(ApplicationContext context)
        {
            var addresses = new List<Address>()
            {
                new Address { Country="Ukraine", City="Kyiv", Street="Nazalejnosti", Builder=5},
                new Address { Country="France", City="Paris", Street="Lafit", Builder=88},
                new Address { Country="Italy", City="Rome", Street="Via della Conciliazione", Builder=12},
                new Address { Country="United Kingdom", City="London", Street="Beach Boulevard, Aberdeen", Builder=1},
                new Address { Country="Poland", City="Warsaw", Street="Maja", Builder=9},
               
            };

            var categories = new List<Category>()
            {
                new Category { NameCategory = "Fashion" },
                new Category { NameCategory = "Hobby" },
                new Category { NameCategory = "Electronics" },
                new Category { NameCategory = "Food" },
                new Category { NameCategory = "Furniture" },
            };

            var clients = new List<Client>
            {
                new Client { NameClient = "Alla Sulhuk"},
                new Client { NameClient = "Iryna Tsygan"},
                new Client { NameClient = "Dasha Tkachuk"},
                new Client { NameClient = "Tania Kovalchuk"},
                new Client { NameClient = "Sergiy Paniuk"},
            };

            var manufactures = new List<Manufacture>
            {
                new Manufacture {NameManufacture="Trembita", Address=addresses.FirstOrDefault(x=>x.Country=="Ukraine")},
                new Manufacture {NameManufacture = "Actimel", Address=addresses.FirstOrDefault(x=>x.Country=="France")},
                new Manufacture {NameManufacture = "Livestock (beer)", Address=addresses.FirstOrDefault(x=>x.Country=="Poland")},
                new Manufacture {NameManufacture="Feretti e Feretti",Address=addresses.FirstOrDefault(x=>x.Country=="Italy")} ,
            };

            var products = new List<Product>()
            {
                 new Product{ NameProduct = "Beer", Price=38, Category=categories.FirstOrDefault(x=>x.NameCategory=="Food"), IsLegal=true, Manufacture=manufactures.FirstOrDefault(x=>x.NameManufacture=="Livestock (beer)") },
                 new Product{ NameProduct = "Doll", Price=360, Category=categories.FirstOrDefault(x=>x.NameCategory=="Hobby"), IsLegal=true, Manufacture=manufactures.FirstOrDefault(x=>x.NameManufacture=="Trembita") },
                 new Product{ NameProduct = "Wardrobe", Price=360, Category=categories.FirstOrDefault(x=>x.NameCategory=="Furniture"), IsLegal=false, Manufacture=manufactures.FirstOrDefault(x=>x.NameManufacture=="Feretti e Feretti") },
            };

            var order1 = new Order
            {
                Date = new DateTime(2008, 3, 15),
                Client = clients.FirstOrDefault(x => x.NameClient == "Alla Sulhuk"),
                Count = 2,
                Address = addresses.FirstOrDefault(x => x.Country == "Ukraine")
            };
            order1.Products.Add(products.FirstOrDefault(x=>x.NameProduct=="Beer"));
            //order1.TotalPrice = order1.Count * order1.Products.DefaultIfEmpty(x=>x.);

            var order2 = new Order
            {
                Date = new DateTime(2020, 2, 22),
                Client = clients.FirstOrDefault(x => x.NameClient == "Iryna Tsygan"),
                Count = 1,
                Address = addresses.FirstOrDefault(x => x.Country == "Italy")
            };

            order2.Products.Add(products.FirstOrDefault(x => x.NameProduct == "Doll"));


            var order3 = new Order
            {
                Date = new DateTime(2020, 5, 18),
                Client = clients.FirstOrDefault(x => x.NameClient == "Dasha Tkachuk"),
                Count = 5,
                Address = addresses.FirstOrDefault(x => x.Country == "Poland")
            };
            order3.Products.Add(products.FirstOrDefault(x => x.NameProduct == "Wardrobe"));

                       
            context.Addresses.AddRange(addresses);
            context.Categories.AddRange(categories);
            context.Clients.AddRange(clients);
            context.Manufactures.AddRange(manufactures);
            context.Products.AddRange(products);
            context.Orders.Add(order1);
            context.Orders.Add(order2);
            context.Orders.Add(order3);

            context.SaveChanges();

            

            base.Seed(context);
        }
    }
}
