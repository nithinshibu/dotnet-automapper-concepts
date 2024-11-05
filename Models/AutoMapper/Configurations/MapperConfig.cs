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
                cfg.CreateMap<Employee, EmployeeDTO>();
                //To fix the error "Missing type map configuration or unsupported mapping" 
                // we need to map Address with AddressDTO
                cfg.CreateMap<Address, AddressDTO>();

                //Any other mapping configuration
            });

            //Create an instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
    }
}
