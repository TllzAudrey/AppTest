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
    public class ResultatTestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ResultatTestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ResultatTests
        public async Task<IActionResult> Index()
        {
            return View(await _context.ResultatTest.ToListAsync());
        }

        // GET: ResultatTests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultatTest = await _context.ResultatTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultatTest == null)
            {
                return NotFound();
            }

            return View(resultatTest);
        }

        // GET: ResultatTests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ResultatTests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fk_id_test")] ResultatTest resultatTest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultatTest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultatTest);
        }

        // GET: ResultatTests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultatTest = await _context.ResultatTest.FindAsync(id);
            if (resultatTest == null)
            {
                return NotFound();
            }
            return View(resultatTest);
        }

        // POST: ResultatTests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fk_id_test")] ResultatTest resultatTest)
        {
            if (id != resultatTest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultatTest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultatTestExists(resultatTest.Id))
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
            return View(resultatTest);
        }

        // GET: ResultatTests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultatTest = await _context.ResultatTest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultatTest == null)
            {
                return NotFound();
            }

            return View(resultatTest);
        }

        // POST: ResultatTests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultatTest = await _context.ResultatTest.FindAsync(id);
            if (resultatTest != null)
            {
                _context.ResultatTest.Remove(resultatTest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultatTestExists(int id)
        {
            return _context.ResultatTest.Any(e => e.Id == id);
        }
    }
}
