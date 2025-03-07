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
    public class BaseQuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BaseQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BaseQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseQuestion.ToListAsync());
        }

        // GET: BaseQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseQuestion = await _context.BaseQuestion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseQuestion == null)
            {
                return NotFound();
            }

            return View(baseQuestion);
        }

        // GET: BaseQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaseQuestions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,intitule")] BaseQuestion baseQuestion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseQuestion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseQuestion);
        }

        // GET: BaseQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseQuestion = await _context.BaseQuestion.FindAsync(id);
            if (baseQuestion == null)
            {
                return NotFound();
            }
            return View(baseQuestion);
        }

        // POST: BaseQuestions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,intitule")] BaseQuestion baseQuestion)
        {
            if (id != baseQuestion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseQuestion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseQuestionExists(baseQuestion.Id))
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
            return View(baseQuestion);
        }

        // GET: BaseQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseQuestion = await _context.BaseQuestion
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseQuestion == null)
            {
                return NotFound();
            }

            return View(baseQuestion);
        }

        // POST: BaseQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseQuestion = await _context.BaseQuestion.FindAsync(id);
            if (baseQuestion != null)
            {
                _context.BaseQuestion.Remove(baseQuestion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseQuestionExists(int id)
        {
            return _context.BaseQuestion.Any(e => e.Id == id);
        }
    }
}
