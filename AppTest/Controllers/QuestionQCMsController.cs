﻿using System;
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
    public class QuestionQCMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionQCMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionQCMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestionQCM.ToListAsync());
        }

        // GET: QuestionQCMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionQCM = await _context.QuestionQCM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionQCM == null)
            {
                return NotFound();
            }

            return View(questionQCM);
        }

        // GET: QuestionQCMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionQCMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,reponse_possible,reponse_correct,intitule")] QuestionQCM questionQCM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionQCM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionQCM);
        }

        // GET: QuestionQCMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionQCM = await _context.QuestionQCM.FindAsync(id);
            if (questionQCM == null)
            {
                return NotFound();
            }
            return View(questionQCM);
        }

        // POST: QuestionQCMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,reponse_possible,reponse_correct,intitule")] QuestionQCM questionQCM)
        {
            if (id != questionQCM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionQCM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionQCMExists(questionQCM.Id))
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
            return View(questionQCM);
        }

        // GET: QuestionQCMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionQCM = await _context.QuestionQCM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionQCM == null)
            {
                return NotFound();
            }

            return View(questionQCM);
        }

        // POST: QuestionQCMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionQCM = await _context.QuestionQCM.FindAsync(id);
            if (questionQCM != null)
            {
                _context.QuestionQCM.Remove(questionQCM);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionQCMExists(int id)
        {
            return _context.QuestionQCM.Any(e => e.Id == id);
        }
    }
}
