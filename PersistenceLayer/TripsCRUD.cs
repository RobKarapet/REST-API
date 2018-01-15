using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static PersistenceLayer.Program;

namespace PersistenceLayer
{
    public class TripsCRUD
    {
        public static void AddTrip(Trip trip, int vehicleId, int employeeId)
        {
            using (var db = new TripContext())
            {
                var vehicles_ = db.Vehicles.
                    Where(vehicle => (vehicle.VehicleId == vehicleId));

                List<Vehicle> vehicles__ = new List<Vehicle>();
                foreach (var vehicle in vehicles_) vehicles__.Add(vehicle);
                Vehicle _vehicle = vehicles__.ElementAt(0);

                var employees_ = db.Employees.
                    Where(employee => (employee.EmployeeId == employeeId));

                List<Employee> employees__ = new List<Employee>();
                foreach (var employee in employees_) employees__.Add(employee);
                Employee _employee = employees__.ElementAt(0);

                trip.Employee = _employee;
                trip.Vehicle = _vehicle;

                db.Add(trip);

                db.SaveChanges();
            }
        }

        public static Trip GetTrip(int TripId)
        {
            List<Trip> trips = new List<Trip>();

            using (var db = new TripContext())
            {
                var collection = db.Trips.Include(t => t.Vehicle).
                    Include(t => t.Employee).
                    Where(t => t.TripId == TripId);

                foreach (var item in collection)
                    trips.Add(item);
            }
            return trips.ElementAt(0);
        }

        public static List<Trip> GetTrips()
        {
            List<Trip> trips = new List<Trip>();

            using (var db = new TripContext())
            {
                var collection = db.Trips.Include(t => t.Employee).
                    Include(t => t.Vehicle);

                foreach (var item in collection)
                    trips.Add(item);
            }

            return trips;
        }

        public static void DeleteTrip(int TripId)
        {
            using (var db = new TripContext())
            {
                List<Trip> trips = new List<Trip>();

                var collection = db.Trips.
                    Where(t => t.TripId == TripId);

                foreach (var item in collection)
                    trips.Add(item);

                db.Trips.Remove(trips.ElementAt(0));

                db.SaveChanges();
            }
        }

        public static void UpdateTrip(Trip trip)
        {
            List<Trip> trips = new List<Trip>();

            using (var db = new TripContext())
            {
                db.Trips.Update(trip);

                db.SaveChanges();
            }
        }
    }
}