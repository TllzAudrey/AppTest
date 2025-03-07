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
    public class ReponseQCMsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReponseQCMsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReponseQCMs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ReponseQCM.ToListAsync());
        }

        // GET: ReponseQCMs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseQCM = await _context.ReponseQCM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reponseQCM == null)
            {
                return NotFound();
            }

            return View(reponseQCM);
        }

        // GET: ReponseQCMs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ReponseQCMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,reponse_candidat")] ReponseQCM reponseQCM)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reponseQCM);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reponseQCM);
        }

        // GET: ReponseQCMs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseQCM = await _context.ReponseQCM.FindAsync(id);
            if (reponseQCM == null)
            {
                return NotFound();
            }
            return View(reponseQCM);
        }

        // POST: ReponseQCMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,reponse_candidat")] ReponseQCM reponseQCM)
        {
            if (id != reponseQCM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reponseQCM);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReponseQCMExists(reponseQCM.Id))
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
            return View(reponseQCM);
        }

        // GET: ReponseQCMs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponseQCM = await _context.ReponseQCM
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reponseQCM == null)
            {
                return NotFound();
            }

            return View(reponseQCM);
        }

        // POST: ReponseQCMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reponseQCM = await _context.ReponseQCM.FindAsync(id);
            if (reponseQCM != null)
            {
                _context.ReponseQCM.Remove(reponseQCM);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReponseQCMExists(int id)
        {
            return _context.ReponseQCM.Any(e => e.Id == id);
        }
    }
}
