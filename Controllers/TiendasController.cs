using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Practico2HDP.Data;
using Practico2HDP.Models;

namespace Practico2HDP.Controllers
{
    public class ConcesionariosController : Controller
    {
        private readonly BiciContext _context;

        public ConcesionariosController(BiciContext context)
        {
            _context = context;
        }

        // GET: Concesionarios
        public async Task<IActionResult> Index()
        {
            return _context.Concesionario != null ?
                        View(await _context.Concesionario.ToListAsync()) :
                        Problem("Entity set 'BiciContext.Concesionario'  is null.");
        }

        // GET: Concesionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Concesionario == null)
            {
                return NotFound();
            }

            var tienda = await _context.Concesionario
                .FirstOrDefaultAsync(m => m.ConcesionarioID == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // GET: Concesionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Concesionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConcesionarioID,RazonSocial,Direccion,Tel,Email,Web")] Concesionario tienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tienda);
        }

        // GET: Concesionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Concesionario == null)
            {
                return NotFound();
            }

            var tienda = await _context.Concesionario.FindAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            return View(tienda);
        }

        // POST: Concesionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConcesionarioID,RazonSocial,Direccion,Tel,Email,Web")] Concesionario tienda)
        {
            if (id != tienda.ConcesionarioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConcesionarioExists(tienda.ConcesionarioID))
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
            return View(tienda);
        }

        // GET: Concesionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Concesionario == null)
            {
                return NotFound();
            }

            var tienda = await _context.Concesionario
                .FirstOrDefaultAsync(m => m.ConcesionarioID == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // POST: Concesionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Concesionario == null)
            {
                return Problem("Entity set 'BiciContext.Concesionario'  is null.");
            }
            var tienda = await _context.Concesionario.FindAsync(id);
            if (tienda != null)
            {
                _context.Concesionario.Remove(tienda);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConcesionarioExists(int id)
        {
            return (_context.Concesionario?.Any(e => e.ConcesionarioID == id)).GetValueOrDefault();
        }
    }
}
