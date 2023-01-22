using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ColaProject.Data;
using ColaProject.Models;

namespace ColaProject.Controllers
{
    public class StreetsController : Controller
    {
       
        private readonly BusStationSystemContext _context;

        public StreetsController(BusStationSystemContext context)
        {
            _context = context;
        }

        // GET: Streets
        public async Task<IActionResult> Index()
        {
            var busStationSystemContext = _context.Streets.Include(s => s.Area);
            return View(await busStationSystemContext.ToListAsync());
        }

        // GET: Streets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streets = await _context.Streets
                .Include(s => s.Area)
                .FirstOrDefaultAsync(m => m.StreetId == id);
            if (streets == null)
            {
                return NotFound();
            }

            return View(streets);
        }

        // GET: Streets/Create
        public IActionResult Create()
        {
           
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName");
            return View();
        }

        // POST: Streets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreetId,StreetCode,StreetName,AreaId")] Streets streets)
        {
            if (ModelState.IsValid)
            {
                _context.Add(streets);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", streets.AreaId);
            return View(streets);
        }

        // GET: Streets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streets = await _context.Streets.FindAsync(id);
            if (streets == null)
            {
                return NotFound();
            }
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", streets.AreaId);
            return View(streets);
        }

        // POST: Streets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StreetId,StreetCode,StreetName,AreaId")] Streets streets)
        {
            if (id != streets.StreetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(streets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreetsExists(streets.StreetId))
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
            ViewData["AreaId"] = new SelectList(_context.Areas, "AreaId", "AreaName", streets.AreaId);
            return View(streets);
        }

        // GET: Streets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streets = await _context.Streets
                .Include(s => s.Area)
                .FirstOrDefaultAsync(m => m.StreetId == id);
            if (streets == null)
            {
                return NotFound();
            }

            return View(streets);
        }

        // POST: Streets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var streets = await _context.Streets.FindAsync(id);
            _context.Streets.Remove(streets);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreetsExists(int id)
        {
            return _context.Streets.Any(e => e.StreetId == id);
        }
    }
}
