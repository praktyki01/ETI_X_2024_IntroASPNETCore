using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ETI_X_2024_IntroASPNETCore.Data;
using ETI_X_2024_IntroASPNETCore.Models;

namespace ETI_X_2024_IntroASPNETCore.Controllers
{
    public class RodzajSilnikaController : Controller
    {
        private readonly ETI_X_2024_IntroASPNETCoreContext _context;

        public RodzajSilnikaController(ETI_X_2024_IntroASPNETCoreContext context)
        {
            _context = context;
        }

        // GET: RodzajSilnika
        public async Task<IActionResult> Index()
        {
            return View(await _context.RodzajSilnika.ToListAsync());
        }

        // GET: RodzajSilnika/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajSilnika = await _context.RodzajSilnika
                .FirstOrDefaultAsync(m => m.RodzajSilnikaId == id);
            if (rodzajSilnika == null)
            {
                return NotFound();
            }

            return View(rodzajSilnika);
        }

        // GET: RodzajSilnika/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RodzajSilnika/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RodzajSilnikaId,Nazwa")] RodzajSilnika rodzajSilnika)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rodzajSilnika);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodzajSilnika);
        }

        // GET: RodzajSilnika/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajSilnika = await _context.RodzajSilnika.FindAsync(id);
            if (rodzajSilnika == null)
            {
                return NotFound();
            }
            return View(rodzajSilnika);
        }

        // POST: RodzajSilnika/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RodzajSilnikaId,Nazwa")] RodzajSilnika rodzajSilnika)
        {
            if (id != rodzajSilnika.RodzajSilnikaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodzajSilnika);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodzajSilnikaExists(rodzajSilnika.RodzajSilnikaId))
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
            return View(rodzajSilnika);
        }

        // GET: RodzajSilnika/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rodzajSilnika = await _context.RodzajSilnika
                .FirstOrDefaultAsync(m => m.RodzajSilnikaId == id);
            if (rodzajSilnika == null)
            {
                return NotFound();
            }

            return View(rodzajSilnika);
        }

        // POST: RodzajSilnika/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rodzajSilnika = await _context.RodzajSilnika.FindAsync(id);
            if (rodzajSilnika != null)
            {
                _context.RodzajSilnika.Remove(rodzajSilnika);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodzajSilnikaExists(int id)
        {
            return _context.RodzajSilnika.Any(e => e.RodzajSilnikaId == id);
        }
    }
}
