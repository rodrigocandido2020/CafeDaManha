using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CafeDaManha.Models;
using CafeDaManha.Infra;

namespace CafeDaManha.Controllers
{
    public class CadastroCafesController : Controller
    {
        private readonly CafeDaManhaContext _context;

        public CadastroCafesController(CafeDaManhaContext context)
        {
            _context = context;
        }

        // GET: CadastroCafes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroCafe.ToListAsync());
        }

        // GET: CadastroCafes/Details/5
        [Route (template: "Detalhes")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCafe = await _context.CadastroCafe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroCafe == null)
            {
                return NotFound();
            }

            return View(cadastroCafe);
        }

        // GET: CadastroCafes/Create
        [Route(template: "Criar")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroCafes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route(template: "Criar")]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Alimento")] CadastroCafe cadastroCafe)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cadastroCafe);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                
                ModelState.AddModelError("", "Incapaz de salvar as alterações. " +
                    "Tente novamente e se o problema persistir " +
                    "consulte o administrador do sistema..");
            }
            return View(cadastroCafe);
        }

        // GET: CadastroCafes/Edit/5
        [Route(template: "Editar")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCafe = await _context.CadastroCafe.FindAsync(id);
            if (cadastroCafe == null)
            {
                return NotFound();
            }
            return View(cadastroCafe);
        }

        // POST: CadastroCafes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to..
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route(template: "Editar")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Alimento")] CadastroCafe cadastroCafe)
        {
            if (id != cadastroCafe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroCafe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroCafeExists(cadastroCafe.Id))
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
            return View(cadastroCafe);
        }

        // GET: CadastroCafes/Delete/5
        [Route(template: "Apagar")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroCafe = await _context.CadastroCafe
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cadastroCafe == null)
            {
                return NotFound();
            }

            return View(cadastroCafe);
        }

        // POST: CadastroCafes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route(template: "Apagar")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroCafe = await _context.CadastroCafe.FindAsync(id);
            _context.CadastroCafe.Remove(cadastroCafe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroCafeExists(int id)
        {
            return _context.CadastroCafe.Any(e => e.Id == id);
        }
    }
}
