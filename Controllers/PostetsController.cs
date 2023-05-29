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
    public class PostetsController : Controller
    {
        private readonly CSDbContext _context;

        public PostetsController(CSDbContext context)
        {
            _context = context;
        }

        // GET: Postets
        public async Task<IActionResult> Index()
        {
              return _context.Postets != null ? 
                          View(await _context.Postets.ToListAsync()) :
                          Problem("Entity set 'CSDbContext.Postets'  is null.");
        }

        // GET: Postets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Postets == null)
            {
                return NotFound();
            }

            var postet = await _context.Postets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postet == null)
            {
                return NotFound();
            }

            return View(postet);
        }

        // GET: Postets/Create
        public IActionResult Create()
        {
            return View();
        }
      
        // POST: Postets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulli,Pershkrimi,CreatedDate,Autoret")] Postet postet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postet);
        }

        // GET: Postets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Postets == null)
            {
                return NotFound();
            }

            var postet = await _context.Postets.FindAsync(id);
            if (postet == null)
            {
                return NotFound();
            }
            return View(postet);
        }

        // POST: Postets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulli,Pershkrimi,CreatedDate,Autoret")] Postet postet)
        {
            if (id != postet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostetExists(postet.Id))
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
            return View(postet);
        }

        // GET: Postets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Postets == null)
            {
                return NotFound();
            }

            var postet = await _context.Postets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postet == null)
            {
                return NotFound();
            }

            return View(postet);
        }

        // GET: Postets
        public async Task<IActionResult> Postimet()
        {
            return _context.Postets != null ?
                        View(await _context.Postets.ToListAsync()) :
                        Problem("Entity set 'CSDbContext.Postets'  is null.");
        }

        // POST: Postets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Postets == null)
            {
                return Problem("Entity set 'CSDbContext.Postets'  is null.");
            }
            var postet = await _context.Postets.FindAsync(id);
            if (postet != null)
            {
                _context.Postets.Remove(postet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostetExists(int id)
        {
          return (_context.Postets?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
