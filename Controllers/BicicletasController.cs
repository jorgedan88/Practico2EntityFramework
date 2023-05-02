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
    public class MotosController : Controller
    {
        private readonly BiciContext _context;

        public MotosController(BiciContext context)
        {
            _context = context;
        }

        // GET: Motos
        public async Task<IActionResult> Index()
        {
            return _context.Moto != null ?
                        View(await _context.Moto.ToListAsync()) :
                        Problem("Entity set 'BiciContext.Moto'  is null.");
        }

        // GET: Motos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Moto
                .FirstOrDefaultAsync(m => m.MotoID == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // GET: Motos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Motos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MotoID,Marca,Modelo,Categoria,EsElectrica,Color,Anio")] Moto bicicleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicicleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicicleta);
        }

        // GET: Motos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Moto.FindAsync(id);
            if (bicicleta == null)
            {
                return NotFound();
            }
            return View(bicicleta);
        }

        // POST: Motos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MotoID,Marca,Modelo,Categoria,EsElectrica,Color,Anio")] Moto bicicleta)
        {
            if (id != bicicleta.MotoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicicleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MotoExists(bicicleta.MotoID))
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
            return View(bicicleta);
        }

        // GET: Motos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Moto == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Moto
                .FirstOrDefaultAsync(m => m.MotoID == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // POST: Motos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Moto == null)
            {
                return Problem("Entity set 'BiciContext.Moto'  is null.");
            }
            var bicicleta = await _context.Moto.FindAsync(id);
            if (bicicleta != null)
            {
                _context.Moto.Remove(bicicleta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MotoExists(int id)
        {
            return (_context.Moto?.Any(e => e.MotoID == id)).GetValueOrDefault();
        }
    }
}
