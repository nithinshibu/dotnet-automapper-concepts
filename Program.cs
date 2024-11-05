using AutoMapper;
using AutoMapperInDotnet.Models.Destination;
using AutoMapperInDotnet.Models.Source;
using AutoMapperInDotnet.Models.AutoMapper.Configurations;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        //var serviceProvider = new ServiceCollection()
        //  .AddAutoMapper(typeof(Program)) // Registers AutoMapper and scans for profiles in the assembly
        //  .BuildServiceProvider();

        //Initialising the automapper
        var _mapper = MapperConfig.InitialiseAutoMapper();

        //Create the Order Request

        Order OrderRequest = CreateOrderRequest();

        //Map the OrderRequest object with OrderDTO Object

        var orderDTOData = _mapper.Map<Order, OrderDTO>(OrderRequest);

        //or
        //var orderDTOData = _mapper.Map<OrderDTO>(OrderRequest);

        //Print the OrderDTO Data

        Console.WriteLine("After Mapping - OrderDTO Data");
        Console.WriteLine("OrderId :"+orderDTOData.OrderId);
        Console.WriteLine("NumberOfItems :" + orderDTOData.NumberOfItems);
        Console.WriteLine("TotalAmount :" + orderDTOData.TotalAmount);
        Console.WriteLine("CustomerId :" + orderDTOData.CustomerId);
        Console.WriteLine("Name :" + orderDTOData.Name);
        Console.WriteLine("PostCode :" + orderDTOData.PostCode);
        Console.WriteLine("MobileNo :" + orderDTOData.MobileNo);
        Console.WriteLine();


        //Modify the OrderDTO data 
        orderDTOData.OrderId = 10;
        orderDTOData.NumberOfItems = 20;
        orderDTOData.TotalAmount = 2000;
        orderDTOData.CustomerId = 5;
        orderDTOData.Name = "William";
        orderDTOData.PostCode = "12345";

        //AutoMapper Reverse Mapping - _mapper.Map(source, destination);

        //Without the reverse mapping , if we try to do so , then we will encounter an error as 
        //"Missing type map configuration or unsupported mapping"

        _mapper.Map(orderDTOData, OrderRequest);

        Console.WriteLine("After Reverse Mapping - Order Data");
        Console.WriteLine("OrderId :" + OrderRequest.OrderNo);
        Console.WriteLine("NumberOfItems :" + OrderRequest.NumberOfItems);
        Console.WriteLine("TotalAmount :" + OrderRequest.TotalAmount);
        Console.WriteLine("CustomerId :" + OrderRequest.Customer.CustomerID);
        Console.WriteLine("Name :" + OrderRequest.Customer.FullName);
        Console.WriteLine("PostCode :" + OrderRequest.Customer.PostCode);
        Console.WriteLine("MobileNo :" + OrderRequest.Customer.ContactNo);
        Console.WriteLine();


    }

    private static Order CreateOrderRequest()
    {
        return new Order
        {
            OrderNo = 101,
            NumberOfItems = 3,
            TotalAmount = 1000,
            Customer = new Customer()
            {
                CustomerID = 777,
                FullName = "James Smith",
                PostCode = "755019",
                ContactNo = "1234567890"
            }
        };
    }
}