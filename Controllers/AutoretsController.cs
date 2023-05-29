using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CSBLOG.Data;
using CSBLOG.Models;

namespace CSBLOG.Controllers
{
    public class AutoretsController : Controller
    {
        private readonly CSDbContext _context;

        public AutoretsController(CSDbContext context)
        {
            _context = context;
        }

        // GET: Autorets
        public async Task<IActionResult> Index()
        {
              return _context.Autorets != null ? 
                          View(await _context.Autorets.ToListAsync()) :
                          Problem("Entity set 'CSDbContext.Autorets'  is null.");
        }

        // GET: Autorets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autorets == null)
            {
                return NotFound();
            }

            var autoret = await _context.Autorets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoret == null)
            {
                return NotFound();
            }

            return View(autoret);
        }

        // GET: Autorets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autorets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Emri,Mbiemri,Email,Password")] Autoret autoret)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoret);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoret);
        }

        // GET: Autorets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autorets == null)
            {
                return NotFound();
            }

            var autoret = await _context.Autorets.FindAsync(id);
            if (autoret == null)
            {
                return NotFound();
            }
            return View(autoret);
        }

        // POST: Autorets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Emri,Mbiemri,Email,Password")] Autoret autoret)
        {
            if (id != autoret.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoret);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoretExists(autoret.Id))
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
            return View(autoret);
        }

        // GET: Autorets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autorets == null)
            {
                return NotFound();
            }

            var autoret = await _context.Autorets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (autoret == null)
            {
                return NotFound();
            }

            return View(autoret);
        }

        // POST: Autorets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autorets == null)
            {
                return Problem("Entity set 'CSDbContext.Autorets'  is null.");
            }
            var autoret = await _context.Autorets.FindAsync(id);
            if (autoret != null)
            {
                _context.Autorets.Remove(autoret);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoretExists(int id)
        {
          return (_context.Autorets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
