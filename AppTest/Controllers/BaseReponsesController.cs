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
    public class BaseReponsesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseReponsesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaseReponses
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseReponse.ToListAsync());
        }

        // GET: BaseReponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseReponse = await _context.BaseReponse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseReponse == null)
            {
                return NotFound();
            }

            return View(baseReponse);
        }

        // GET: BaseReponses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseReponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,fk_id_test,fk_id_question")] BaseReponse baseReponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseReponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseReponse);
        }

        // GET: BaseReponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseReponse = await _context.BaseReponse.FindAsync(id);
            if (baseReponse == null)
            {
                return NotFound();
            }
            return View(baseReponse);
        }

        // POST: BaseReponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,fk_id_test,fk_id_question")] BaseReponse baseReponse)
        {
            if (id != baseReponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseReponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseReponseExists(baseReponse.Id))
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
            return View(baseReponse);
        }

        // GET: BaseReponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseReponse = await _context.BaseReponse
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseReponse == null)
            {
                return NotFound();
            }

            return View(baseReponse);
        }

        // POST: BaseReponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseReponse = await _context.BaseReponse.FindAsync(id);
            if (baseReponse != null)
            {
                _context.BaseReponse.Remove(baseReponse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseReponseExists(int id)
        {
            return _context.BaseReponse.Any(e => e.Id == id);
        }
    }
}
