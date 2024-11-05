using AutoMapper;
using AutoMapperInDotnet.Models.Destination;
using AutoMapperInDotnet.Models.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInDotnet.Models.AutoMapper.Configurations
{
    public class MapperConfig
    {
        public static Mapper InitialiseAutoMapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Mapping Order with OrderDTO
                //Source will be Order and Destination will be OrderDTO
                cfg.CreateMap<Order, OrderDTO>()
                
                .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderNo))
                .ForMember(dest => dest.Customer, act => act.MapFrom(src => new Customer()
                {
                    CustomerID=src.CustomerId,
                    FullName=src.Name,
                    PostCode=src.PostCode,
                    ContactNo=src.MobileNo
                }))
                .ReverseMap()
                //After this line , the source will be OrderDTO and the destination will be Order
                .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.Customer.CustomerID))
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.MobileNo, act => act.MapFrom(src => src.Customer.ContactNo))
                .ForMember(dest => dest.PostCode, act => act.MapFrom(src => src.Customer.PostCode))
                ;//Making the mapping Bi-directional

                //Any other mapping configuration
            });

            //Create an instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
