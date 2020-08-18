using System;
using System.Collections.Generic;
using System.Data;
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

namespace _01_Authentication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        /*Вікно
Випадаючий список з вибором режиму аутентифікації (віндовс чи сервер)
Якщо вибрали сервер - то ввести логін та пароль, а також адресу сервера
Після того як натиснути кнопку Підключитись - знизу у список (ListBox) 
вивести перелік доступних БД
         */


        private void Cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb.SelectedIndex == 1)
            {
                tb_log.Visibility = Visibility;
                tb_password.Visibility = Visibility;
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cb.SelectedIndex == 0)
            {
                MessageBox.Show("Windows Authentication");

                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial catalog=master;
                                        Integrated Security=true;";
              
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        
                        string commandText = "select name from sys.databases";
                        SqlCommand command = new SqlCommand(commandText, connection);
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                lb_db.Items.Add(reader.GetString(0));
                            }
                        }
                        reader.Close();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }
            else if (cb.SelectedIndex == 1)
            {               
                MessageBox.Show("Server Authentication");
                
                {
                    string connectionString = @"Data Source=194.44.93.225;Initial Catalog=master;
                                        Integrated Security=false; User Id=test; Password=1";


                

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        try
                        {
                            connection.Open();

                            string commandText = "select name from sys.databases";
                            SqlCommand command = new SqlCommand(commandText, connection);
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    lb_db.Items.Add(reader.GetString(0));
                                }
                            }
                            reader.Close();

                        }
                        catch (SqlException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
             

            }
            else
            {
                MessageBox.Show("Error!!! Make your choice");
            }
        }


        private void Up_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineUp();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            scroll.LineDown();
        }

    }
}
