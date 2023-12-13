using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PWEB_TP.Data;
using TP_PWEB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;

namespace PWEB_TP.Controllers
{
    public class HabitacoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HabitacoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Habitacoes
        [Authorize]
        public async Task<IActionResult> Index(string sortOrder)
        {

            var habitacoes = _context.Habitacoes.AsQueryable();

            ViewData["PrecoSortParm"] = sortOrder == "preco_desc" ? "preco_asc" : "preco_desc";
            ViewData["AvaliacaoSortParm"] = sortOrder == "avaliacao_desc" ? "avaliacao_asc" : "avaliacao_desc";
            habitacoes = from h in _context.Habitacoes
                         select h;

            switch (sortOrder)
            {
                case "preco_desc":
                    habitacoes = habitacoes.OrderByDescending(h => h.Preco);
                    break;
                case "preco_asc":
                    habitacoes = habitacoes.OrderBy(h => h.Preco);
                    break;
                case "avaliacao_desc":
                    habitacoes = habitacoes.OrderByDescending(h => h.Avaliacao);
                    break;
                case "avaliacao_asc":
                    habitacoes = habitacoes.OrderBy(h => h.Avaliacao);
                    break;
                default:
                    habitacoes = habitacoes.OrderBy(h => h.Preco);
                    break;
            }


            var habitacoesList = await habitacoes.ToListAsync();


            return View("Index", habitacoesList);
        }

        // GET: Habitacoes/Procurar
        public async Task<IActionResult> ProcurarHab()
        {
            return View();
        }
        public async Task<IActionResult> Filtrar()
        {
            return View();
        }
        public async Task<IActionResult> Arrendar(int? id)
        {
            if (id == null || _context.Habitacoes == null)
            {
                return NotFound();
            }

            var habitacoes = await _context.Habitacoes
                .FirstOrDefaultAsync(m => m.IdHabitacoes == id);
            if (habitacoes == null)
            {
                return NotFound();
            }

            return View(habitacoes);
        }
        // GET: Habitacoes/Resultados
        public async Task<IActionResult> ResultadosDefault(String localizacao,string tipo, string tipo2, string locador, string sortOrder)
        {
            //tipo É o tipo de Habitacao definida no ProcurarHab
            //tipo2 É o tipo de Habitacao definida no Filtrar

            var habitacoes = _context.Habitacoes.AsQueryable();

            ViewData["PrecoSortParm"] = sortOrder == "preco_desc" ? "preco_asc" : "preco_desc";
            ViewData["AvaliacaoSortParm"] = sortOrder == "avaliacao_desc" ? "avaliacao_asc" : "avaliacao_desc";
            habitacoes = from h in _context.Habitacoes
                         select h;

            switch (sortOrder)
            {
                case "preco_desc":
                    habitacoes = habitacoes.OrderByDescending(h => h.Preco);
                    break;
                case "preco_asc":
                    habitacoes = habitacoes.OrderBy(h => h.Preco);
                    break;
                case "avaliacao_desc":
                    habitacoes = habitacoes.OrderByDescending(h => h.Avaliacao);
                    break;
                case "avaliacao_asc":
                    habitacoes = habitacoes.OrderBy(h => h.Avaliacao);
                    break;
                default:
                    habitacoes = habitacoes.OrderBy(h => h.Preco);
                    break;
            }

            if (localizacao != null)
            {
                habitacoes = habitacoes.Where(j => j.Localizacao.Contains(localizacao));
            }
            if (locador != null)
            {
                habitacoes = habitacoes.Where(j => j.Locador.Contains(locador));
            }

            if (tipo != null) { 
            habitacoes = habitacoes.Where(j => j.Tipo.Contains(tipo));
                }

            if (tipo2 != null)
            {
                habitacoes = habitacoes.Where(j => j.Tipo.Contains(tipo2));
            }

            string disponivel = "TRUE";
            habitacoes = habitacoes.Where(j => j.Disponivel.Contains(disponivel));

            var habitacoesResultado = await habitacoes.ToListAsync();

            return View("IndexDefault", habitacoesResultado);
        }



            // GET: Habitacoes/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habitacoes == null)
            {
                return NotFound();
            }

            var habitacoes = await _context.Habitacoes
                .FirstOrDefaultAsync(m => m.IdHabitacoes == id);
            if (habitacoes == null)
            {
                return NotFound();
            }

            return View(habitacoes);
        }

        // GET: Habitacoes/Details/5
        public async Task<IActionResult> DetailsDefault(int? id)
        {
            if (id == null || _context.Habitacoes == null)
            {
                return NotFound();
            }

            var habitacoes = await _context.Habitacoes
                .FirstOrDefaultAsync(m => m.IdHabitacoes == id);
            if (habitacoes == null)
            {
                return NotFound();
            }

            return View(habitacoes);
        }

        // GET: Habitacoes/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habitacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHabitacoes,Localizacao,Tipo,Preco,Disponivel,DataInicioContrato,DataFimContrato,Locador,Avaliacao")] Habitacoes habitacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habitacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habitacoes);
        }

        // GET: Habitacoes/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habitacoes == null)
            {
                return NotFound();
            }

            var habitacoes = await _context.Habitacoes.FindAsync(id);
            if (habitacoes == null)
            {
                return NotFound();
            }
            return View(habitacoes);
        }

        // POST: Habitacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHabitacoes,Localizacao,Tipo,Preco,Disponivel,DataInicioContrato,DataFimContrato,Locador,Avaliacao")] Habitacoes habitacoes)
        {
            if (id != habitacoes.IdHabitacoes)
            {
                return NotFound();
            }

            // Adicione a validação para a avaliação estar no intervalo de 0 a 10
            if (habitacoes.Avaliacao < 0 || habitacoes.Avaliacao > 10)
            {
                ModelState.AddModelError("Avaliacao", "A avaliação deve estar no intervalo de 0 a 10.");
            }

            if (string.IsNullOrWhiteSpace(habitacoes.Tipo))
            {
                ModelState.AddModelError("Tipo", "The Tipo field is required");
            }


            // Verifique se o Locador está vazio e, se estiver, defina Avaliacao como vazio
            if (string.IsNullOrWhiteSpace(habitacoes.Locador))
            {
                habitacoes.Avaliacao = 0; // Ou outro valor que indique "vazio"
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habitacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitacoesExists(habitacoes.IdHabitacoes))
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
            return View(habitacoes);
        }

        // GET: Habitacoes/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habitacoes == null)
            {
                return NotFound();
            }

            var habitacoes = await _context.Habitacoes
                .FirstOrDefaultAsync(m => m.IdHabitacoes == id);
            if (habitacoes == null)
            {
                return NotFound();
            }

            return View(habitacoes);
        }

        // POST: Habitacoes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habitacoes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Habitacoes'  is null.");
            }
            var habitacoes = await _context.Habitacoes.FindAsync(id);
            if (habitacoes != null)
            {
                _context.Habitacoes.Remove(habitacoes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitacoesExists(int id)
        {
          return (_context.Habitacoes?.Any(e => e.IdHabitacoes == id)).GetValueOrDefault();
        }
    }
}
