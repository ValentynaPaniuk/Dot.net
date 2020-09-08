using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.BLL.Model
{
    public class OrderDTO
    {

       
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public Double TotalPrice { get; set; }

        //Navigation prop


        public string Client { get; set; }

        public string Address { get; set; }

        public virtual ICollection<string> Products { get; set; } = new List<string>();

      



    }
}
