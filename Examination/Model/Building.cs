using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF_StoreLib.Model
{
    public class Building
    {
        public int Id { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }
        public Building()
        {
            Manufacturers = new HashSet<Manufacturer>();
        }
        public override string ToString()
        {
            return $"{Address}";
        }
    }
}
