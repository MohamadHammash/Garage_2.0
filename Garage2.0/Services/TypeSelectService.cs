using Garage2._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Garage2._0.services
{
    public class TypeSelectService: ITypeSelectService
    {
        private readonly Garage2_0Context db;

        public TypeSelectService(Garage2_0Context db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypesAsync()
        {
            return await db.ParkedVehicle
                          .Select(v => v.VehicleType)
                          .Distinct()
                          .Select(g => new SelectListItem
                          {
                              Text = g.ToString(),
                              Value = g.ToString()
                          })
                          .ToListAsync();
        }
    }
}
