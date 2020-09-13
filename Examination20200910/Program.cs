using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination20200910
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

            DataClassesDataContext context = new DataClassesDataContext(connectionString);

            //Показати історію замовлень певного користувача
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.1 Order history of a specific user");
            var sale = context.Orders.Where(x => x.Clients.NameClient == "Alla Sulhuk");

            ShowSale(sale);

            //Показати історію замовлень певного користувача за певний період
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.2 Order history of a certain user for a certain period (February 2020)");
            DateTime start = new DateTime(2020, 2, 1);
            DateTime end = new DateTime(2020, 2, 28);
            var sale1 = context.Orders.Where(x => x.Clients.NameClient == "Iryna Tsygan" && (x.Date >= start && x.Date <= end));
            ShowSale(sale1);

            //вивести всі замовлення за вчора
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.3 All orders for yesterday");
            var sale2 = context.Orders.Where(x => x.Date.Equals(DateTime.Now));
            ShowSale(sale2);

            //вивести всі замовлення до Італії
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.4 All orders to Italy");
            var sale3 = context.Orders.Where(x => x.Address_Id == 4);
            ShowSale(sale3);

            //вивести всі продукти польських виробників
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.5 All products of Poland manufacturers");
            var products = context.Products.Where(x => x.Manufactures.Address_Id == 3);
            ShowProduct(products);

            //вивести всі адреси потужностей виробника конкретного товару
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.6 Addresses of capacities of the manufacturer of 'Livestock(beer)'");
            //var manufacture1 = context.Manufactures.Where(x=>x.Products.)
            
            //ShowAddress(address);

            //Вивести всі країни виробників і без повторів.
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.7 Country of origin and without repetition.");
            var manufactures = context.Manufactures.Distinct();

            ShowManufacture(manufactures);

            //Вивести користувачів з максимальною сумою замовлення.
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.8 Users with the maximum order amount.");
            var maxOrders = context.Orders.Max(x => x.Count);
            Console.WriteLine($"Maximum order Amount: {maxOrders}");

         
            var clients = context.Clients.Where(x=>x.Orders.Count==maxOrders) ;
            

            foreach (var item in clients)
            {
                Console.WriteLine($"{item.NameClient}");
            }

            //Вивести емейл користувачів, що замовляли inllegal продукти
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.9 Email users who have ordered inllegal products");
            var inleggalProduct = context.Products.Where(x => x.IsLegal == false);
           
            Console.WriteLine("Inleggal product");
            foreach (var item in inleggalProduct)
            {
                Console.WriteLine($"{item.NameProduct}");
            }

           


            //Вивести перелік замовлень, які необхідно доставити по адресах, які містять к - сть літер більше 1 в додатковому полі Коментар таблиці адреса
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.10 List of orders to be delivered to addresses that contain more than 1 letter in the additional field Comment table address");


            //Вивести перелік користувачів, які отримають продукти, термін придатності яких закінчиться 1.04.19
            Console.WriteLine("=============================================================");
            Console.WriteLine("1.11 List of users who will receive products whose expiration date expires on 1.04.19");

        }

        private static void ShowManufacture(IQueryable<Manufactures> manufactures)
        {
            foreach (var item in manufactures)
            {
                Console.WriteLine($"{item.NameManufacture} {item.Addresses.Country} {item.Addresses.City}");
            }
        }

        private static void ShowAddress(IQueryable<Addresses> address)
        {
            foreach (var item in address)
            {
                Console.WriteLine($"{item.Country} {item.City} {item.Street} {item.Builder}");
            }
        }

        private static void ShowProduct(IQueryable<Products> product)
        {
            foreach (var item in product)
            {
                Console.WriteLine($"{item.NameProduct} {item.Categories.NameCategory} {item.Manufactures.NameManufacture}");
            }
        }

        private static void ShowSale(IQueryable<Orders> sale)
        {
            foreach (var item in sale)
            {
                Console.WriteLine($"{item.Date} {item.Clients.NameClient} {item.Count} ");
            }
        }

    }
    
}
