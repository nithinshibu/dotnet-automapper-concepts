using AutoMapper;
using AutoMapperInDotnet.Models;
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
            Address = "London",
            Department = "IT"
        };

        //Initialising the automapper
        var _mapper = MapperConfig.InitialiseAutoMapper();

        // Way 1 : Specify the Destination Type and to the Map method pass the Source object
        //Now, employeeDTO1 object will have the same values as emp object

        //Here in this example the EmployeeDTO (destination class) has different property names from the Source class (Employee)
        //So we will get Name and Department as empty initially unless we make some changes in the MapperConfig


        //Automapper will map the properties automatically when the source and destination property names matches

        //When the properties names are different then we need to use the ForMember option in the automapper in the MapperConfig

        EmployeeDTO employeeDTO1 = _mapper.Map<Employee, EmployeeDTO>(emp);

        Console.WriteLine("Name: " + employeeDTO1.FullName);
        Console.WriteLine("Deparment: " + employeeDTO1.Dept);


    }
}