using System;
using System.Collections.Generic;
using System.Data.Common;
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
        DbConnection connection_AddStudent;
        DbProviderFactory factory;

       // SqlConnection connection_AddStudent; //Створюємо з'єднання
        public Student student { get; set; } //Створюємо студента
        bool addNew; //Перевірка чи додати чи видалити

        //Конструктор
        public AddStudent(Student student, bool addNew, DbConnection connection, DbProviderFactory factory)
        {
            InitializeComponent();

            this.addNew = addNew;
            this.student = student;
            this.connection_AddStudent = connection;

            this.factory = factory;

            DbCommand command = factory.CreateCommand();
            command.CommandText = "Select * from Groups";
            command.Connection = connection_AddStudent;

            ReadDataFromGroups(command);

            cb_Groups.ItemsSource = groups;
            if (!addNew)
            {
                tb_Name.Text = student.Name;
                tb_Surname.Text = student.Surname;
                cb_Groups.SelectedIndex = groups.FindIndex(x => x.ID == student.IdGroup);
            }
        }

        private void ReadDataFromGroups(DbCommand command)
        {
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        groups.Add(new Group
                        {
                            ID = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        });
                    }
                }
            }
        }


        private void AddParameter(DbCommand command, string parameterName, string value)
        {
            DbParameter parameter = factory.CreateParameter();
            parameter.ParameterName = parameterName;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }

        //Метод додавання студента
        private void AddStudents()
        {
            DbCommand command = factory.CreateCommand();
            command.CommandText = $"insert into student values(@name, @surname, @idGroup)";
            command.Connection = connection_AddStudent;

            AddParameter(command, "@name", student.Name);
            AddParameter(command, "@surname", student.Surname);
            AddParameter(command, "@idGroup", student.IdGroup.ToString());

            command.ExecuteNonQuery();
        }

        private void UpdateStudents()
        {
            DbCommand command = factory.CreateCommand();
            command.CommandText = $"update student set Name = @name, Surname = @surname, IdGroup = @idGroup where id = @id";
            command.Connection = connection_AddStudent;

            AddParameter(command, "@id", student.IdStudent.ToString());
            AddParameter(command, "@name", student.Name);
            AddParameter(command, "@surname", student.Surname);
            AddParameter(command, "@idGroup", student.IdGroup.ToString());

            command.ExecuteNonQuery();
        }


        private void Bt_Add_Click(object sender, RoutedEventArgs e)
        {
            student = student ?? new Student();

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
