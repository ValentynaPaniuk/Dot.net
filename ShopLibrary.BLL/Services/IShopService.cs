﻿using ShopLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.BLL.Services
{
    public interface IShopService
    {
        IEnumerable<Order> GetOrders();
    }
}
