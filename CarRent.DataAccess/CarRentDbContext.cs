﻿using CarRent.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarRent.DataAccess
{
    public class CarRentDbContext : DbContext
    {
        public CarRentDbContext(DbContextOptions<CarRentDbContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Worker>()
                .HasOne(w => w.Car)
                .WithOne(c => c.Worker)
                .HasForeignKey<Car>(c => c.WorkerId);

            builder.Entity<Worker>()
                .HasOne(w => w.Coordinator)
                .WithMany(c => c.Workers)
                .HasForeignKey(w => w.CoordinatorId);

            builder.Entity<Worker>()
                .HasOne(w => w.Region)
                .WithMany(r => r.Workers)
                .HasForeignKey(w => w.RegionId);

            builder.Entity<Coordinator>()
                .HasOne(c => c.Region)
                .WithMany(r => r.Coordinators)
                .HasForeignKey(c => c.RegionId);

            builder.Entity<Worker>()
                .HasBaseType("Person");
            builder.Entity<Coordinator>()
                .HasBaseType("Person");
            builder.Entity<Client>()
                .HasBaseType("Person");
        }
    }
}