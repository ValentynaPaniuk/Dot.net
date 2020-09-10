using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF_StoreLib.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int ManufacturerId { get; set; }
        public int CategoryId { get; set; }
        public bool IsLegal { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public override string ToString()
        {
            return $"{Category}. {Name}, {Quantity}, {Price}$. From: {ProductionDate.ToShortDateString()}, to: {ExpirationDate.ToShortDateString()}. " +
                $"Manufacturer: {Manufacturer}";
        }
        public Product()
        {
            Orders = new HashSet<Order>();
        }
    }
}
