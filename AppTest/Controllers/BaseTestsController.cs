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
    public class BaseTestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseTestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaseTests
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseTest.ToListAsync());
        }

        // GET: BaseTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseTest = await _context.BaseTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseTest == null)
            {
                return NotFound();
            }

            return View(baseTest);
        }

        // GET: BaseTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nom,fk_id_entreprise")] BaseTest baseTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseTest);
        }

        // GET: BaseTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseTest = await _context.BaseTest.FindAsync(id);
            if (baseTest == null)
            {
                return NotFound();
            }
            return View(baseTest);
        }

        // POST: BaseTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nom,fk_id_entreprise")] BaseTest baseTest)
        {
            if (id != baseTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseTestExists(baseTest.Id))
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
            return View(baseTest);
        }

        // GET: BaseTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseTest = await _context.BaseTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseTest == null)
            {
                return NotFound();
            }

            return View(baseTest);
        }

        // POST: BaseTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseTest = await _context.BaseTest.FindAsync(id);
            if (baseTest != null)
            {
                _context.BaseTest.Remove(baseTest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseTestExists(int id)
        {
            return _context.BaseTest.Any(e => e.Id == id);
        }
    }
}
