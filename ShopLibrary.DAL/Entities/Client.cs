using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.DAL.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NameClient { get; set; }

        //Navigation prop
        public virtual ICollection<Order> Orders { get; set; }

        public Client()
        {

            Orders = new List<Order>();
        }

    }
}
