using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kolokwium.Model.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Car> Cars { get; set; } = default!;
        public virtual DbSet<Owner> Owners { get; set; } = default!;
        public virtual DbSet<OwnerCar> OwnerCars { get; set; } = default!;
        public virtual DbSet<Store> Stores { get; set; } = default!;
        public virtual DbSet<Ambulance> Ambulances { get; set; } = default!;
        public virtual DbSet<Truck> Trucks { get; set; } = default!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .ToTable("Cars")
                .HasDiscriminator<int>("CarType")
                .HasValue<Car>(0)
                .HasValue<Truck>(1)
                .HasValue<Ambulance>(2);

            modelBuilder.Entity<OwnerCar>()
                .HasKey(x => new { x.OwnerId, x.CarVin });
            modelBuilder.Entity<OwnerCar>()
                .HasOne(x => x.Owner)
                .WithMany(y => y.OwnerCars)
                .HasForeignKey(x => x.OwnerId);
            modelBuilder.Entity<OwnerCar>()
                .HasOne(x => x.Car)
                .WithMany(y => y.OwnerCars)
                .HasForeignKey(x => x.CarVin);

        }
    }
}
