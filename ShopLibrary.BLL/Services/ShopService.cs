using AutoMapper;
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
        private readonly IGenericRepository<Order> repoOrder;
        private readonly IGenericRepository<Product> repoProduct;
        private readonly IGenericRepository<Client> repoClient;
        private readonly IGenericRepository<Address> repoAddress;

        private readonly IMapper mapper;

        //===========================Інєкція залежностей===================
        public ShopService(   IGenericRepository<Order> _repoOrder, 
                              IGenericRepository<Product> _repoProduct, 
                              IGenericRepository<Client> _repoClient, 
                              IGenericRepository<Address> _repoAddress,
                              IMapper _mapper)
        {                     
            repoOrder = _repoOrder;
            repoProduct = _repoProduct;
            repoClient = _repoClient;
            repoAddress = _repoAddress;
            mapper = _mapper;
        }

        public void AddOrder(OrderDTO orderDTO)
        {
            var addOrder = mapper.Map<Order>(orderDTO);
            var address = repoAddress.GetAll().FirstOrDefault(x => x.Country == orderDTO.Address);
            var client = repoClient.GetAll().FirstOrDefault(x => x.NameClient == orderDTO.Client);

            //var addOrder = new Order()
            //{
            //    Date = orderDTO.Date,
            //    Count = orderDTO.Count,
            //    Client = client,
            //    Address = address,

            //};

            addOrder.Address = address;
            addOrder.Client = client;

            repoOrder.Create(addOrder);
        }

        public IEnumerable<OrderDTO> GetOrders()
        {
            var orders = repoOrder.GetAll();

            //var model =new  List<OrderDTO>();
            //foreach (var item in orders)
            //{
            //    model.Add(new OrderDTO
            //    {
            //        Id =item.Id,
            //        Date = item.Date,
            //        Count = item.Count,
            //        Address = item.Address.Country,
            //        Client = item.Client.NameClient,
            //        TotalPrice = item.TotalPrice,
                  
            //    });
            //}

            var model = mapper.Map<ICollection<OrderDTO>>(orders);
            return model;
        }



        ICollection<ProductDTO> GetDetailsAboutOrder(int OrderID)
        {
            //var model = new List<ProductDTO>();
            var order = repoOrder.GetAll().FirstOrDefault(x => x.Id == OrderID);

            //foreach (var item in order.Products)
            //{
            //    model.Add(new ProductDTO
            //    {
            //        Id = item.Id,
            //        NameProduct = item.NameProduct,
            //        Price = item.Price,
            //        IsLegal = item.IsLegal,
            //        Category = item.Category.NameCategory,
            //        Manufacture = item.Manufacture.NameManufacture,
            //        Address = item.Address.Country,


            //    });
            //}
            var model = mapper.Map<ICollection<ProductDTO>>(order);
            return model;
        }

    }
}
