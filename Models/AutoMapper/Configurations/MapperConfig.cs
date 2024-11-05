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
                cfg.CreateMap<Product, ProductDTO>()
                //If the Name starts with 'A' then map the Name value else map the OptionalName value
                .ForMember(dest => dest.ItemName, act => act.MapFrom(src => (src.Name.StartsWith("A") ? src.Name : src.OptionalName)))
                //Map the quantity value if it's greater than 0
                .ForMember(dest => dest.ItemQuantity, act => act.Condition(src => (src.Quantity > 0)))
                .ForMember(dest=>dest.ItemQuantity,act=>act.MapFrom(src=>src.Quantity))
                //Map the amount value if it's greater than 100
                .ForMember(dest => dest.Amount, act => act.Condition(src => (src.Amount > 100)));
                

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
 * 
 * We need to map the Name property of the Product class to the ItemName property of the ProductDTO class only if
 * the Name value starts with the letter A , else map the OptionalName property value of the Product class with the
 * ItemName property of the ProductDTO class.
 * 
 * If the Quantity value of the Product class is greater than 0 then only map it to the ItemQuantity property of the ProductDTO class.
 * 
 * Similarly, if the Amount value of the Product object is greater than 100 then only map it to the Amount property of the ProductDTO class
 * 
 */