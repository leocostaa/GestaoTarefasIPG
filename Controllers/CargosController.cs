﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoTarefasIPG.Models;
using Microsoft.AspNetCore.Authorization;

namespace GestaoTarefasIPG.Controllers
{
    public class CargosController : Controller
    {
        private readonly GestaoTarefasIPGDbContext _context;
        private const int NUMERO_DE_CARGOS_POR_PAGINA = 5;
        private const int NUMERO_DE_PAGINAS_ANTES_DEPOIS = 3;

        public CargosController(GestaoTarefasIPGDbContext context)
        {
            _context = context;
        }

        // GET: Cargos
        public IActionResult Index(int page = 1)
        {
            decimal numberProducts = _context.Cargos.Count();
            CargosViewModel vm = new CargosViewModel
            {
                Cargos = _context.Cargos
                //.OrderBy(p => p.Nome)
                .Skip((page - 1) * NUMERO_DE_CARGOS_POR_PAGINA)
                .Take(NUMERO_DE_CARGOS_POR_PAGINA),
                PaginaAtual = page,
                TotalPaginas = (int)Math.Ceiling(numberProducts / NUMERO_DE_CARGOS_POR_PAGINA),
                PrimeiraPagina = Math.Max(1, page - NUMERO_DE_PAGINAS_ANTES_DEPOIS),
            };
            vm.UltimaPagina = Math.Min(vm.TotalPaginas, page + NUMERO_DE_PAGINAS_ANTES_DEPOIS);
            return View(vm);
        }
        // GET: Cargos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargos = await _context.Cargos
                .FirstOrDefaultAsync(m => m.CargosId == id);
            if (cargos == null)
            {
                return NotFound();
            }

            return View(cargos);
        }

        // GET: Cargos/Create
        [Authorize(Roles = "admin,func")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CargosId,Nome,Superior")] Cargos cargos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cargos);
                await _context.SaveChangesAsync();
                ViewBag.Message = "Setor criado com sucesso!";
                return View("ViewSUCESSSO");
            }
            return View(cargos);
        }

        // GET: Cargos/Edit/5
        [Authorize(Roles = "admin,func")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargos = await _context.Cargos.FindAsync(id);
            if (cargos == null)
            {
                return NotFound();
            }
            return View(cargos);
        }

        // POST: Cargos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CargosId,Nome,Superior")] Cargos cargos)
        {
            if (id != cargos.CargosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cargos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CargosExists(cargos.CargosId))
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
            return View(cargos);
        }

        // GET: Cargos/Delete/5
        [Authorize(Roles = "admin,func")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cargos = await _context.Cargos
                .FirstOrDefaultAsync(m => m.CargosId == id);
            if (cargos == null)
            {
                return NotFound();
            }

            return View(cargos);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cargos = await _context.Cargos.FindAsync(id);
            _context.Cargos.Remove(cargos);
            await _context.SaveChangesAsync();
            ViewBag.Message = "Setor apagado com sucesso!";
            return View("ViewSUCESSSO");
        }

        private bool CargosExists(int id)
        {
            return _context.Cargos.Any(e => e.CargosId == id);
        }
    }
}
