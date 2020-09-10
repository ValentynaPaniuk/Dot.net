using AutoMapper;
using ShopLibrary.BLL.Model;
using ShopLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopLibrary.BLL.Utils
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //   BookDTO <= Book
            CreateMap<Order, OrderDTO>()
                //    Author = item.Author.Name,
                .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date))
                .ForMember(x => x.Count, opt => opt.MapFrom(x => x.Count))
                .ForMember(x => x.Client, opt => opt.MapFrom(x => x.Client.NameClient))
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Address.Country));
               

            CreateMap<OrderDTO, Order>()
                // Author = new Author
                .ForMember(x => x.Client, opt => opt.MapFrom(x => new Client
                {
                    NameClient = x.Client
                }))
                .ForMember(x => x.Count, opt => opt.MapFrom(x => new Address
                {
                    Country = x.Address
                }));
        }
    }
}
