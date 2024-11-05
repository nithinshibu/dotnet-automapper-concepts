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


        PermanentAddress permAddress = new PermanentAddress()
        {
            Name = "Pranaya",
            Address = null,
            CreatedBy = "Dot Net Tutorials",
            CreatedOn = DateTime.Now
        };
        var TempAddress = _mapper.Map<PermanentAddress, TemporaryAddress>(permAddress);
        Console.WriteLine("After Mapping Permanent Address");
        //Here CreatedBy and CreatedOn will be empty for Permanent Address
        Console.WriteLine($"Name: {permAddress.Name}, Address: {permAddress.Address}, CreatedBy: {permAddress.CreatedBy}, CreatedOn: {permAddress.CreatedOn}");
        Console.WriteLine("After Mapping Permanent Address");
        //Here CreatedBy with Fixed Valye and CreatedOn with Dynamic Value
        Console.WriteLine($"Name: {TempAddress.Name}, Address: {TempAddress.Address}, CreatedBy: {TempAddress.CreatedBy}, CreatedOn: {TempAddress.CreatedOn}");
        Console.ReadLine();


    }
}