using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CodeFirst_.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }

        //Navigation prop
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }

    }
}
