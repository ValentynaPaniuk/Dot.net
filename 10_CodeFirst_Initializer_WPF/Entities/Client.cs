using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CodeFirst_Initializer_WPF.Entities
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
