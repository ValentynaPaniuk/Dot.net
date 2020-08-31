using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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

namespace _03_AddStudentInDB
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*На вікно зчитати у лістбокс перелік всіх студентів бази даних University
          Додати 3 кнопки:
          Додати студента
          Видалити студента
          Оновити дані про студента
          Коли натискаємо кнопку "Додати" - відкривається дочірнє вікно
          з можливістю вводу необхідних даних (Ім'я, прізвище, група)
          група - комбобокс з НАЗВАМИ груп
          Після заповнення необхідних полів - натискаємо кнопку 
          ОК і студент має додатись у БД
         */
       
        public ObservableCollection<Student> students = new ObservableCollection<Student>(); 
        string sqlExpression; //команда sql буде передаватися
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
        SqlConnection connection = null;

        public MainWindow()
        {
            InitializeComponent();

            builder.AsynchronousProcessing = true;
            connection = new SqlConnection(builder.ConnectionString);
           
            //Відкриваємо з'єднання
            try
            {
                connection.Open();
                UpdateCollection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            //
            lb_students.ItemsSource = students; //Прив'язка колекції
                                 
        }
        
        //Метод зчитування даних про студента
        private void ReadDataFromStudent(SqlCommand command)
        {
            students.Clear();
            try
            {
                var reader = command.BeginExecuteReader(ReaderCallback, command);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }



        private void ReaderCallback(IAsyncResult ar)
        {
            var result = (SqlCommand)ar.AsyncState;
            var reader = result.EndExecuteReader(ar);

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Dispatcher.Invoke(() =>
                    {
                        students.Add(new Student
                        {
                            IdStudent = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Surname = reader.GetString(2),
                            IdGroup = reader.GetValue(3) as Nullable<int>
                        });
                    });
                }
            }

            reader.Close();
        }


        //Оновлюємо дані про студентів
        private void UpdateCollection()
        {

            sqlExpression = "Select * from Student"; //sql вираз
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection); //створюємо команду для sql виразу 
            ReadDataFromStudent(sqlCommand);
        }

        private void Click_Add(object sender, RoutedEventArgs e)
        {
            AddStudent  windowAddStudent = new AddStudent(new Student(), true, connection);

            if (windowAddStudent.ShowDialog() == true)
                sqlExpression = "Select * from Student";
            SqlCommand sqlCommand = new SqlCommand(sqlExpression, connection);
            UpdateCollection();


        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            //Якщо немає виділеного студента
            if (lb_students.SelectedIndex == -1)
                return;

            //інакше
            Student st = students[lb_students.SelectedIndex];
            SqlCommand command = new SqlCommand($"Delete Student Where Id = {st.IdStudent}", connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            UpdateCollection();
        }



        private void Click_Update(object sender, RoutedEventArgs e)
        {
            // //Якщо немає виділеного стурента
            if (lb_students.SelectedIndex == -1)
                return;

            //інакше
            AddStudent window1 = new AddStudent(students[lb_students.SelectedIndex], false, connection);
            if (window1.ShowDialog() == true)
                UpdateCollection();
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connection.Close();
        }

    }
}
