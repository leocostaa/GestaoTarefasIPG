using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;

namespace GestaoTarefasIPG.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly GestaoTarefasIPGDbContext _context;
        private const int NUMERO_DE_COLABORADORES_POR_PAGINA = 5;
        private const int NUMERO_DE_PAGINAS_ANTES_DEPOIS = 3;

        public ColaboradoresController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Colaboradores
        public IActionResult Index(int page = 1)
        {
            decimal numberProducts = _context.Colaboradores.Count();
            ColaboradoresViewModel vm = new ColaboradoresViewModel
            {
                Colaboradores = _context.Colaboradores
                //.OrderBy(p => p.Nome)
                .Skip((page - 1) * NUMERO_DE_COLABORADORES_POR_PAGINA)
                .Take(NUMERO_DE_COLABORADORES_POR_PAGINA),
                PaginaAtual = page,
                TotalPaginas = (int)Math.Ceiling(numberProducts / NUMERO_DE_COLABORADORES_POR_PAGINA),
                PrimeiraPagina = Math.Max(1, page - NUMERO_DE_PAGINAS_ANTES_DEPOIS),
            };
            vm.UltimaPagina = Math.Min(vm.TotalPaginas, page + NUMERO_DE_PAGINAS_ANTES_DEPOIS);
            return View(vm);
        }
        

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradores = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.ColaboradoresId == id);
            if (colaboradores == null)
            {
                return NotFound();
            }

            return View(colaboradores);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,ColaboradoresId,Profissao,DataNascimento,email")] Colaboradores colaboradores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaboradores);
        }

        // GET: Colaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradores = await _context.Colaboradores.FindAsync(id);
            if (colaboradores == null)
            {
                return NotFound();
            }
            return View(colaboradores);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,ColaboradoresId,Profissao,DataNascimento,email")] Colaboradores colaboradores)
        {

            if (id != colaboradores.ColaboradoresId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradoresExists(colaboradores.ColaboradoresId))
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
            return View(colaboradores);
        }

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradores = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.ColaboradoresId == id);
            if (colaboradores == null)
            {
                return NotFound();
            }

            return View(colaboradores);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var colaboradores = await _context.Colaboradores.FindAsync(id);
            _context.Colaboradores.Remove(colaboradores);
            await _context.SaveChangesAsync();
            ViewBag.Message = "Setor apagado com sucesso!";
            return View("ViewSUCESSSO");
        }
        
       
        private bool ColaboradoresExists(int id)
        {
            return _context.Colaboradores.Any(e => e.ColaboradoresId == id);
        }
    }
}
