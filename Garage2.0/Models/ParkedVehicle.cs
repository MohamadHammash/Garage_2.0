using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
//using SQLite;

namespace Garage2._0.Models
{
    public class ParkedVehicle
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Type")]
        public VehicleType VehicleType { get; set; }
        [Display(Name = "Registration Number")]
        //[Unique]
        public string RegNr { get; set; }
        public string Color { get; set; }
        [StringLength(30)]
        public string Brand { get; set; }
        [StringLength(30)]
        public string Model { get; set; }
        [Range(1,20)]

        [Display(Name = "Number Of Wheels")]
        public int NrOfWheels { get; set; }
        [Display(Name = "Arrival Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MMMM-dd HH:mm}")]
        public DateTime ArrivalTime { get; set; }

    }
}
