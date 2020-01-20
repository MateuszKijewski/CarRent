using CarRent.DataAccess;
using CarRent.Models.Converters;
using CarRent.Models.Converters.Interfaces;
using CarRent.Repositories;
using CarRent.Repositories.Interfaces;
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
            services.AddDbContext<CarRentDbContext>();

            services.AddTransient<ICarService, CarService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IWorkerService, WorkerService>();
            services.AddTransient<IDocumentService, DocumentService>();

            services.AddTransient<ICarRepository, CarRepository>();
            services.AddSingleton<ICarConverter, CarConverter>();

            services.AddTransient<IWorkerRepository, WorkerRepository>();
            services.AddSingleton<IWorkerConverter, WorkerConverter>();

            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddSingleton<IClientConverter, ClientConverter>();

            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderConverter, OrderConverter>();

            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddSingleton<IReportConverter, ReportConverter>();



            return services.BuildServiceProvider();
        }
        

    }
}
