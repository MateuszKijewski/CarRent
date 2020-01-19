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

            var connectionString = @"Data Source=sqlite.db;";

            builder.UseSqlite(connectionString);

            return new CarRentDbContext(builder.Options);
        }
    }
}