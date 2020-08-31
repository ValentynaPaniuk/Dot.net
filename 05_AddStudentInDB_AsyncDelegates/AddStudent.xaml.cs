using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace _03_AddStudentInDB
{
    /// <summary>
    /// Логика взаимодействия для AddStudent.xaml
    /// </summary>
    public partial class AddStudent : Window
    {
        
        List<Group> groups = new List<Group>(); //Список всіх груп
        SqlConnection connection_AddStudent; //Створюємо з'єднання
        public Student student { get; set; } //Створюємо студента
        bool addNew; //Перевірка чи додати чи видалити

        //Конструктор
        public AddStudent(Student student, bool addNew, SqlConnection connection)
        {
            InitializeComponent();

            this.addNew = addNew;
            this.student = student;
            this.connection_AddStudent = connection;

            ReadDataFromGroups(new SqlCommand("Select * from Groups", connection_AddStudent));

            cb_Groups.ItemsSource = groups;
            if (!addNew)
            {
                tb_Name.Text = student.Name;
                tb_Surname.Text = student.Surname;
                cb_Groups.SelectedIndex = groups.FindIndex(x => x.ID == student.IdGroup);
            }
        }

        private void ReadDataFromGroups(SqlCommand command)
        {
            command.BeginExecuteReader(ReaderCallback, command);
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
                        groups.Add(new Group
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    });
                }
            }

            reader.Close();
        }


        //Метод додавання студента
        private void AddStudents()
        {
            SqlCommand command = new SqlCommand($"insert into student values(@name, @surname, @idGroup)", connection_AddStudent);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@surname", student.Surname);
            command.Parameters.AddWithValue("@idGroup", student.IdGroup);
            command.BeginExecuteReader();
        }

        private void UpdateStudents()
        {
            SqlCommand command = new SqlCommand($"update student set Name = @name, Surname = @surname, IdGroup = @idGroup where id = @id", connection_AddStudent);
            command.Parameters.AddWithValue("@id", student.IdStudent);
            command.Parameters.AddWithValue("@name", student.Name);
            command.Parameters.AddWithValue("@surname", student.Surname);
            command.Parameters.AddWithValue("@idGroup", student.IdGroup);
            command.BeginExecuteReader();
        }


        private void Bt_Add_Click(object sender, RoutedEventArgs e)
        {
            //student = student ?? new Student(); //Перевірка на нуль
            if (student == null)
                student = new Student();

            //Перевіряємо чи всі поля заповнені
            if (String.IsNullOrWhiteSpace(tb_Name.Text) || String.IsNullOrWhiteSpace(tb_Surname.Text) || cb_Groups.SelectedIndex == -1)
                return;


            student.Name = tb_Name.Text;
            student.Surname = tb_Surname.Text;
            string groupName = cb_Groups.SelectedItem.ToString();
            student.IdGroup = groups.Find(x => x.Name == groupName).ID;

            if (addNew)
                AddStudents();
            else
                UpdateStudents();

            this.DialogResult = true;

        }
    }
}
