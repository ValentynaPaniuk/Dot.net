﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_CodeFirst_Initializer_WPF.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public Double TotalPrice { get; set; }

        //Navigation prop


        public virtual Client Client { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Order()
        {
            Products = new List<Product>();

        }


    }
}