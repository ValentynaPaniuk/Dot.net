using ShopLibrary.BLL.Model;
using ShopLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.BLL.Services
{
    public interface IShopService
    {
        IEnumerable<OrderDTO> GetOrders();
        ICollection<ClientDTO> GetClients();
        ICollection<Address> GetAddresses();


        void AddOrder(OrderDTO orderDTO);
        void DeleteOrder(OrderDTO orderDTO);
    }
}
