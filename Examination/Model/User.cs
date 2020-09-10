using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF_StoreLib.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }
        [Column("Account", TypeName = "money")]
        public decimal Account { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public ICollection<Order> Orders { get; set; }
        public User()
        {
            Orders = new HashSet<Order>();
        }
        public override string ToString()
        {
            return $"{Status}: {Name} {LastName}. {BirthDate.ToShortDateString()}. {Account}$";
        }
    }
}
