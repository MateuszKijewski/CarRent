using CarRent.DataAccess;
using CarRent.Models.Converters;
using CarRent.Models.Dtos;
using CarRent.Repositories;
using CarRent.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CarRent.App
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddDbContext<CarRentDbContext>(factory =>
            {
                var connectionString = @"Data Source=sqlite.db;";
                factory.UseSqlite(connectionString);
            });

            var provider = services.BuildServiceProvider();

            var db = provider.GetService<CarRentDbContext>();
            var clientConverter = new ClientConverter();
            var clientRepository = new ClientRepository(db);
            var clientService = new ClientService(clientConverter, clientRepository);


            var client = new AddClientDto();
            client.DriversLicenseNumber = "test";
            client.FirstName = "Jan";
            client.LastName = "Kowalski";
            client.PhoneNumber = "123321123";
            client.Email = "test@gmail.com";
            client.Pesel = "124323425";
            client.IdNumber = "cdf21345";
            clientService.AddClient(client);
            var test = clientService.GetClient(1);
            Console.WriteLine(test.fullName);
            
            

        }
    }
}
