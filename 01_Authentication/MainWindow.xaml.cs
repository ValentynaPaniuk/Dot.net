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
        SqlConnection connection = null;
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
                tb_ip.Visibility = Visibility;
            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //===================Windows Authentication
                if (cb.SelectedIndex == 0)
                {
                  //  MessageBox.Show("Windows Authentication");

                    string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                        Initial catalog=master;
                                        Integrated Security=true;";
                    ConnectToServer(connectionString);

                }
                //===================Server Authentication
                else if (cb.SelectedIndex == 1)
                {
                   // MessageBox.Show("Server Authentication");
                    string connectionString = @"Data Source={0};Initial Catalog=master;
                                        Integrated Security=false; User Id={1}; Password={2}";

                    //string connectionString = @"Data Source=194.44.93.225;Initial Catalog=University;
                    //                    Integrated Security=false; User Id=test; Password=1";

                    connectionString = String.Format(connectionString, tb_ip.Text, tb_log.Text, tb_password.Text);
                    ConnectToServer(connectionString);
                }
                else
                {
                    MessageBox.Show("Error!!! Make your choice");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConnectToServer(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                FillDatabases(connection);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private List<string> MakeQuery(SqlConnection connection, string table)
        {
            List<string> results = new List<string>();
            string commandText = $"select name from {table}";
            SqlCommand command = new SqlCommand(commandText, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    results.Add(reader.GetString(0));
                }
            }
            reader.Close();
            return results;
        }

        private void Cb_db_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedDb = cb_db.SelectedItem.ToString();
            FillTables(selectedDb);

        }


        //Додаємо всі БД в комбобокс
        private void FillDatabases(SqlConnection connection)
        {
            var res = MakeQuery(connection, "sys.databases");
            foreach (var item in res)
            {
                cb_db.Items.Add(item);
            }


        }

        // //Додаємо всі таблиці в комбобокс
        private void FillTables(string selectedDb)
        {
            connection.ChangeDatabase(selectedDb);
            var res = MakeQuery(connection, "sys.tables");
            foreach (var item in res)
            {
                cb_table.Items.Add(item);
            }
        }

        private void FillColumns(string selectedTable)
        {
            string nameColumn = "";

            int line = 0;
            string commandText = $"select * from {selectedTable}";
            SqlCommand command = new SqlCommand(commandText, connection);

            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            nameColumn = "";
                            if (line == 0)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    nameColumn += $"{ reader.GetName(i)}\t";
                                }
                            }
                            nameColumn += $"\n";
                            lb_column.Items.Add(nameColumn);
                            ++line;
                            nameColumn = "";

                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                nameColumn += ($"[{reader.GetValue(i)}]\t");
                            }

                            lb_column.Items.Add(nameColumn);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void Cb_table_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedTable = cb_table.SelectedItem.ToString();
           // MessageBox.Show($"Selected table: { selectedTable}");
            FillColumns(selectedTable);


        }



        //private void Up_Click(object sender, RoutedEventArgs e)
        //{
        //    scroll.LineUp();
        //}

        //private void Down_Click(object sender, RoutedEventArgs e)
        //{
        //    scroll.LineDown();
        //}

    }
}
