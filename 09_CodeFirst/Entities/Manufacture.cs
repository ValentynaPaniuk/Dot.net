using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09_CodeFirst.Entities
{
    public class Manufacture
    {
        public int Id { get; set; }
        public string NameManufacture { get; set; }

        //Navigation prop
        public virtual ICollection<Product> Products { get; set; }

        public Manufacture()
        {
            Products = new List<Product>();
        }

        public virtual Address Address { get; set; }
    }
}
