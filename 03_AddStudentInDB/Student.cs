using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_AddStudentInDB
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? IdGroup { get; set; } //тут дозволяється int присвоювати значення Null

        public override string ToString()
        {
            return $"{IdStudent}\t\t{Name}\t\t{Surname}\t\t{IdGroup}";
        }
    }

   
}
