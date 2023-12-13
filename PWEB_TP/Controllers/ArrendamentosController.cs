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
    public class ArrendamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArrendamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Arrendamentos
        public async Task<IActionResult> Index()
        {
              return _context.Arrendamentos != null ? 
                          View(await _context.Arrendamentos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Arrendamentos'  is null.");
        }

        // GET: Arrendamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Arrendamentos == null)
            {
                return NotFound();
            }

            var arrendamentos = await _context.Arrendamentos
                .FirstOrDefaultAsync(m => m.IdArrendamentos == id);
            if (arrendamentos == null)
            {
                return NotFound();
            }

            return View(arrendamentos);
        }

        // GET: Arrendamentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arrendamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArrendamentos,DataInicio,DataFim,PeridoMinimoArrendamento,ValorArrendamento")] Arrendamentos arrendamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrendamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arrendamentos);
        }

        // GET: Arrendamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Arrendamentos == null)
            {
                return NotFound();
            }

            var arrendamentos = await _context.Arrendamentos.FindAsync(id);
            if (arrendamentos == null)
            {
                return NotFound();
            }
            return View(arrendamentos);
        }

        // POST: Arrendamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArrendamentos,DataInicio,DataFim,PeridoMinimoArrendamento,ValorArrendamento")] Arrendamentos arrendamentos)
        {
            if (id != arrendamentos.IdArrendamentos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrendamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArrendamentosExists(arrendamentos.IdArrendamentos))
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
            return View(arrendamentos);
        }

        // GET: Arrendamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Arrendamentos == null)
            {
                return NotFound();
            }

            var arrendamentos = await _context.Arrendamentos
                .FirstOrDefaultAsync(m => m.IdArrendamentos == id);
            if (arrendamentos == null)
            {
                return NotFound();
            }

            return View(arrendamentos);
        }

        // POST: Arrendamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Arrendamentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Arrendamentos'  is null.");
            }
            var arrendamentos = await _context.Arrendamentos.FindAsync(id);
            if (arrendamentos != null)
            {
                _context.Arrendamentos.Remove(arrendamentos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArrendamentosExists(int id)
        {
          return (_context.Arrendamentos?.Any(e => e.IdArrendamentos == id)).GetValueOrDefault();
        }
    }
}
