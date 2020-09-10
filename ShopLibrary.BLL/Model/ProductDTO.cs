using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.BLL.Model
{
    public class ProductDTO
    {

       
        public int Id { get; set; }
       
        public string NameProduct { get; set; }
      
        public double Price { get; set; }
      
        public bool IsLegal { get; set; }

        //Navigation prop
        public string Category { get; set; }
        public string Manufacture { get; set; }
        public string Address { get; set; }

       // public ICollection<string> Orders { get; set; }
       

    }
}
