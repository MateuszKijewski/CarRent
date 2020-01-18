using CarRent.DataAccess;
using CarRent.Models.Converters;
using CarRent.Repositories;
using CarRent.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.App
{
    public class Dependencies
    {
        private IServiceCollection services = new ServiceCollection();

        public IServiceProvider Load()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarRentDbContext>();
            optionsBuilder.UseSqlite("Data Source=sqlite.db");

            services.AddTransient<CarRentDbContext>(sp => new CarRentDbContext(optionsBuilder.Options));

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddTransient<IDocumentService, DocumentServices>();

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddSingleton<ICarConverter, CarConverter>();

            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddSingleton<IWorkerConverter, WorkerConverter>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddSingleton<IClientConverter, ClientConverter>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderConverter, OrderConverter>();


            return services.BuildServiceProvider();
        }
    }
}
