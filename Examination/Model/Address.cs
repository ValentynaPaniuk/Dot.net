using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF_StoreLib.Model
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public Address()
        {
            Orders = new HashSet<Order>();
            Buildings = new HashSet<Building>();
        }
        public override string ToString()
        {
            return $"{City}, {Street}, {House}";
        }
    }
}
