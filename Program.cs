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

        //Creating the source object

        Employee employee = new Employee()
        {
            ID=101,
            Name="James",
            Address="Mumbai",
            Email="info@samplemail.com"
        };

        //Mapping the source Employee Object with the Destination EmployeeDTO object
        var empDTO = _mapper.Map<Employee, EmployeeDTO>(employee);


        //Printing the Employee Object
        Console.WriteLine("After Mapping : Employee Object");
        Console.WriteLine("ID : " + employee.ID + ", Name : " + employee.Name + ", Address : " + employee.Address + ", Email : " + employee.Email);
        Console.WriteLine();
        //Printing the EmployeeDTO Object
        Console.WriteLine("After Mapping : EmployeeDTO Object");
        Console.WriteLine("ID : " + empDTO.ID + ", Name : " + empDTO.Name + ", Address : " + empDTO.Address + ", Email : " + empDTO.Email);
        Console.ReadLine();

    }

    
}