using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Linq_to_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;

            DataClasses1DataContext context = new DataClasses1DataContext(connectionString);

            //Інсталюємо LINQ to SQL tools через Installer VS

            // 1.Вибрати всі книги, кількість сторінок в яких більше 100
            var books = context.Books.Where(x => x.Pages > 100);
            
            ReadBooks(books);
            // 2.Вибрати всі книги, ім'я яких починається на літеру 'А' або 'а
            var books1 = context.Books.Where(x => x.Name.ToLower().StartsWith("a"));
            ReadBooks(books1);
            // 3.Вибрати всі книги автора William Shakespeare
            var books2 = context.Books.Where(x => x.Author.Name == "R.S.Martin");
            ReadBooks(books2);

            // 4.Вибрати всі книги українських авторів

            // 5.Вибрати всі книги, ім'я в яких складається менше ніж з 10-ти символів
            var books3 = context.Books.Where(x => x.Name.Length < 10);
            ReadBooks(books3);

            // 6.Вибрати книгу з максимальною кількістю сторінок не американського автор
            var books4 = context.Books.Where(x => x.Pages == (context.Books.Select(y => y.Pages)).Max());
            ReadBooks(books4);

            // 7.Вибрати автора, який має найменше книг в базі даних
            var books5 = context.Authors.Where(x => x.Books.Count == (context.Authors.Select(y => y.Books.Count)).Min());
            ReadAuthors(books5);

            // 8.Вибрати імена всіх авторів, крім американських, розташованих в алфавітном порядку
            var books6 = context.Authors.OrderBy(x => x.Name);
            ReadAuthors(books6);

            // 9.Вибрати країну, авторів якої є найбільше в базі
           
            //=======================================================
            //=======================================================



            int[] values1 = new int[5] { 1, 10, 5, 13, 4 };
            int[] values2 = new int[5] { 19, 1, 4, 9, 8 };
            //1) Посчитать среднее значение четных элементов, которые больше 10.
            var avg = values1.Concat(values2).Where(x => x % 2 == 0).Average();
            Console.WriteLine($"2.1.The average value of even elements that are greater than 10 = {avg}");
            Console.WriteLine();
            //2) Выбрать только уникальные элементы из массивов values1 и values2.
            var uniqueNumbers = values1.Concat(values2).GroupBy(i => i).Where(i => i.Count() == 1).Select(i => i.Key);
            Console.WriteLine($"2.2.unique elements from the arrays values1 and values2: ");

            foreach (var item in uniqueNumbers)
            {
                Console.Write($"{item}    ");
            }
            Console.WriteLine();
            Console.WriteLine();
            //3) Найти максимальный элемент массива values2, который есть в массиве values1.


            //4) Посчитать сумму элементов массивов values1 и values2, которые попадают в диапазон от 5 до 15.
            var sumValues1Values2 = values1.Concat(values2).Where(x => x>=5 && x <= 15).Sum();
            Console.WriteLine($"2.4. The sum of arrays (> 5 and < 15) = {sumValues1Values2}");
            Console.WriteLine();
            //5) Отсортировать элементы массивов values1 и values2 по убыванию.

            var sort = values1.Concat(values2).OrderByDescending(x => x);
            Console.WriteLine($"2.5. Sort the elements of the values1 and values2 arrays in descending order:");
            foreach (var item in sort)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();


            List<Good> goods1 = new List<Good>()
            {
            new Good() { Id = 1, Title = "Nokia 1100", Price = 450.99, Category = "Mobile" },
            new Good() { Id = 2, Title = "Iphone 4", Price = 5000, Category = "Mobile" },
            new Good() { Id = 3, Title = "Refregirator 5000", Price = 2555, Category = "Kitchen" },
            new Good() { Id = 4, Title = "Mixer", Price = 150, Category = "Kitchen" },
            new Good() { Id = 5, Title = "Magnitola", Price = 1499, Category = "Car" }
            };

            List<Good> goods2 = new List<Good>()
            {
            new Good() { Id = 6, Title = "Samsung Galaxy", Price = 3100, Category = "Mobile" },
            new Good() { Id = 7, Title = "Auto Cleaner", Price = 2300, Category = "Car" },
            new Good() { Id = 8, Title = "Owen", Price = 700, Category = "Kitchen" },
            new Good() { Id = 9, Title = "Siemens Turbo", Price = 3199, Category = "Mobile" },
            new Good() { Id = 10, Title = "Lighter", Price = 150, Category = "Car" }
            };


            //Рассматривать как одну коллекцию.
            var goods = goods1.Concat(goods2);

            Console.WriteLine();

            //1) Выбрать товары категории Mobile, цена которых превышает 1000 грн.
            var mobile = goods1.Concat(goods2).Where(x => x.Price > 1000 && x.Category=="Mobile");
            
            Console.WriteLine($"3.1 Products of the category Mobile, the price of which exceeds 1000 UAH.");
            foreach (var item in mobile)
            {
                Console.WriteLine($"      {item.Id} {item.Title} {item.Price} {item.Category}");
            }
            //2) Вывести название и цену тех товаров, которые не относятся к категории Kitchen и цена которых превышает 1000 грн.
            Console.WriteLine($"3.2 The name and price of those goods that do not belong to the Kitchen category and whose price exceeds 1000 UAH. ");
            var good = goods.Where(x => x.Category != "Kitchen" && x.Price > 1000);
            foreach (var item in good)
            {
                Console.WriteLine($"      {item.Id} {item.Title} {item.Price} {item.Category}");
            }
            Console.WriteLine();

            //3) Вывести название товара и его категорию, который имеет максимальную цену.
            var maxPrice = goods.Where(x => x.Price == goods.Select(y => y.Price).Max());
            Console.WriteLine($"3.3 The name of the product and its category that has the maximum price: {maxPrice} ");


            //4) Вычислить среднее значение всех цен товаров.
            var average = goods.Average(x => x.Price);
            Console.WriteLine($"3.4 The average of all prices of goods: {average}");
            Console.WriteLine();

            //5) Вывести список категорий без повторений.
            Console.WriteLine($"3.5 List of categories without repetitions. ");
            var names = goods.Select(x => x.Category).Distinct();
            foreach (var item in names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //6) Вывести названия тех товаров, цены которых совпадают.
            Console.WriteLine($"3.6 The names of those goods whose prices are the same.");
            var product = goods.Where(x => goods.Count(y => y.Price == x.Price) > 1);
            foreach (var item in product)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //7) Вывести названия и категории товаров в алфавитном порядке, упорядоченных по названию.
            Console.WriteLine($"3.7 Names and categories of products in alphabetical order, sorted by name.");
            var sorting = goods.OrderBy(x => x.Title);
            foreach (var item in sorting)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //8) Проверить, содержит ли категория Car товары, с ценой от 1000 до 2000 грн.
            Console.WriteLine($"3.8 Check if the Car category contains goods priced from 1000 to 2000 UAH.");
            ReadGoods(goods.Where(x => x.Category == "Car" && (x.Price >= 1000 && x.Price <= 2000)));

            //9) Посчитать суммарное количество товаров категорий Сar и Mobile.
            Console.WriteLine($"3.9 The total number of goods in the Сar and Mobile categories. ");
            Console.WriteLine(goods.Where(x => x.Category == "Car" || x.Category == "Mobile").Count());
            //10) Вывести список категорий и количество товаров каждой категории.
            Console.WriteLine($"3.10 ");
            var categories = goods.Select(x => x.Category).Distinct();

            foreach (var item in categories)
            {
                Console.WriteLine($"{item} = {goods.Where(x => x.Category == item).Count()}");
            }

        }

        class Good
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public double Price { get; set; }
            public string Category { get; set; }

            public override string ToString()
            {
                return $"{Id}.{Title} | {Price} | {Category}";
            }
        }

        private static void ReadGoods(IEnumerable goods)
        {
            foreach (var item in goods)
            {
                Console.WriteLine(item);
            }
        }

        private static void ReadBooks(IQueryable<Book> books)
        {
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Desc} | {item.Year} | {item.Pages} | {item.Author.Name} | {item.Genre.Name}");
            }
        }

        private static void ReadAuthors(IQueryable<Author> books)
        {
            foreach (var item in books)
            {
                Console.WriteLine($"{item.Id} | {item.Name} ");
            }
        }

    }


}


