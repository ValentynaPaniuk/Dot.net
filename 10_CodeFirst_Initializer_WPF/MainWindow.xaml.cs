using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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

namespace _10_CodeFirst_Initializer_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
                     

        public MainWindow()
        {
            InitializeComponent();
            ApplicationContext context = new ApplicationContext();

            context.Clients.Load();
            dgclients.ItemsSource = context.Clients.Local.ToBindingList();

            context.Products.Load();
            dgproduct.ItemsSource = context.Products.Local.ToBindingList();

            context.Orders.Load();
            dgorders.ItemsSource = context.Orders.Local.ToBindingList();
        }


       
    }
}
