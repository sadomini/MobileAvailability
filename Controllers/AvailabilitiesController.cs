using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobileAvailability.Models;

namespace MobileAvailability.Controllers
{
    public class AvailabilitiesController : Controller
    {
        private readonly MobileAvailabilityContext _context;

        public AvailabilitiesController(MobileAvailabilityContext context)
        {
            _context = context;
        }

        // GET: Availabilities
        public async Task<IActionResult> Index()
        {
            var mobileAvailabilityContext = _context.Availabilities.Include(a => a.Proizvodjac).Include(a => a.Trgovina);
            return View(await mobileAvailabilityContext.ToListAsync());
        }

        // GET: Availabilities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availabilities = await _context.Availabilities
                .Include(a => a.Proizvodjac)
                .Include(a => a.Trgovina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availabilities == null)
            {
                return NotFound();
            }

            return View(availabilities);
        }

        // GET: Availabilities/Create
        public IActionResult Create()
        {
            ViewData["ProizvodjacId"] = new SelectList(_context.Producer, "Id", "Naziv");
            ViewData["TrgovinaId"] = new SelectList(_context.Market, "Id", "Naziv");
            return View();
        }

        // POST: Availabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProizvodjacId,Tip,TrgovinaId,PredajaOglasa,Cijena,Dostupnost,Kontakt")] Availabilities availabilities)
        {
            if (ModelState.IsValid)
            {
                _context.Add(availabilities);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Producer, "Id", "Naziv", availabilities.ProizvodjacId);
            ViewData["TrgovinaId"] = new SelectList(_context.Market, "Id", "Naziv", availabilities.TrgovinaId);
            return View(availabilities);
        }

        // GET: Availabilities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availabilities = await _context.Availabilities.FindAsync(id);
            if (availabilities == null)
            {
                return NotFound();
            }
            ViewData["ProizvodjacId"] = new SelectList(_context.Producer, "Id", "Naziv", availabilities.ProizvodjacId);
            ViewData["TrgovinaId"] = new SelectList(_context.Market, "Id", "Naziv", availabilities.TrgovinaId);
            return View(availabilities);
        }

        // POST: Availabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProizvodjacId,Tip,TrgovinaId,PredajaOglasa,Cijena,Dostupnost,Kontakt")] Availabilities availabilities)
        {
            if (id != availabilities.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(availabilities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvailabilitiesExists(availabilities.Id))
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
            ViewData["ProizvodjacId"] = new SelectList(_context.Producer, "Id", "Naziv", availabilities.ProizvodjacId);
            ViewData["TrgovinaId"] = new SelectList(_context.Market, "Id", "Naziv", availabilities.TrgovinaId);
            return View(availabilities);
        }

        // GET: Availabilities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availabilities = await _context.Availabilities
                .Include(a => a.Proizvodjac)
                .Include(a => a.Trgovina)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (availabilities == null)
            {
                return NotFound();
            }

            return View(availabilities);
        }

        // POST: Availabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var availabilities = await _context.Availabilities.FindAsync(id);
            _context.Availabilities.Remove(availabilities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvailabilitiesExists(int id)
        {
            return _context.Availabilities.Any(e => e.Id == id);
        }
    }
}
