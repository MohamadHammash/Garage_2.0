using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.Models.ViewModels
{
    public class ParkedVehiclesViewModel
    {
        public IEnumerable<ParkedVehicle> ParkedVehicles { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        [Display(Name = "Registration Number")]
        public string RegNr { get; set; }
        [Display(Name = "Type")]
        public VehicleType? VehicleType { get; set; } //ToDo:
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
       
        public DateTime DepartureTime { get; set; }
    }
}
