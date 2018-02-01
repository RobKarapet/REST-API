using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static PersistenceLayer.Program;

namespace PersistenceLayer
{
    public class VehiclesCRUD
    {
        public static void AddVehicle(Vehicle vehicle)
        {
            using (var db = new TripContext())
            {
                db.Add(vehicle);
                db.SaveChanges(); 
            }
        }

        public static Vehicle GetVehicle(int Id)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var db = new TripContext())
            {
                var collection = db.Vehicles.
                    Where(v => v.VehicleId == Id);

                foreach (var item in collection)                
                    vehicles.Add(item);                
            }

            return vehicles.ElementAt(0);
        }

        public static List<Vehicle> GetVehicles()
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            using (var db = new TripContext())
            {
                var collection = db.Vehicles;

                
                foreach (Vehicle item in collection)
                     vehicles.Add(item);              
                db.SaveChanges();
            }

            return vehicles;
        }

        public static void DeleteVehicle(int Id)
        {
            using (var db = new TripContext())
            {
                List<Vehicle> vehicles = new List<Vehicle>();

                var collection = db.Vehicles.
                    Where(v => v.VehicleId == Id);

                foreach (var item in collection)                
                    vehicles.Add(item);
               
                db.Vehicles.Remove(vehicles.ElementAt(0));

                db.SaveChanges();
            }
        }

        public static List<Trip> GetHistory(int VehicleId)
        {
            List<Trip> trips = new List<Trip>();

            using (var db = new TripContext())
            {
                var collection = db.Trips.Include(t => t.Vehicle).
                    Include(t => t.Employee).
                    Where(t => t.Vehicle.VehicleId == VehicleId);

                foreach (var item in collection)
                    trips.Add(item);
            }
            return trips;
        }
    }
}
