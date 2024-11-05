using AutoMapper;
using AutoMapperInDotnet.Models.AutoMapper.IgnoreMultiple.IgnoreNoMapExtension;
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
                cfg.CreateMap<Employee, EmployeeDTO>().IgnoreNoMap();


                //Any other mapping configuration
            });

            //Create an instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}


/*
 * BUSINESS REQUIREMENT (Conditional Mapping)
 * 
 * Our business requirement is not to map the Address property i.e we need to ignore the Address property while doing the mapping between
 * these two objects.
 * 
 * 
 */