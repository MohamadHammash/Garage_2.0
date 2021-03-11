using Garage2._0.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.Models.ViewModels
{
    public class TypeViewModel
    {
            public IEnumerable<ParkedVehicle> Vehicles { get; set; }
            public VehicleType? VehicleType { get; set; }
            public string RegNo { get; set; }
        
    }
}
