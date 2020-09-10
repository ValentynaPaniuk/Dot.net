using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.BLL.Model
{
    public class AddressDTO
    {
       
        public int Id { get; set; }
       
        public string Country { get; set; }
       
        public string City { get; set; }
       
        public string Street { get; set; }
        
        public int Builder { get; set; }



        //Navigation prop

        public virtual ICollection<string> Manufactures { get; set; }
        public virtual ICollection<string> Orders { get; set; }

       
    }
}
