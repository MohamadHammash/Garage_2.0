using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models;
using Garage2._0.Models.ViewModels;
using System.Text;

namespace Garage2._0.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage2_0Context _context;

        public ParkedVehiclesController(Garage2_0Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkedVehicle.ToListAsync());
        }


        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public IActionResult Park()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park(ParkedVehicle parkedVehicle)
        {

            bool RegNrExits = _context.ParkedVehicle.Any //ToDo
         (x => x.RegNr == parkedVehicle.RegNr && x.Id != parkedVehicle.Id);
            if (RegNrExits == true)
            {
                ModelState.AddModelError("RegNr", "Vehicle already exists");
            }
            if (ModelState.IsValid)
            {

                parkedVehicle.ArrivalTime = DateTime.Now;



                _context.Add(parkedVehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(HomePage)); //ToDo:

            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }
            bool RegNrExits = _context.ParkedVehicle.Any //ToDo
        (x => x.RegNr == parkedVehicle.RegNr && x.Id != parkedVehicle.Id);
            if (RegNrExits == true)
            {
                ModelState.AddModelError("RegNr", "Vehicle already exists");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Unpark(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            var model = new LeavingVehicleViewModel(parkedVehicle);

            return View(model);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Unpark")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UnparkConfirmed(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HomePage)); //ToDo:
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }

        private async Task<IEnumerable<SelectListItem>> GetTypeAsync()
        {
            return await _context.ParkedVehicle
                          .Select(v => v.VehicleType)
                          .Distinct()
                          .Select(t => new SelectListItem
                          {
                              Text = t.ToString(),
                              Value = t.ToString()
                          })
                          .ToListAsync();
        }
        public async Task<IActionResult> HomePage()
        {
            var vehicles = await _context.ParkedVehicle.ToListAsync();
            var vTypes = await GetTypeAsync();
            var model = new ParkedVehiclesViewModel
            {
                ParkedVehicles = vehicles,
                Types = vTypes
            };


            return View(nameof(HomePage), model);
        }
        public IActionResult Filter(ParkedVehiclesViewModel viewModel)
        {
            var vehicles = string.IsNullOrWhiteSpace(viewModel.RegNr) ?
                _context.ParkedVehicle :
                _context.ParkedVehicle.Where(m => m.RegNr.StartsWith(viewModel.RegNr));

            vehicles = viewModel.VehicleType == null ?
                vehicles :
                vehicles.Where(V => V.VehicleType == viewModel.VehicleType);

            var model = new ParkedVehiclesViewModel
            {
                ParkedVehicles = vehicles

            };
            return View(nameof(HomePage), model);
        }
    }
}


