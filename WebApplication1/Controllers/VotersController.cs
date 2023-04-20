using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class VotersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VotersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Voters
        public async Task<IActionResult> Index()
        {
              return _context.Voters != null ? 
                          View(await _context.Voters.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Voters'  is null.");
        }

        // GET: Voters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voters == null)
            {
                return NotFound();
            }

            var voters = await _context.Voters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voters == null)
            {
                return NotFound();
            }

            return View(voters);
        }

        // GET: Voters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TRN,Id")] Voters voters)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voters);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voters);
        }

        // GET: Voters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voters == null)
            {
                return NotFound();
            }

            var voters = await _context.Voters.FindAsync(id);
            if (voters == null)
            {
                return NotFound();
            }
            return View(voters);
        }

        // POST: Voters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TRN,Id")] Voters voters)
        {
            if (id != voters.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voters);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VotersExists(voters.Id))
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
            return View(voters);
        }

        // GET: Voters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voters == null)
            {
                return NotFound();
            }

            var voters = await _context.Voters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voters == null)
            {
                return NotFound();
            }

            return View(voters);
        }

        // POST: Voters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Voters'  is null.");
            }
            var voters = await _context.Voters.FindAsync(id);
            if (voters != null)
            {
                _context.Voters.Remove(voters);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VotersExists(int id)
        {
          return (_context.Voters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
