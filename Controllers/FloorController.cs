using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FloorForce2.Models;

namespace FloorForce2.Controllers
{
    public class FloorController : Controller
    {
        private readonly MvcFloorContext _context;

        public FloorController(MvcFloorContext context)
        {
            _context = context;
        }

        // GET: Floor
        public async Task<IActionResult> Index()
        {
              return _context.Floor != null ? 
                          View(await _context.Floor.ToListAsync()) :
                          Problem("Entity set 'MvcFloorContext.Floor'  is null.");
        }

        // GET: Floor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Floor == null)
            {
                return NotFound();
            }

            var floor = await _context.Floor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (floor == null)
            {
                return NotFound();
            }

            return View(floor);
        }

        // GET: Floor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Floor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Desc,Price")] Floor floor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(floor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(floor);
        }

        // GET: Floor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Floor == null)
            {
                return NotFound();
            }

            var floor = await _context.Floor.FindAsync(id);
            if (floor == null)
            {
                return NotFound();
            }
            return View(floor);
        }

        // POST: Floor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Desc,Price")] Floor floor)
        {
            if (id != floor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(floor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FloorExists(floor.Id))
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
            return View(floor);
        }

        // GET: Floor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Floor == null)
            {
                return NotFound();
            }

            var floor = await _context.Floor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (floor == null)
            {
                return NotFound();
            }

            return View(floor);
        }

        // POST: Floor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Floor == null)
            {
                return Problem("Entity set 'MvcFloorContext.Floor'  is null.");
            }
            var floor = await _context.Floor.FindAsync(id);
            if (floor != null)
            {
                _context.Floor.Remove(floor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FloorExists(int id)
        {
          return (_context.Floor?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
