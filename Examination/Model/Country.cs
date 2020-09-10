using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_EF_StoreLib.Model
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public Country()
        {
            Cities = new HashSet<City>();
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
