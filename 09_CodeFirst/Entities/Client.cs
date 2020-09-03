using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CodeFirst.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string NameClient { get; set; }

        //Navigation prop
        public virtual ICollection<Order> Orders { get; set; }

        public Client()
        {
         
            Orders = new List<Order>();
        }

    }
}
