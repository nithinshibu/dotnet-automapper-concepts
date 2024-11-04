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

        //Method 1

        var mapper = serviceProvider.GetRequiredService<IMapper>();

        var source = new Source { Name = "John Doe" };
        var destination = mapper.Map<Destination>(source);

        Console.WriteLine($"Mapped Name: {destination.Name}");


        //Method 2

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

        EmployeeDTO employeeDTO1 = _mapper.Map<EmployeeDTO>(emp);


        //Way 2: Specify the both Source and Destination Type
        //and to the Map metohd pass the Source object
        //Now, employeeDTO2 object will have the same values as the emp object

        EmployeeDTO employeeDTO2 = _mapper.Map<Employee,EmployeeDTO>(emp);

        Console.WriteLine("Name: " + employeeDTO1.Name);
        Console.WriteLine("Deparment: " + employeeDTO2.Department);


    }
}