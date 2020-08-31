using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace _06_Library
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    /*Вивести вміст таблиць з БД BookDB
       Вимога: кожна таблиця на окремому TabItem, вміст таблиці має міститись в dataGrid
       Додати кнопки для видалення книжки, збереження даних в xml
     */

    public partial class MainWindow : Window
    {
        enum Functions
        {
            ReadDatabase,
            Delete,
            ReadTable
        }

        string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        SqlConnection connection;
        DataTable table;
        string tableName;

        public MainWindow()
        {
            InitializeComponent();

            InitializeComponent();
            connection = new SqlConnection(connectionString);
            ConnectToDB(new SqlCommand("select name from sys.tables"), Functions.ReadDatabase);
        }


        private void ConnectToDB(SqlCommand command, Functions functions)
        {
            using (connection)
            {
                try
                {
                    connection.ConnectionString = connectionString;
                    connection.Open();

                    command.Connection = connection;

                    switch (functions)
                    {
                        case Functions.ReadTable:
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        for (int i = 0; i < reader.FieldCount; i++)
                                            table.Columns.Add(reader.GetName(i));

                                        do
                                        {
                                            while (reader.Read())
                                            {
                                                DataRow r = table.NewRow();
                                                for (int i = 0; i < reader.FieldCount; i++)
                                                    r[i] = reader[i];
                                                table.Rows.Add(r);
                                            }
                                        } while (reader.NextResult());
                                    }
                                }
                            }
                            break;
                        case Functions.ReadDatabase:
                            {
                                using (SqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            DataGrid grid = new DataGrid();
                                            grid.Name = "grid";
                                            TabItem item = new TabItem();
                                            item.Header = reader["name"];
                                            item.Content = grid;
                                            tabControl.Items.Add(item);
                                        }

                                    }
                                }

                            }
                            break;
                        case Functions.Delete:
                            {
                                command.ExecuteNonQuery();
                                DataRow[] rows = table.Select($"Id = {int.Parse(tb_id.Text)}");

                                if (rows.Length > 0)
                                    rows[0].Delete();
                            }
                            break;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
            
        

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            tableName = (tabControl.SelectedItem as TabItem).Header.ToString();

            if (tableName == "Books")
            {
                btn_del.Visibility = lbl_placeholder.Visibility = tb_id.Visibility = Visibility.Visible;
            }
            else
                btn_del.Visibility = lbl_placeholder.Visibility = tb_id.Visibility = Visibility.Collapsed;

            table = new DataTable();
            table.TableName = tableName;

            ConnectToDB(new SqlCommand($"Select * from {tableName}"), Functions.ReadTable);
            ((tabControl.SelectedItem as TabItem).Content as DataGrid).ItemsSource = table.DefaultView;
        }


        private void Btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_id.Text))
            {
                ConnectToDB(new SqlCommand($"Delete Books where Id = {tb_id.Text}"), Functions.Delete);
            }
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            table.WriteXml($"{tableName}.xml");

        }
    }
}
