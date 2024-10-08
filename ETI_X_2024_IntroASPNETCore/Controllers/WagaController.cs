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
    public class WagaController : Controller
    {
        private readonly ETI_X_2024_IntroASPNETCoreContext _context;

        public WagaController(ETI_X_2024_IntroASPNETCoreContext context)
        {
            _context = context;
        }

        // GET: Waga
        public async Task<IActionResult> Index()
        {
            var eTI_X_2024_IntroASPNETCoreContext = _context.Waga.Include(w => w.Uzytkownik);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }

        // GET: Waga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waga = await _context.Waga
                .Include(w => w.Uzytkownik)
                .FirstOrDefaultAsync(m => m.WagaId == id);
            if (waga == null)
            {
                return NotFound();
            }

            return View(waga);
        }

        // GET: Waga/Create
        public IActionResult Create()
        {
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "UzytkownikId", "UzytkownikId");
            return View();
        }

        // POST: Waga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WagaId,Data,Wartosc,UzytkownikId")] Waga waga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(waga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "UzytkownikId", "UzytkownikId", waga.UzytkownikId);
            return View(waga);
        }

        // GET: Waga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waga = await _context.Waga.FindAsync(id);
            if (waga == null)
            {
                return NotFound();
            }
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "UzytkownikId", "UzytkownikId", waga.UzytkownikId);
            return View(waga);
        }

        // POST: Waga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WagaId,Data,Wartosc,UzytkownikId")] Waga waga)
        {
            if (id != waga.WagaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(waga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WagaExists(waga.WagaId))
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
            ViewData["UzytkownikId"] = new SelectList(_context.Set<Uzytkownik>(), "UzytkownikId", "UzytkownikId", waga.UzytkownikId);
            return View(waga);
        }

        // GET: Waga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var waga = await _context.Waga
                .Include(w => w.Uzytkownik)
                .FirstOrDefaultAsync(m => m.WagaId == id);
            if (waga == null)
            {
                return NotFound();
            }

            return View(waga);
        }

        // POST: Waga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var waga = await _context.Waga.FindAsync(id);
            if (waga != null)
            {
                _context.Waga.Remove(waga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WagaExists(int id)
        {
            return _context.Waga.Any(e => e.WagaId == id);
        }
    }
}
