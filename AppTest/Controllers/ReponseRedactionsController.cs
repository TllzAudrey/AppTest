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
    public class ReponseRedactionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReponseRedactionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReponseRedactions
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReponseRedaction.ToListAsync());
        }

        // GET: ReponseRedactions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseRedaction = await _context.ReponseRedaction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reponseRedaction == null)
            {
                return NotFound();
            }

            return View(reponseRedaction);
        }

        // GET: ReponseRedactions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReponseRedactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,reponse_candidat")] ReponseRedaction reponseRedaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reponseRedaction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reponseRedaction);
        }

        // GET: ReponseRedactions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseRedaction = await _context.ReponseRedaction.FindAsync(id);
            if (reponseRedaction == null)
            {
                return NotFound();
            }
            return View(reponseRedaction);
        }

        // POST: ReponseRedactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,reponse_candidat")] ReponseRedaction reponseRedaction)
        {
            if (id != reponseRedaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reponseRedaction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReponseRedactionExists(reponseRedaction.Id))
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
            return View(reponseRedaction);
        }

        // GET: ReponseRedactions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseRedaction = await _context.ReponseRedaction
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reponseRedaction == null)
            {
                return NotFound();
            }

            return View(reponseRedaction);
        }

        // POST: ReponseRedactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reponseRedaction = await _context.ReponseRedaction.FindAsync(id);
            if (reponseRedaction != null)
            {
                _context.ReponseRedaction.Remove(reponseRedaction);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReponseRedactionExists(int id)
        {
            return _context.ReponseRedaction.Any(e => e.Id == id);
        }
    }
}
