using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DAL.Entities
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public int Count { get; set; }
        public Double TotalPrice { get; set; }

        //Navigation prop


        public virtual Client Client { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();

        }


    }
}
