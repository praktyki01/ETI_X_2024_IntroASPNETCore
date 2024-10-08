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
    public class SamochodController : Controller
    {
        private readonly ETI_X_2024_IntroASPNETCoreContext _context;

        public SamochodController(ETI_X_2024_IntroASPNETCoreContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAuto()
        {
            var db = _context.Samochod.Include(s => s.Marka).Include(s => s.Kolor).Include(s => s.RodzajSilnika).Include(s => s.Model);
            return View(await db.ToListAsync());
        }
        public async Task<IActionResult> CreateAuto(int Cena, int Przebieg, int RokProdukcji, int Marka, int Model, int Kolor, int RodzajSilnika)
        {
            ViewBag.Marka = _context.Marka.ToList();
            ViewBag.Model = _context.Model.ToList();
            ViewBag.Kolor = _context.Kolor.ToList();
            ViewBag.RodzajSilnika = _context.RodzajSilnika.ToList();
            if (Cena != 0 && Przebieg != 0 && RokProdukcji != 0)
            {
                Samochod s = new Samochod();
                s.Cena = Cena;
                s.Przebieg = Przebieg;
                s.RokProdukcji = RokProdukcji;
                s.MarkaId = Marka;
                s.ModelId = Model;
                s.KolorId = Kolor;
                s.RodzajSilnikaId = RodzajSilnika;
                _context.Samochod.Add(s);
                _context.SaveChanges();
                return RedirectToAction("IndexAuto");
            }
            return View();
        }
        // GET: Samochod
        public async Task<IActionResult> Index()
        {
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //Filtrowanie według roku 2012
        public async Task<IActionResult> Index2()
        {
            var db = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model)
                .Include(s => s.RodzajSilnika).Where(n=>n.RokProdukcji==2012);
            return View(await db.ToListAsync());
        }
        //Filtrowanie według nazwy Marki z polem tekstowym
        public async Task<IActionResult> Index3(string marka)
        {
            if (marka == null)
            {
                var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).
                Include(s => s.Model).Include(s => s.RodzajSilnika);
                return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
            }else
            {
                var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).
                Include(s => s.Model).Include(s => s.RodzajSilnika).Where(s => s.Marka.Nazwa == marka);
                return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
            }

            
        }
        //wyszukiwanie po zakresie dat z listami rozwijanymi
        public async Task<IActionResult> Index4(int rokod,int rokdo)
        {
            if(rokod==0 || rokdo==0)
            {
                var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).
                Include(s => s.Model).Include(s => s.RodzajSilnika);
                return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
            }
            else
            { 
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).
                Include(s => s.Model).Include(s => s.RodzajSilnika).
                Where(s=>s.RokProdukcji >=rokod && s.RokProdukcji<=rokdo);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
            }
        }
        //Wyswietlenie ilości wszystkich samochodów
        public async Task<IActionResult> Index5()
        {
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            ViewBag.ilosc = eTI_X_2024_IntroASPNETCoreContext.Count();
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //Wyswietlenie wartości(sumy) wszystkich samochodów
        public async Task<IActionResult> Index6()
        {
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            ViewBag.suma = eTI_X_2024_IntroASPNETCoreContext.Sum(s=>s.Cena);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //Usuwanie wszystkich samochodów wskazanej marki
        public async Task<IActionResult> Index7(string marka)
        {
            var carsToDelete = _context.Samochod.Where(s => s.Marka.Nazwa == marka);
            if(carsToDelete.Count()>0)
            {
                _context.Samochod.RemoveRange(carsToDelete);
                _context.SaveChanges();
            }

            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //Usuwanie samochodów z użyciem listy rozwijanej
        public async Task<IActionResult> Index8(int MarkaId)
        {
            var carsToDelete = _context.Samochod.Where(s => s.Marka.MarkaId == MarkaId);
            if (carsToDelete.Count() > 0)
            {
                _context.Samochod.RemoveRange(carsToDelete);
                _context.SaveChanges();
            }
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "Nazwa");
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //Usuwanie samochodów z użyciem listy rozwijanej i uwzględnieniem roczników
        public async Task<IActionResult> Index9(int Roczniki)
        {
            ViewBag.Roczniki = _context.Samochod.Select(s => s.RokProdukcji);
            

            var carsToDelete = _context.Samochod.Where(s => s.RokProdukcji == Roczniki);
            if (carsToDelete.Count() > 0)
            {
                _context.Samochod.RemoveRange(carsToDelete);
                _context.SaveChanges();
            }            
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //każda kolumna inny kolor
        public async Task<IActionResult> Index10()
        {
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //wszystkie dane bez rodzaju silnika
        public async Task<IActionResult> Index11()
        {
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //kolor czcionki taki jak kolor po angielsku
        public async Task<IActionResult> Index12()
        {
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajSilnika);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        public async Task<IActionResult> Index13(int RodzajSilnikaId)
        {
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "Nazwa");
            var eTI_X_2024_IntroASPNETCoreContext = _context.Samochod.Include(s => s.Kolor).
                Include(s => s.Marka).Include(s => s.Model).
                Include(s => s.RodzajSilnika).Where(s=>s.RodzajSilnikaId==RodzajSilnikaId);
            return View(await eTI_X_2024_IntroASPNETCoreContext.ToListAsync());
        }
        //Klonowanie samochodów
        public async Task<IActionResult> Index15(int id)
        {
            var samochod = _context.Samochod.Where(s=>s.SamochodId==id).FirstOrDefault();
            if (samochod != null)
            {
                Samochod s = new Samochod();
                s.Cena = samochod.Cena;
                s.Przebieg = samochod.Przebieg;
                s.RokProdukcji = samochod.RokProdukcji;
                s.MarkaId = samochod.MarkaId;
                s.ModelId = samochod.ModelId;
                s.KolorId = samochod.KolorId;
                s.RodzajSilnikaId = samochod.RodzajSilnikaId;
                _context.Samochod.Add(s);
                _context.SaveChanges();
                return RedirectToAction("Index15", new {id=0});
            }
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
            ViewData["KolorId"] = new SelectList(_context.Kolor, "KolorId", "Nazwa");
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "Nazwa");
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "Nazwa");
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "Nazwa");
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
            ViewData["KolorId"] = new SelectList(_context.Kolor, "KolorId", "Nazwa", samochod.KolorId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "Nazwa", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "Nazwa", samochod.ModelId);
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "Nazwa", samochod.RodzajSilnikaId);
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
            ViewData["KolorId"] = new SelectList(_context.Kolor, "KolorId", "Nazwa", samochod.KolorId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "Nazwa", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "Nazwa", samochod.ModelId);
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "Nazwa", samochod.RodzajSilnikaId);
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
            ViewData["KolorId"] = new SelectList(_context.Kolor, "KolorId", "Nazwa", samochod.KolorId);
            ViewData["MarkaId"] = new SelectList(_context.Marka, "MarkaId", "Nazwa", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Model, "ModelId", "Nazwa", samochod.ModelId);
            ViewData["RodzajSilnikaId"] = new SelectList(_context.RodzajSilnika, "RodzajSilnikaId", "Nazwa", samochod.RodzajSilnikaId);
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
