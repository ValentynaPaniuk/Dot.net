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


            //Alt+Enter - create function
            Print(context);

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

            Print(context);

            //Update Group in Student

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

            Print(context);


            //Вивести всіх студентів певної групи
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

            Student student = (Student)context.Achievements.Where(s => s.Subject.Name == "C++" && s.Mark==10);
            Console.WriteLine($"Exellent Student:   {student.Name} {student.Surname}");


            //Знайти всі предмети, які читає Андрій Трофімчук

            Subject sub = (Subject)context.Subjects.Where(s=> s.)
            //Знайти скільки студентів з іменем Оля
            //Студенту з мінімальною оцінкою змінити прізвище

        }




        private static void Print(UniversityEntities context)
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
