﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CodeFirst_Initializer_WPF.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public double Price { get; set; }
        public bool IsLegal { get; set; }

        //Navigation prop
        public virtual Category Category { get; set; }
        public virtual Manufacture Manufacture { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Product()
        {
            Order order = new Order();
        }


    }
}
