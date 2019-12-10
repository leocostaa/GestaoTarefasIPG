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
    public class SetorsController : Controller
    {
    
        private readonly GestaoTarefasIPGDbContext _context;
        private const int NUMERO_DE_SETORES_POR_PAGINA = 5;
        private const int NUMERO_DE_PAGINAS_ANTES_DEPOIS = 3;
        public SetorsController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Setors
        public IActionResult Index(int page = 1)
        {
            decimal numberProducts = _context.Setor.Count();
            SetoresViewModel vm = new SetoresViewModel
            {
                Setores = _context.Setor
                //.OrderBy(p => p.Nome)
                .Skip((page - 1) * NUMERO_DE_SETORES_POR_PAGINA)
                .Take(NUMERO_DE_SETORES_POR_PAGINA),
                PaginaAtual = page,
                TotalPaginas = (int)Math.Ceiling(numberProducts / NUMERO_DE_SETORES_POR_PAGINA),
                PrimeiraPagina = Math.Max(1, page - NUMERO_DE_PAGINAS_ANTES_DEPOIS),
            };
            vm.UltimaPagina = Math.Min(vm.TotalPaginas, page + NUMERO_DE_PAGINAS_ANTES_DEPOIS);
            return View(vm);
        }

        // GET: Setors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _context.Setor
                .FirstOrDefaultAsync(m => m.SetorId == id);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // GET: Setors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SetorId,Nome,Local")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setor);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Setor criado com sucesso!";
                
                return View("ViewSUCESSSO");
            }

            return View(setor);
        }

        // GET: Setors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _context.Setor.FindAsync(id);
            if (setor == null)
            {
                return NotFound();
            }
            return View(setor);
        }

        // POST: Setors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SetorId,Nome,Local")] Setor setor)
        {
            if (id != setor.SetorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetorExists(setor.SetorId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Message = "Setor editado com sucesso!";
                return View("ViewSUCESSSO");
            }
            return View(setor);
        }

        // GET: Setors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var setor = await _context.Setor
                .FirstOrDefaultAsync(m => m.SetorId == id);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // POST: Setors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var setor = await _context.Setor.FindAsync(id);
            _context.Setor.Remove(setor);
            await _context.SaveChangesAsync();
            ViewBag.Message = "Setor apagado com sucesso!";
            return View("ViewSUCESSSO");
        }

        private bool SetorExists(int id)
        {
            return _context.Setor.Any(e => e.SetorId == id);
        }
    }
}
