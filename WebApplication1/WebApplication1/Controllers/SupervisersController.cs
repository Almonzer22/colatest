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
    public class SupervisersController : Controller
    {
        private readonly BusStationSystemContext _context;

        public SupervisersController(BusStationSystemContext context)
        {
            _context = context;
        }

        // GET: Supervisers
        public async Task<IActionResult> Index()
        {
            var busStationSystemContext = _context.Supervisers.Include(s => s.CreatedByNavigation).Include(s => s.UpdatedByNavigation);
            return View(await busStationSystemContext.ToListAsync());
        }

        // GET: Supervisers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisers = await _context.Supervisers
                .Include(s => s.CreatedByNavigation)
                .Include(s => s.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.SuperviserId == id);
            if (supervisers == null)
            {
                return NotFound();
            }

            return View(supervisers);
        }

        // GET: Supervisers/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Name");
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Name");
            return View();
        }

        // POST: Supervisers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuperviserId,SuperviserName,UserName,UserPassword,SuperviserStatus,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Supervisers supervisers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supervisers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Name", supervisers.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Name", supervisers.UpdatedBy);
            return View(supervisers);
        }

        // GET: Supervisers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisers = await _context.Supervisers.FindAsync(id);
            if (supervisers == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Name", supervisers.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Name", supervisers.UpdatedBy);
            return View(supervisers);
        }

        // POST: Supervisers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuperviserId,SuperviserName,UserName,UserPassword,SuperviserStatus,CreatedBy,CreatedDate,UpdatedBy,UpdatedDate")] Supervisers supervisers)
        {
            if (id != supervisers.SuperviserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supervisers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupervisersExists(supervisers.SuperviserId))
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
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Name", supervisers.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Name", supervisers.UpdatedBy);
            return View(supervisers);
        }

        // GET: Supervisers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supervisers = await _context.Supervisers
                .Include(s => s.CreatedByNavigation)
                .Include(s => s.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.SuperviserId == id);
            if (supervisers == null)
            {
                return NotFound();
            }

            return View(supervisers);
        }

        // POST: Supervisers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supervisers = await _context.Supervisers.FindAsync(id);
            _context.Supervisers.Remove(supervisers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupervisersExists(int id)
        {
            return _context.Supervisers.Any(e => e.SuperviserId == id);
        }
    }
}
