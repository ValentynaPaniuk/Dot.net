using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.BLL.Model
{
    public class ClientDTO
    {
       
        public int Id { get; set; }
        public string NameClient { get; set; }
        public virtual ICollection<string> Orders { get; set; }

       
    }
}
