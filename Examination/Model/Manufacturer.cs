using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF_StoreLib.Model
{
    public class Manufacturer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Manufacturer()
        {
            Products = new HashSet<Product>();
        }
        public override string ToString()
        {
            return $"{Name}, {Building}";
        }
    }
}
