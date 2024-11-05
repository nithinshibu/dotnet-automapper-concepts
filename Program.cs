using AutoMapper;
using AutoMapperInDotnet.Models.Destination;
using AutoMapperInDotnet.Models.Source;
using AutoMapperInDotnet.Models.AutoMapper.Configurations;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {

        //Initialising the automapper
        var _mapper = MapperConfig.InitialiseAutoMapper();

        Product product = new Product()
        {
            ProductID = 101,
            Name= "Led TV",
            OptionalName="Product Name not start with A",
            Quantity=-5,
            Amount=1000
        };

        var productDTO = _mapper.Map<Product,ProductDTO>(product);



        Console.WriteLine("Before Mapping : Product Object");
        Console.WriteLine("ProductID : " + product.ProductID);
        Console.WriteLine("Name : " + product.Name);
        Console.WriteLine("OptionalName : " + product.OptionalName);
        Console.WriteLine("Quantity : " + product.Quantity);
        Console.WriteLine("Amount : " + product.Amount);
        Console.WriteLine();

        Console.WriteLine("After Mapping : ProductDTO Object");
        Console.WriteLine("ProductID : " + productDTO.ProductID);
        Console.WriteLine("ItemName : " + productDTO.ItemName);
        Console.WriteLine("ItemQuantity : " + productDTO.ItemQuantity);
        Console.WriteLine("Amount : " + productDTO.Amount);
        Console.ReadLine();


    }

    
}