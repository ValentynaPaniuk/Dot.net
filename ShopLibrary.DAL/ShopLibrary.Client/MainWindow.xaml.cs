using ShopLibrary.BLL.Services;
using System;
using System.Collections.Generic;
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

    //25. Копіюємо StringConnrction з App.config (classLibrary.DAL) в App.config (ShopLibrary.Client)





    public partial class MainWindow : Window
    {
        private readonly IShopService service;
        public MainWindow()
        {
            InitializeComponent();
            service = new ShopService();
            this.DataContext = service.GetOrders().ToList();
        }
    }
}
