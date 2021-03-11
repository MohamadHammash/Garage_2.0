using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.Models.ViewModels
{
    public class LeavingVehicleViewModel
    {
        private const double pricePerHour = 10;
        public ParkedVehicle LeavingVehicle { get; set; }

        public DateTime LeavingTime { get; set; }
        public TimeSpan ParkingTime { get; }

        public double ParkingCost 
        {
            get
            {
                return Math.Round(pricePerHour * ParkingTime.TotalHours * 100) / 100;
            }

        }

        public LeavingVehicleViewModel(ParkedVehicle leavingVehicle)
        {
            LeavingVehicle = leavingVehicle;
            ParkingTime = DateTime.Now - LeavingVehicle.ArrivalTime;
        }
    }
}
