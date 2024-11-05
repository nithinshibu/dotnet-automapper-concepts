using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperInDotnet.Models.AutoMapper.IgnoreMultiple.IgnoreNoMapExtension
{
    //Extension Method: 
    //The Class Should Be Static
    //Method Should Be Static
    //First Parameter is the class which which we can access the Method
    public static class IgnoreNoMapExtensions
    {
        //Method is Generic and Hence we can use with any TSource and TDestination Type
        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression)
        {
            //Fetching Type of the TSource
            var sourceType = typeof(TSource);
            //Fetching All Properties of the Source Type using GetProperties() method
            foreach (var property in sourceType.GetProperties())
            {
                //Get the Property Name
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                //Check if Property is Decorated with the NoMapAttribute
                NoMapAttribute attribute = (NoMapAttribute)descriptor.Attributes[typeof(NoMapAttribute)];
                if (attribute != null)
                {
                    //If Property is Decorated with NoMap Attribute, call the Ignore Method
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
            }
            return expression;
        }
    }
}

/*======== Use Cases for Ignore Method========
 * Property Mismatches: When the source and destination types do not have the same properties, you want to prevent AutoMapper from trying to map these mismatched properties.
 * Read-Only Properties: If the destination type has read-only properties, that should not be modified during mapping.
 * Conditional Mapping: In scenarios where certain properties should be mapped or ignored based on specific conditions.
 * Performance Optimization: Ignoring properties that are expensive to map or are not needed in the destination object can improve performance.
 */