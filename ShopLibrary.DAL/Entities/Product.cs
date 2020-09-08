using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopLibrary.DAL.Entities
{
    public class Product
    {
        [Key] //Primary Key
        public int Id { get; set; }
        [Required] //Обов'язкове поле
        public string NameProduct { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public bool IsLegal { get; set; }

        //Navigation prop
        public virtual Category Category { get; set; }
        public virtual Manufacture Manufacture { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        {
            Order order = new Order();
        }


    }
}
