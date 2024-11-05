using AutoMapper;
using AutoMapperInDotnet.Models.Destination;
using AutoMapperInDotnet.Models.Source;
using AutoMapperInDotnet.Models.AutoMapper.Configurations;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main()
    {
        var serviceProvider = new ServiceCollection()
          .AddAutoMapper(typeof(Program)) // Registers AutoMapper and scans for profiles in the assembly
          .BuildServiceProvider();


        //Create and Populate the Employee Object i.e Source object (in real time , this might come from an API)

        Employee emp = new Employee()
        {
            Name = "John",
            Salary = 20000,
            //Creating an instance of Address Entity
            Address = new Address() { City= "London" ,Country="UK",State="England"},
            Department = "IT"
        };

        //Initialising the automapper
        var _mapper = MapperConfig.InitialiseAutoMapper();

      
        EmployeeDTO employeeDTO1 = _mapper.Map<Employee, EmployeeDTO>(emp);

        //Without making necessary changes in the AutoMapper configuration 
        //an error will be thrown
        //"Missing type map configuration or unsupported mapping"

        Console.WriteLine("Name: " + employeeDTO1.Name);
        Console.WriteLine("Deparment: " + employeeDTO1.Department);
        //So in the EmployeeDTO I changed the property name to "AddressDTO"
        //We will get a object reference null error
        Console.WriteLine("Country: " + employeeDTO1.AddressDTO.Country);


    }
}