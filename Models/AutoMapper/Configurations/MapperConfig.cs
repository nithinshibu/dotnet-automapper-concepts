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
                .ForMember(dest=>dest.City,act=>act.MapFrom(src=>src.Address.City))
                .ForMember(dest=>dest.State,act=>act.MapFrom(src=>src.Address.State))
                .ForMember(dest=>dest.Country,act=>act.MapFrom(src=>src.Address.Country));
                

                //Any other mapping configuration
            });

            //Create an instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
