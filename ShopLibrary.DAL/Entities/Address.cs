using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DAL.Entities
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
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
