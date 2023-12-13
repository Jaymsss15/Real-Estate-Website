using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PWEB_TP.Data;
using PWEB_TP.Models;

namespace PWEB_TP.Controllers
{
    public class LocadoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocadoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Locadores
        public async Task<IActionResult> Index()
        {
              return _context.Locadores != null ? 
                          View(await _context.Locadores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Locadores'  is null.");
        }

        // GET: Locadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locadores == null)
            {
                return NotFound();
            }

            var locadores = await _context.Locadores
                .FirstOrDefaultAsync(m => m.IdLocadores == id);
            if (locadores == null)
            {
                return NotFound();
            }

            return View(locadores);
        }

        // GET: Locadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLocadores,NomeLocador,EstadoSubscricao")] Locadores locadores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locadores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locadores);
        }

        // GET: Locadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locadores == null)
            {
                return NotFound();
            }

            var locadores = await _context.Locadores.FindAsync(id);
            if (locadores == null)
            {
                return NotFound();
            }
            return View(locadores);
        }

        // POST: Locadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLocadores,NomeLocador,EstadoSubscricao")] Locadores locadores)
        {
            if (id != locadores.IdLocadores)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocadoresExists(locadores.IdLocadores))
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
            return View(locadores);
        }

        // GET: Locadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locadores == null)
            {
                return NotFound();
            }

            var locadores = await _context.Locadores
                .FirstOrDefaultAsync(m => m.IdLocadores == id);
            if (locadores == null)
            {
                return NotFound();
            }

            return View(locadores);
        }

        // POST: Locadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Locadores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Locadores'  is null.");
            }
            var locadores = await _context.Locadores.FindAsync(id);
            if (locadores != null)
            {
                _context.Locadores.Remove(locadores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocadoresExists(int id)
        {
          return (_context.Locadores?.Any(e => e.IdLocadores == id)).GetValueOrDefault();
        }
    }
}
