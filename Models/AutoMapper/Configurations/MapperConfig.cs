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
                cfg.CreateMap<Order, OrderDTO>()
                //OrderId is different so map them using ForMember
                .ForMember(dest => dest.OrderId, act => act.MapFrom(src => src.OrderNo))
                //Customer is a Complex type, so map Customer to Simple type using ForMember
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.PostCode, act => act.MapFrom(src => src.Customer.PostCode))
                .ForMember(dest => dest.MobileNo, act => act.MapFrom(src => src.Customer.ContactNo))
                .ForMember(dest => dest.CustomerId, act => act.MapFrom(src => src.Customer.CustomerID))
                .ReverseMap();//Making the mapping Bi-directional

                //Any other mapping configuration
            });

            //Create an instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
