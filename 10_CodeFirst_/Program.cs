using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CodeFirst_
{
    //Створюємо папку Entities
    //Додаємо туди класи
    //Інсталюємо EF, або створюємо клас ApplicationContext і обираємо Порожня модель CodeFirst
    //Додаємо туди DbSet
    //Створюємо клас ShopInitializer : DropCreateDatabaseAlways<ApplicationContext> 
    //Прописуємо override метод Seed() і заповнюємо таблиці даними
    //Додаємо дані до context
    //В ApplicationContext додаємо в конструктор метод Database.SetInitializer(new ShopInitializer());
       



    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            foreach (var item in context.Orders)
            {
                Console.WriteLine($"{item.Client.NameClient} {item.Count}");
            }
        }
    }
}
