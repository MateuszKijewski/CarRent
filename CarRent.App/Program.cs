using CarRent.DataAccess;
using CarRent.Models.Converters;
using CarRent.Models.Dtos;
using CarRent.Repositories;
using CarRent.Services;
using CarRent.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CarRent.App
{
    class Program
    {

        static void Main(string[] args)
        {
            var provider = new Dependencies().Load();
            IClientService clientService = provider.GetService<IClientService>();
            ICarService carService = provider.GetService<ICarService>();
            IWorkerService workerService = provider.GetService<IWorkerService>();
            IDocumentService documentService = provider.GetService<IDocumentService>();
            ICoordinatorService coordinatorService = provider.GetService<ICoordinatorService>();

            var coo = coordinatorService.GetCoordinator(2);

            Dictionary<string, string> stringQuery = new Dictionary<string, string>();
            Dictionary<string, int[]> intQuery = new Dictionary<string, int[]>();
            stringQuery.Add("Brand", "Porsche");
            stringQuery.Add("Model", "Cayenne");
            int[] zakres = {2017, 2019};
            intQuery.Add("Year", zakres);
            
            var cars = carService.FilterCars(stringQuery, null, null);
            foreach(var car in cars)
            {
                Console.WriteLine(car.Description);
            }

            var clients = clientService.GetAllClients();


            /*var worker = new AddWorkerDto { FirstName = "Krzysztof", LastName = "Nowak", Email = 
                                            "test@interia.pl", PhoneNumber = "123321123", Salary = 3405m };
            workerService.AddWorker(1, worker);
            
            var car = new AddCarDto
            {
                Brand = "Porsche",
                Model = "Cayenne",
                Engine = "v8",
                Year = 2018,
                Transmission = "Automatic",
                FuelType = "Gasoline",
                Color = "Black",
                PricePerDay = 350.30m,
                Mileage = 5000,
            };
            carService.AddCar(car);
            
            var client = clientService.GetClient(4);
            var updateClient = new UpdateClientDto() { Pesel = "2137" };
            Console.WriteLine(client.description);
            var updatedClient = clientService.UpdateClient(4, updateClient);
            Console.WriteLine(updatedClient.description);
            
            
            var clients = clientService.GetAllClients();
            foreach(var client in clients)
            {
                Console.WriteLine(client.description);
            }
            Console.WriteLine("--------------------------------------------");

            var gotclient = clientService.GetClient(4);
            Console.WriteLine(gotclient.description);

            Console.WriteLine("--------------------------------------------");
            Dictionary<string, string> query = new Dictionary<string, string>();
             query.Add("FirstName", "om");

            var filteredClients = clientService.FilterClients(query, null);
             foreach(var filteredClient in filteredClients)
            {
                Console.WriteLine(filteredClient.description);
            }

             */
        }
    }
}
