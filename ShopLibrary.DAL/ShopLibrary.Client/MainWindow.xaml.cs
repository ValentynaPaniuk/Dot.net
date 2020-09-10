using Autofac;
using ShopLibrary.BLL.Model;
using ShopLibrary.BLL.Services;
using ShopLibrary.DAL;
using ShopLibrary.DAL.Entities;
using ShopLibrary.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace ShopLibrary.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    //1. Створюємо classLibrary.DAL
    //2. Створюємо classLibrary.BLL
    //3. Створюємо вікно ShopLibrary.Client WPF(UI,Client)
    //4. Видаляємо порожні класи, що створюються в DAL+BLL

    //===============   DAL  ====================================
    //5. В classLibrary.DAL створюємо папку Entities
    //6. Додаємо класи необхідні для роботи (з foreign key)
    //7. Створюємо model ApplicationContext
    //8. Додаємо DbSet in ApplicationContext
    //9. Створюємо папку Initializer і в ній клас ShopInitializer : DropCreateDatabaseIfModelChanges<ApplicationContext>
    //10. Робимо override Seed() в якому додаємо об'єкти в класи і приєднуємо все до context і робимо context.SaveChange;
    //11. В constructor ApplicationContext передаємо  Database.SetInitializer(new ShopInitializer());
    //12. В App.config міняємо назву БД
    //13. Створюємо папку Repository і в ній Interface ( public interface IGenericRepository<TEntity> where TEntity : class) і клас public class (EFRepository <TEntity> : IGenericRepository <TEntity> where TEntity : class)   де опис методів, які будуть працювати в БД
    //14. В EFRepository:
    //          public readonly DbContext context;
    //          public EFRepository()
    //          {
    //          context = new ApplicationContext();
    //          }
    //15. В IGenericRepository<TEntity> пишемо методи, що доступні в нашій БД (Create, Read, Delete, Update)
    //16. В EFRepository реалізуємо IGenericRepository<TEntity> (public class EFRepository <TEntity> : IGenericRepository <TEntity> where TEntity : class)
    //17. І реалізуємо всі методи інтерфейсу (створюємо там додаткове поле  private readonly DbSet<TEntity> set; + в конструкторі робимо  set = context.Set<TEntity>();)

    //=======================================BLL=============================================
    //18. Створюємо папку Services в ній інтерфейс IShopService і клас ShopService
    //19. В IShopService пишемо методи, що доступні клієнту  IEnumerable<Order> GetOrders();
    //20. Реалізуємо ці методи в ShopService і створюємо об'єкти IGenericRepository<Order> repo і в констукторі repo = new EFRepository<Order>();
    //       private readonly IGenericRepository<Order> repo;
    //       public ShopService()
    //        {
    //           repo = new EFRepository<Order>();
    //       }
    //21. ShopLibrary.DAL робимо ctrl+Shift+B(Сборка -> Собрать решение)
    //================================Client===================================================
    //22. Створили DataGrid  на вікні і прив'язали ItemSource{Binding}
    //23. Створити поле private readonly IShopService service і в конструкторі зробити -  service = new ShopService();
    //24. Прив'язати DataContext в конструкторі -  this.DataContext = service.GetOrders().ToList();

    //25. Копіюємо StringConnection з App.config (classLibrary.DAL) в App.config (ShopLibrary.Client)
    //26. Install Entity Framework

    //===========================DAL================================
    //27. Створюємо папку Model і в ній клас BookDTO(для переміщення об'єктів між БД і IU)
    //28. Редагуємо IShopService (колекція IEnumerable<BookDTO> GetOrders() буде вертати BookDTO)
    //29. Редагуємо метод GetOrders() в BookServise теж редагуємо - вертає BookDTO
    //      public IEnumerable<OrderDTO> GetOrders()
    //      {
    //          return repo.GetAll();
    //      }
    //      

    public partial class MainWindow : Window
    {
        private readonly IShopService service;

        public ObservableCollection<OrderDTO> Orders { get; set; } = new ObservableCollection<OrderDTO>();

        public MainWindow(IShopService shopService)
        {
            InitializeComponent();
            service = shopService;
            UpdateOrders(shopService);
            this.DataContext = Orders;

            

        }

        private void UpdateOrders(IShopService shopService)
        {
            Orders.Clear();
            var temp = shopService.GetOrders();
            foreach (var item in temp)
            {
                Orders.Add(item);
            }
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {

            OrderWindow orderWindow = new OrderWindow(new OrderDTO(), true);
            if (orderWindow.ShowDialog() == true)
                     
            UpdateOrders(service);

        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            if (dg.SelectedIndex == -1)
                return;

        }

        private void Click_Update(object sender, RoutedEventArgs e)
        {
            Orders.Clear();
            var temp = service.GetOrders();
            foreach (var item in temp)
            {
                Orders.Add(item);
            }
        }
    }
}
