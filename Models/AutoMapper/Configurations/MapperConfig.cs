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

                cfg.CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name))
                .ForMember(dest => dest.Address, act => act.MapFrom(src => new Address()
                {
                    City = src.City,
                    State = src.State,
                    Country = src.Country
                }));

                //Any other mapping configuration
            });

            //Create an instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
