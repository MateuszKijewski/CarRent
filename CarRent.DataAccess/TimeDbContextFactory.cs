using CarRent.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FunWithSqLite.DataAccess.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CarRentDbContext>
    {
        public CarRentDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CarRentDbContext>();

            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=CarRent;Integrated Security=True";
            
            builder.UseSqlServer(connectionString);

            return new CarRentDbContext(builder.Options);
        }
    }
}