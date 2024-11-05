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
        Console.WriteLine("CustomerId :" + orderDTOData.Customer.CustomerID);
        Console.WriteLine("Name :" + orderDTOData.Customer.FullName);
        Console.WriteLine("PostCode :" + orderDTOData.Customer.PostCode);
        Console.WriteLine("MobileNo :" + orderDTOData.Customer.ContactNo);
        Console.WriteLine();


        //Modify the OrderDTO data 
        orderDTOData.OrderId = 10;
        orderDTOData.NumberOfItems = 20;
        orderDTOData.TotalAmount = 2000;
        orderDTOData.Customer = new Customer()
        {
            CustomerID = 50,
            FullName= "John Wick",
            PostCode="12345",
            ContactNo="0011220056"

        };

        //AutoMapper Reverse Mapping - _mapper.Map(source, destination);

        //Without the reverse mapping , if we try to do so , then we will encounter an error as 
        //"Missing type map configuration or unsupported mapping"

        _mapper.Map(orderDTOData, OrderRequest);

        Console.WriteLine("After Reverse Mapping - Order Data");
        Console.WriteLine("OrderId :" + OrderRequest.OrderNo);
        Console.WriteLine("NumberOfItems :" + OrderRequest.NumberOfItems);
        Console.WriteLine("TotalAmount :" + OrderRequest.TotalAmount);
        Console.WriteLine("CustomerId :" + OrderRequest.CustomerId);
        Console.WriteLine("Name :" + OrderRequest.Name);
        Console.WriteLine("PostCode :" + OrderRequest.PostCode);
        Console.WriteLine("MobileNo :" + OrderRequest.MobileNo);
        Console.WriteLine();


    }

    private static Order CreateOrderRequest()
    {
        return new Order
        {
            OrderNo = 101,
            NumberOfItems = 3,
            TotalAmount = 1000,
            CustomerId = 777,
            Name = "James Smith",
            PostCode = "755019",
            MobileNo = "1234567890"
        };
    }
}