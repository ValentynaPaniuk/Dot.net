using ShopLibrary.BLL.Model;
using ShopLibrary.DAL.Entities;
using ShopLibrary.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ShopLibrary.BLL.Services.ShopService;

namespace ShopLibrary.BLL.Services
{
    public class ShopService : IShopService
    {
        private readonly IGenericRepository<Order> repo;

        public ShopService()
        {
            repo = new EFRepository<Order>();
        }

        public IEnumerable<Order> GetOrders()
        {
            return repo.GetAll();
        }
    }
}
