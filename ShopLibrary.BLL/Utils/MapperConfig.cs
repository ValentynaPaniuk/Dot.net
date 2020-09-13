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
            //   OrderDTO <= Order
            CreateMap<Order, OrderDTO>()
                //    Author = item.Author.Name,
                .ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date))
                .ForMember(x => x.Count, opt => opt.MapFrom(x => x.Count))
                .ForMember(x => x.Client, opt => opt.MapFrom(x => x.Client.NameClient))
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Address.Country));
               

            CreateMap<OrderDTO, Order>().MaxDepth(2)
                // Author = new Author
                .ForMember(x => x.Client, opt => opt.MapFrom(x => new Client
                {
                    NameClient = x.Client
                }))
                .ForMember(x => x.Address, opt => opt.MapFrom(x => new Address
                {
                    Country = x.Address
                }));

            //Address
            CreateMap<AddressDTO, Address>().MaxDepth(1);
            CreateMap<Address, AddressDTO>().MaxDepth(1);
            //    Author = item.Author.Name,
            //     .ForMember(x => x.Country, opt => opt.MapFrom(x => x.Country))
            //   .ForMember(x => x.City, opt => opt.MapFrom(x => x.City))
            // .ForMember(x => x.Street, opt => opt.MapFrom(x => x.Street))
            //  .ForMember(x => x.Builder, opt => opt.MapFrom(x => x.Builder));


            //Client
            CreateMap<Client, ClientDTO>();
            CreateMap<Manufacture, ManufactureDTO>().MaxDepth(2);
            CreateMap<ManufactureDTO, Manufacture>().MaxDepth(2);
            CreateMap<Product, ProductDTO>()
                .ForMember(x=>x.Manufacture, opt=>opt.MapFrom(x=>x.Manufacture.NameManufacture))
                .ForMember(x=>x.Category, opt=>opt.MapFrom(x=>x.Category.NameCategory))
                .ForMember(x=>x.Address, opt=>opt.MapFrom(x=>x.Address.Country))
                ;
               //    Author = item.Author.Name,
           //    .ForMember(x => x.NameClient, opt => opt.MapFrom(x => x.NameClient));
            //Manufacture





        }
    }
}
