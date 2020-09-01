using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_EF
{
    class Program
    {
        static void Main(string[] args)
        {
            UniversityEntities context = new UniversityEntities();

            //Delete student (Name from keyboard)
            Console.WriteLine("Delete student (Name from keyboard)");
            //Alt+Enter - create function
            PrintContextStudents(context);

            Console.WriteLine();
            try
            {
                Console.WriteLine("Enter Name student for DELETE: ");
                string NameStudent = Console.ReadLine();
                Student st = (Student)context.Students.FirstOrDefault(b => b.Name == NameStudent);

                context.Students.Remove(st);
                context.SaveChanges();
                Console.WriteLine($"You deleted {NameStudent}");
            }
            catch
            {
                Console.WriteLine("Enter correct Name Student");
            }

            Console.WriteLine();

            PrintContextStudents(context);

            //Update Group in Student
            Console.WriteLine("Update Group in Student (Name from keyboard)");
            Console.WriteLine();
            try
            {
                Console.WriteLine("Enter Name Student for UPDATE: ");
                string NameStudent = Console.ReadLine();
                Student st = (Student)context.Students.FirstOrDefault(b => b.Name == NameStudent);
                Console.WriteLine("Enter New Name Group for UPDATE: ");
                string NameGroupNew = Console.ReadLine();
                st.Group.Name = NameGroupNew;
             
                context.SaveChanges();
                Console.WriteLine($"You update {st.Group.Name}");
            }
            catch
            {
                Console.WriteLine("Enter correct Name Student");
            }

            PrintContextStudents(context);


            //Вивести всіх студентів певної групи
            Console.WriteLine("Display all students in a group");
            try 
            {
                Console.WriteLine("Enter Name Group of find : ");
                string NameGroup= Console.ReadLine();

                Console.WriteLine("=====================================");
                Console.WriteLine($"Students of group{NameGroup}: ");
                foreach (var item in context.Students.Where(s=>s.Group.Name==NameGroup))
                    {
                        Console.WriteLine($"{item.Name}  {item.Surname} =====>>>>>  {item.Group.Name}");
                    }

                Console.WriteLine("=====================================");

            }
            catch 
            {
                Console.WriteLine("Enter correct Name Group");
            }



            //Знайти кількість студентів двох груп
            Console.WriteLine("Find the number of students in two groups");

            try 
            {
                Console.WriteLine("Enter First Group Name of find : ");
                string NameGroupOne = Console.ReadLine();
                Console.WriteLine("Enter Second Group Name of find : ");
                string NameGroupTwo = Console.ReadLine();
                int count = 0;

                foreach (var item in context.Students.Where(s => s.Group.Name == NameGroupOne || s.Group.Name == NameGroupTwo))
                {
                    count++;
                }

                if (count!=0)
                Console.WriteLine($"Count Students of groups {NameGroupOne}+{NameGroupTwo} = {count}");
                else
                    Console.WriteLine("Enter correct Name Group");
            }
            catch 
            {
                Console.WriteLine("Enter correct Name Group");
            }

            //Знайти студента з максимальною оцінкою по предмету С++
            Console.WriteLine("Find a student with the maximum grade in the subject C++");

            var maxMark = context.Achievements.Where(x => x.Subject.Name == "C++" && x.Student != null).Select(x => x.Mark).Max();

            Console.WriteLine("Mark => " + maxMark);

            var studentsCS = context.Achievements.Where(x => x.Subject.Name == "C#" && x.Mark == maxMark && x.Student != null).Select(x => x.Student).ToList();

            if (studentsCS != null)
                foreach (var item in studentsCS)
                {
                    Console.WriteLine($"{item.Name} {item.Surname} | {item.Group.Name}");
                }


            //Знайти всі предмети, які читає Андрій Трофімчук
            Console.WriteLine("Find all subjects read by Andriy Trofimchuk");

            var subjects = context.TeachersGroups.Where(x => x.Teacher.Name == "Andrii" && x.Teacher.Surname == "Trofimchuk").Select(x => x.Subject);

            foreach (var item in subjects)
            {
                Console.WriteLine($"{item.Name} {item.Department.Name}");
            }

            //Знайти скільки студентів з іменем Оля
            Console.WriteLine("Find how many students named Olya");

            var nameOlia = context.Students.Count(x => x.Name == "Olia");

            Console.WriteLine("Olia: " + nameOlia);


            //Студенту з мінімальною оцінкою змінити прізвище
            Console.WriteLine("A student with a minimum grade should change his / her last name");
            //PrintContextStudents(context);

             var minMark = context.Achievements.Where(x => x.Subject.Name == "C#" && x.Student != null).Select(x => x.Mark).Max();

            Console.WriteLine("Min Mark => " + minMark);

            var studentsMinCS = context.Achievements.Where(x => x.Subject.Name == "C#" && x.Mark == minMark && x.Student != null).Select(x => x.Student).ToList();

            

            if (studentsMinCS != null)
            {
                foreach (var item in studentsMinCS)
                {
                    Console.Write($"Enter new surname for {item.Name} {item.Surname}: ");
                    item.Surname = Console.ReadLine();
                }
                context.SaveChanges();
            }

            PrintContextStudents(context);


        }

               
        private static void PrintContextStudents(UniversityEntities context)
        {
            Console.WriteLine("=====================================");
            foreach (var item in context.Students)
            {
                Console.WriteLine($"{item.Name}  {item.Surname} =====>>>>>  {item.Group.Name}");
            }
            Console.WriteLine("=====================================");
        }



    }
}
