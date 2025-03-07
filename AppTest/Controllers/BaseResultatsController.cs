using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppTest.Data;
using AppTest.Models;

namespace AppTest.Controllers
{
    public class BaseResultatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseResultatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaseResultats
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseResultat.ToListAsync());
        }

        // GET: BaseResultats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseResultat = await _context.BaseResultat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseResultat == null)
            {
                return NotFound();
            }

            return View(baseResultat);
        }

        // GET: BaseResultats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseResultats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Note")] BaseResultat baseResultat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseResultat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseResultat);
        }

        // GET: BaseResultats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseResultat = await _context.BaseResultat.FindAsync(id);
            if (baseResultat == null)
            {
                return NotFound();
            }
            return View(baseResultat);
        }

        // POST: BaseResultats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Note")] BaseResultat baseResultat)
        {
            if (id != baseResultat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseResultat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseResultatExists(baseResultat.Id))
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
            return View(baseResultat);
        }

        // GET: BaseResultats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseResultat = await _context.BaseResultat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseResultat == null)
            {
                return NotFound();
            }

            return View(baseResultat);
        }

        // POST: BaseResultats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseResultat = await _context.BaseResultat.FindAsync(id);
            if (baseResultat != null)
            {
                _context.BaseResultat.Remove(baseResultat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseResultatExists(int id)
        {
            return _context.BaseResultat.Any(e => e.Id == id);
        }
    }
}
