using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clase7TareaRelaciones.Directors;
using Clase7TareaRelaciones.data;

namespace Clase7TareaRelaciones.Controllers
{
    public class DirectorController : Controller
    {
        private readonly MovieContext _context;

        public DirectorController(MovieContext context)
        {
            _context = context;
        }

        // GET: Director
        public async Task<IActionResult> Index()
        {
            var movieContext = _context.Directors.Include(d => d.Movie);
            return View(await movieContext.ToListAsync());
        }

        // GET: Director/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }

            var director = await _context.Directors
                .Include(d => d.Movie)
                .FirstOrDefaultAsync(m => m.DirectorId == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // GET: Director/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id");
            return View();
        }

        // POST: Director/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DirectorId,FirstName,LastName,MovieId")] Director director)
        {
            if (ModelState.IsValid)
            {
                _context.Add(director);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", director.MovieId);
            return View(director);
        }

        // GET: Director/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }

            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", director.MovieId);
            return View(director);
        }

        // POST: Director/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("DirectorId,FirstName,LastName,MovieId")] Director director)
        {
            if (id != director.DirectorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(director);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorExists(director.DirectorId))
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
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Id", director.MovieId);
            return View(director);
        }

        // GET: Director/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }

            var director = await _context.Directors
                .Include(d => d.Movie)
                .FirstOrDefaultAsync(m => m.DirectorId == id);
            if (director == null)
            {
                return NotFound();
            }

            return View(director);
        }

        // POST: Director/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Directors == null)
            {
                return Problem("Entity set 'MovieContext.Directors'  is null.");
            }
            var director = await _context.Directors.FindAsync(id);
            if (director != null)
            {
                _context.Directors.Remove(director);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorExists(string id)
        {
          return (_context.Directors?.Any(e => e.DirectorId == id)).GetValueOrDefault();
        }
    }
}
