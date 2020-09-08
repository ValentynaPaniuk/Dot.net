using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DAL.Entities
{
    public class Manufacture
    {
        [Key]
        public int Id { get; set; }
        [Required]
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
