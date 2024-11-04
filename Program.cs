using AutoMapperInDotnet.Models;

class Program
{
    static void Main()
    {
        //Create and Populate Employee Object (TRADITIONAL WAY)

        //Switch between Git branches for automapper examples , master branch shows the traditional way example

        Employee emp = new Employee()
        {
            Name="John",
            Salary=20000,
            Address="London",
            Department="IT"
        };

        //Mapping Employee Object into the EmployeeDTO object
      
        EmployeeDTO empDTO = new EmployeeDTO()
        {
            Name = emp.Name,
            Salary = emp.Salary,
            Address = emp.Address,
            Department = emp.Department
        };

        Console.WriteLine("Name: "+empDTO.Name);
        Console.ReadLine();

        //The main problem in this approach is that in future if any new properties are added in the main class "Employee" then we need to manually map all those 
        //properties in to the EmployeeDTO class also which can be a hectic and futile task to do.

        //Another problem is that if we use the mapping in more than one place , then in each of those places we need to repeat this steps.

        //In those case, if we use the automapper then this problem will be solved

    }
}