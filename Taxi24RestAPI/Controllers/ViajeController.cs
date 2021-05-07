using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Taxi24RestAPI.Data;
using Taxi24RestAPI.Models;

namespace Taxi24RestAPI.Controllers
{
    public class ViajeController : Controller
    {
        private readonly TaxiContext _context;

        public ViajeController(TaxiContext context)
        {
            _context = context;
        }

        // GET: Viaje
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tbl_Viajes.ToListAsync());
        }

        // GET: Viaje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajeModel = await _context.Tbl_Viajes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (viajeModel == null)
            {
                return NotFound();
            }

            return View(viajeModel);
        }

        // GET: Viaje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Viaje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,IDConductor,IDPasajero,UbicacionInicialLatitud,UbicacionInicialLongitud,UbicacionFinalLatitud,UbicacionFinalLongitud,EstatusViaje")] ViajeModel viajeModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(viajeModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viajeModel);
        }

        // GET: Viaje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajeModel = await _context.Tbl_Viajes.FindAsync(id);
            if (viajeModel == null)
            {
                return NotFound();
            }
            return View(viajeModel);
        }

        // POST: Viaje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,IDConductor,IDPasajero,UbicacionInicialLatitud,UbicacionInicialLongitud,UbicacionFinalLatitud,UbicacionFinalLongitud,EstatusViaje")] ViajeModel viajeModel)
        {
            if (id != viajeModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(viajeModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ViajeModelExists(viajeModel.ID))
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
            return View(viajeModel);
        }

        // GET: Viaje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viajeModel = await _context.Tbl_Viajes
                .FirstOrDefaultAsync(m => m.ID == id);
            if (viajeModel == null)
            {
                return NotFound();
            }

            return View(viajeModel);
        }

        // POST: Viaje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var viajeModel = await _context.Tbl_Viajes.FindAsync(id);
            _context.Tbl_Viajes.Remove(viajeModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ViajeModelExists(int id)
        {
            return _context.Tbl_Viajes.Any(e => e.ID == id);
        }
    }
}
