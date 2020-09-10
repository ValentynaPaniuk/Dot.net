using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF_StoreLib.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public virtual User User { get; set; }
        public virtual Address DelivaryAddress { get; set; }
        public int UserId { get; set; }
        public int DelivaryAddressId { get; set; }
        public string Comment { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Order()
        {
            Products = new HashSet<Product>();
        }
        public override string ToString()
        {
            return $"{User}. {DelivaryAddress}. {OrderDate}";
        }
    }
}
