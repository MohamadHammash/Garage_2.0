using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Models;

namespace Garage2._0.Data
{
    public class Garage2_0Context : DbContext
    {
        public DbSet<Garage2._0.Models.ParkedVehicle> ParkedVehicle { get; set; }
        public Garage2_0Context (DbContextOptions<Garage2_0Context> options)
            : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParkedVehicle>().HasData(new ParkedVehicle
            {
                Id = 1,
                VehicleType = VehicleType.Car,
                RegNr = "ABC001",
                Color = "Red",
                Brand = "Volvo",
                Model = "XC40",
                NrOfWheels = 4,
                ArrivalTime = new DateTime(2020, 12, 25, 8, 15, 30)
            });

            modelBuilder.Entity<ParkedVehicle>().HasData(new ParkedVehicle
            {
                Id = 2,
                VehicleType = VehicleType.Car,
                RegNr = "BCA321",
                Color = "Black",
                Brand = "Toyota",
                Model = "Corolla",
                NrOfWheels = 4,
                ArrivalTime = new DateTime(2020, 12, 31, 16, 25, 0)
            });

            modelBuilder.Entity<ParkedVehicle>().HasData(new ParkedVehicle
            {
                Id = 3,
                VehicleType = VehicleType.MotorCycle,
                RegNr = "HDA555",
                Color = "Green",
                Brand = "Harley Davidson",
                Model = "Low rider",
                NrOfWheels = 2,
                ArrivalTime = new DateTime(2021, 3, 10, 21, 10, 0)
            });

            modelBuilder.Entity<ParkedVehicle>().HasData(new ParkedVehicle
            {
                Id = 4,
                VehicleType = VehicleType.Car,
                RegNr = "MLB11U",
                Color = "Blue",
                Brand = "Volkswagen",
                Model = "Golf",
                NrOfWheels = 4,
                ArrivalTime = (DateTime.Now).AddHours(-37.33)
            });

            modelBuilder.Entity<ParkedVehicle>().HasData(new ParkedVehicle
            {
                Id = 5,
                VehicleType = VehicleType.Truck,
                RegNr = "SCA777",
                Color = "White",
                Brand = "Scania",
                Model = "L320",
                NrOfWheels = 4,
                ArrivalTime = (DateTime.Now).AddHours(-2.5)
            }); ;

        }


    }
}
