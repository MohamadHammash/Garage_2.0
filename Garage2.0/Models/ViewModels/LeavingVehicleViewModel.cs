using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.Models.ViewModels
{
    public class LeavingVehicleViewModel
    {
        private const double pricePerHour = 10;
        public ParkedVehicle LeavingVehicle { get; set; }

        public DateTime LeavingTime { get; set; }

        [DisplayFormat(DataFormatString = "{0:hh':'mm}")]
        public TimeSpan ParkingTime { get; }

        public string ParkingCost 
        {
            get
            {
                double cost = Math.Round(pricePerHour * ParkingTime.TotalHours * 100) / 100;
                string formattedForCurrency = String.Format("{0:C}", cost);
                return formattedForCurrency;
            }
        }

        public LeavingVehicleViewModel(ParkedVehicle leavingVehicle)
        {
            LeavingVehicle = leavingVehicle;
            ParkingTime = DateTime.Now - LeavingVehicle.ArrivalTime;
        }
    }
}
