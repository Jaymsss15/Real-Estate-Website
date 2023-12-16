using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PWEB_TP.Data;
using PWEB_TP.Models;
using TP_PWEB.Models;

namespace PWEB_TP.Controllers
{
    public class ArrendamentoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArrendamentoController(ApplicationDbContext context)
        {
            _context = context;
        }

       
        // GET: Arrendamento
        public async Task<IActionResult> Index()
        {
              return _context.Arrendamento != null ? 
                          View(await _context.Arrendamento.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Arrendamento'  is null.");
        }

        // GET: Arrendamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Arrendamento == null)
            {
                return NotFound();
            }

            var arrendamento = await _context.Arrendamento
                .FirstOrDefaultAsync(m => m.IdArrendamentos == id);
            if (arrendamento == null)
            {
                return NotFound();
            }

            return View(arrendamento);
        }

        // GET: Arrendamento/Create
        public IActionResult Create()
        {
              return View();
        }

        // POST: Arrendamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArrendamentos,DataInicio,DataFim,PeridoMinimoArrendamento,ValorArrendamento")] Arrendamento arrendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arrendamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arrendamento);
        }

        // GET: Arrendamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Arrendamento == null)
            {
                return NotFound();
            }

            var arrendamento = await _context.Arrendamento.FindAsync(id);
            if (arrendamento == null)
            {
                return NotFound();
            }
            return View(arrendamento);
        }

        // POST: Arrendamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArrendamentos,DataInicio,DataFim,PeridoMinimoArrendamento,ValorArrendamento")] Arrendamento arrendamento)
        {
            if (id != arrendamento.IdArrendamentos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arrendamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArrendamentoExists(arrendamento.IdArrendamentos))
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
            return View(arrendamento);
        }

        // GET: Arrendamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Arrendamento == null)
            {
                return NotFound();
            }

            var arrendamento = await _context.Arrendamento
                .FirstOrDefaultAsync(m => m.IdArrendamentos == id);
            if (arrendamento == null)
            {
                return NotFound();
            }

            return View(arrendamento);
        }

        // POST: Arrendamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Arrendamento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Arrendamento'  is null.");
            }
            var arrendamento = await _context.Arrendamento.FindAsync(id);
            if (arrendamento != null)
            {
                _context.Arrendamento.Remove(arrendamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArrendamentoExists(int id)
        {
          return (_context.Arrendamento?.Any(e => e.IdArrendamentos == id)).GetValueOrDefault();
        }
    }
}
