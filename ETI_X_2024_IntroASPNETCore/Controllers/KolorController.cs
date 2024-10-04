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
    public class KolorController : Controller
    {
        private readonly ETI_X_2024_IntroASPNETCoreContext _context;

        public KolorController(ETI_X_2024_IntroASPNETCoreContext context)
        {
            _context = context;
        }

        // GET: Kolor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kolor.ToListAsync());
        }

        // GET: Kolor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolor = await _context.Kolor
                .FirstOrDefaultAsync(m => m.KolorId == id);
            if (kolor == null)
            {
                return NotFound();
            }

            return View(kolor);
        }

        // GET: Kolor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kolor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KolorId,Nazwa")] Kolor kolor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kolor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kolor);
        }

        // GET: Kolor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolor = await _context.Kolor.FindAsync(id);
            if (kolor == null)
            {
                return NotFound();
            }
            return View(kolor);
        }

        // POST: Kolor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KolorId,Nazwa")] Kolor kolor)
        {
            if (id != kolor.KolorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kolor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KolorExists(kolor.KolorId))
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
            return View(kolor);
        }

        // GET: Kolor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kolor = await _context.Kolor
                .FirstOrDefaultAsync(m => m.KolorId == id);
            if (kolor == null)
            {
                return NotFound();
            }

            return View(kolor);
        }

        // POST: Kolor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kolor = await _context.Kolor.FindAsync(id);
            if (kolor != null)
            {
                _context.Kolor.Remove(kolor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KolorExists(int id)
        {
            return _context.Kolor.Any(e => e.KolorId == id);
        }
    }
}
