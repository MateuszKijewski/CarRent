using CarRent.DataAccess;
using CarRent.Models.Converters;
using CarRent.Models.Dtos;
using CarRent.Repositories;
using CarRent.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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

            /*
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
