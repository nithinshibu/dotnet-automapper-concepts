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
            //Configuring AutoMapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PermanentAddress, TemporaryAddress>()
                    //Using MapFrom Method to Store Static or Hard-Coded Value in a Destination Property
                    .ForMember(dest => dest.CreatedBy, act => act.MapFrom(src => "System"))
                   //Before AutoMapper 8.0, to Store Static Value use the UseValue() method
                   //.ForMember(dest => dest.CreatedBy, act => act.UseValue("System"))
                   //Using MapFrom Method to Store Dynamic Value in a Destination Property
                   //Here, we are calling GetCurrentDateTime method which will return a dynamic value
                   .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => GetCurrentDateTime()))
                   ////Before AutoMapper 8.0, To Store Dynamic value use ResolveUsing() method
                   //.ForMember(dest => dest.CreatedBy, act => act.ResolveUsing(src =>
                   //{
                   //    return DateTime.Now;
                   //}))
                   //Storing NA in the destination Address Property, if Source Address is NULL
                   .ForMember(dest => dest.Address, act => act.NullSubstitute("N/A"))
                   .ReverseMap();
            });

            //Create an instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
        //Method to return Dynamic Value
        public static DateTime GetCurrentDateTime()
        {
            //Write the Logic to Get Dynamic value
            return DateTime.Now;
        }
    }
}
