using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using static PersistenceLayer.Program;

namespace PersistenceLayer
{
    public class EmployeesCRUD
    {
        public static void AddEmployee(Employee employee)
        {
            using (var db = new TripContext())
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }
        }

        public static Employee GetEmployee(int EmployeeId_)
        {
            List<Employee> employees = new List<Employee>();

            using (var db = new TripContext())
            {
                var result = db.Employees.
                    Where(e => e.EmployeeId == EmployeeId_);

                foreach (var item in result)
                    employees.Add(item);
            }

            return employees.ElementAt(0);
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            using (var db = new TripContext())
            {
                var result = db.Employees;

                foreach (var item in result)
                    employees.Add(item);

                db.SaveChanges();
            }

            return employees;
        }

        public static void DeleteEmployee(int EmployeeId_)
        {
            using (var db = new TripContext())
            {
                List<Employee> employees = new List<Employee>();

                var result = db.Employees.Where(
                    e => e.EmployeeId == EmployeeId_);

                foreach (var item in result)
                    employees.Add(item);

                db.Employees.Remove(employees.ElementAt(0));

                db.SaveChanges();
            }
        }

        public static List<Trip> GetHistory(int EmployeeId)
        {
            List<Trip> trips = new List<Trip>();

            using (var db = new TripContext())
            {
                var collection = db.Trips.Include(t => t.Vehicle).
                    Include(t => t.Employee).
                    Where(t => t.Employee.EmployeeId == EmployeeId);

                foreach (var item in collection)
                    trips.Add(item);
            }
            return trips;
        }
    }
}
