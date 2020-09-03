using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CodeFirst.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Builder { get; set; }



        //Navigation prop

        public virtual ICollection<Manufacture> Manufactures { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        public Address()
        {
            Manufactures = new List<Manufacture>();
            Orders = new List<Order>();

        }
    }
}
