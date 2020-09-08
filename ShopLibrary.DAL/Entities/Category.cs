using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DAL.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameCategory { get; set; }

        //Navigation prop
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }

    }
}
