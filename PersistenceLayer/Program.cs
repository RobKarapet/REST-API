using Microsoft.EntityFrameworkCore;
using System;

namespace PersistenceLayer
{
    public class Program
    {
        public static void Main(String[] args)
        {

        }

        // DB Connection 
        public class TripContext : DbContext
        {
            public DbSet<Employee> Employees { get; set; }
            public DbSet<Vehicle> Vehicles { get; set; }
            public DbSet<Trip> Trips { get; set; }

            protected override void OnConfiguring(
                DbContextOptionsBuilder optionsBuilder)

            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;
                    Database=SQL_DB;Trusted_Connection=True");
            }
        }

        // A Table Model
        public class Employee
        {
            public int EmployeeId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string PhoneNumber { get; set; }
            public string LicenseNumber { get; set; }
            public string Password { get; set; }
        }

        // A Table Model
        public class Vehicle
        {
            public int VehicleId { get; set; }
            public string Make { get; set; }
            public string Model { get; set; }
            public string PlateNumber { get; set; }
            public string Color { get; set; }
            public DateTime ModelYear { get; set; }
            public string ModelTrim { get; set; }
            public int Odometer { get; set; }
            public DateTime LastService { get; set; }
            public DateTime NextService { get; set; }            
        }

        // A Table Model
        public class Trip
        {
            public int TripId { get; set; }
            public string ProjectTitle { get; set; }
            public string TripPath { get; set; }
            public string Purpose { get; set; }
            public string ProjectFunction { get; set; }
            public string TaskOrder { get; set; }
            public int InitialOdometer { get; set; }
            public int FinalOdometer { get; set; }
            public Vehicle Vehicle { get; set; }
            public Employee Employee { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime FinishTime { get; set; }
        }
    }
}
