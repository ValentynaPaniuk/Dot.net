using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.BLL.Model
{
    public class ManufactureDTO
    {
        
        public int Id { get; set; }
        public string NameManufacture { get; set; }
        public virtual ICollection<string> Products { get; set; }
        public virtual string Address { get; set; }
    }
}
