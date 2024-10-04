﻿using System;
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
    public class SamochodController : Controller
    {
        private readonly ETI_X_2024_IntroASPNETCoreContext _context;

        public SamochodController(ETI_X_2024_IntroASPNETCoreContext context)
        {
            _context = context;
        }

        // GET: Samochod
        public async Task<IActionResult> Index()
        {
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }

        // GET: Samochod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod
                .Include(s => s.Kolor)
                .Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.RodzajSilnika)
                .FirstOrDefaultAsync(m => m.SamochodId == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // GET: Samochod/Create
        public IActionResult Create()
        {
            ViewData["KolorId"] = new SelectList(_context.Kolor, "KolorId", "KolorId");
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "MarkaId");
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "ModelId");
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "RodzajSilnikaId");
            return View();
        }

        // POST: Samochod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SamochodId,Przebieg,RokProdukcji,Cena,MarkaId,ModelId,RodzajSilnikaId,KolorId")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samochod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KolorId"] = new SelectList(_context.Kolor, "KolorId", "KolorId", samochod.KolorId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "MarkaId", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "ModelId", samochod.ModelId);
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "RodzajSilnikaId", samochod.RodzajSilnikaId);
            return View(samochod);
        }

        // GET: Samochod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod.FindAsync(id);
            if (samochod == null)
            {
                return NotFound();
            }
            ViewData["KolorId"] = new SelectList(_context.Kolor, "KolorId", "KolorId", samochod.KolorId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "MarkaId", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "ModelId", samochod.ModelId);
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "RodzajSilnikaId", samochod.RodzajSilnikaId);
            return View(samochod);
        }

        // POST: Samochod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SamochodId,Przebieg,RokProdukcji,Cena,MarkaId,ModelId,RodzajSilnikaId,KolorId")] Samochod samochod)
        {
            if (id != samochod.SamochodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samochod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamochodExists(samochod.SamochodId))
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
            ViewData["KolorId"] = new SelectList(_context.Kolor, "KolorId", "KolorId", samochod.KolorId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "MarkaId", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "ModelId", samochod.ModelId);
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "RodzajSilnikaId", samochod.RodzajSilnikaId);
            return View(samochod);
        }

        // GET: Samochod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod
                .Include(s => s.Kolor)
                .Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.RodzajSilnika)
                .FirstOrDefaultAsync(m => m.SamochodId == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // POST: Samochod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var samochod = await _context.Samochod.FindAsync(id);
            if (samochod != null)
            {
                _context.Samochod.Remove(samochod);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamochodExists(int id)
        {
            return _context.Samochod.Any(e => e.SamochodId == id);
        }
    }
}
