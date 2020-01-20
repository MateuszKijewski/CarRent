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
            var provider = new Dependencies().Load();
            IClientService clientService = provider.GetService<IClientService>();
            var client = new AddClientDto();
            client.FirstName = "Jan";
            client.LastName = "Kowalski";
            client.Pesel = "23232323232";
            client.PhoneNumber = "123321123";
            client.Email = "test@gmail.com";
            client.IdNumber = "aqdc2134";
            clientService.AddClient(client);


        }
    }
}
