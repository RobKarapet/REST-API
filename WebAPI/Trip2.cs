using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Trip2
    {
        public int TripId { get; set; }
        public string ProjectTitle { get; set; }
        public string TripPath { get; set; }
        public string Purpose { get; set; }
        public string ProjectFunction { get; set; }
        public string TaskOrder { get; set; }
        public int InitialOdometer { get; set; }
        public int FinalOdometer { get; set; }
        public int VehicleId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime FinishTime { get; set; }
    }
}
