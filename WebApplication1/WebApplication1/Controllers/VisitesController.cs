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
    public class VisitesController : Controller
    {
        private readonly BusStationSystemContext _context;

        public VisitesController(BusStationSystemContext context)
        {
            _context = context;
        }

        // GET: Visites
        public async Task<IActionResult> Index()
        {
            var busStationSystemContext = _context.Visites.Include(v => v.Kiosk).Include(v => v.Operator).Include(v => v.Superviser);
            return View(await busStationSystemContext.ToListAsync());
        }

        // GET: Visites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visites = await _context.Visites
                .Include(v => v.Kiosk)
                .Include(v => v.Operator)
                .Include(v => v.Superviser)
                .FirstOrDefaultAsync(m => m.VisiteId == id);
            if (visites == null)
            {
                return NotFound();
            }

            return View(visites);
        }

        // GET: Visites/Create
        public IActionResult Create()
        {
            ViewData["KioskId"] = new SelectList(_context.Kiosks, "KioskId", "KioskCode");
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorId", "Address");
            ViewData["SuperviserId"] = new SelectList(_context.Supervisers, "SuperviserId", "SuperviserName");
            return View();
        }

        // POST: Visites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VisiteId,KioskId,SuperviserId,OperatorId,VisiteDate,VisitStatuse,Clean,Recommendation,Note,ImagePath")] Visites visites)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visites);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KioskId"] = new SelectList(_context.Kiosks, "KioskId", "KioskCode", visites.KioskId);
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorId", "Address", visites.OperatorId);
            ViewData["SuperviserId"] = new SelectList(_context.Supervisers, "SuperviserId", "SuperviserName", visites.SuperviserId);
            return View(visites);
        }

        // GET: Visites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visites = await _context.Visites.FindAsync(id);
            if (visites == null)
            {
                return NotFound();
            }
            ViewData["KioskId"] = new SelectList(_context.Kiosks, "KioskId", "KioskCode", visites.KioskId);
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorId", "Address", visites.OperatorId);
            ViewData["SuperviserId"] = new SelectList(_context.Supervisers, "SuperviserId", "SuperviserName", visites.SuperviserId);
            return View(visites);
        }

        // POST: Visites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VisiteId,KioskId,SuperviserId,OperatorId,VisiteDate,VisitStatuse,Clean,Recommendation,Note,ImagePath")] Visites visites)
        {
            if (id != visites.VisiteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visites);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitesExists(visites.VisiteId))
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
            ViewData["KioskId"] = new SelectList(_context.Kiosks, "KioskId", "KioskCode", visites.KioskId);
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorId", "Address", visites.OperatorId);
            ViewData["SuperviserId"] = new SelectList(_context.Supervisers, "SuperviserId", "SuperviserName", visites.SuperviserId);
            return View(visites);
        }

        // GET: Visites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visites = await _context.Visites
                .Include(v => v.Kiosk)
                .Include(v => v.Operator)
                .Include(v => v.Superviser)
                .FirstOrDefaultAsync(m => m.VisiteId == id);
            if (visites == null)
            {
                return NotFound();
            }

            return View(visites);
        }

        // POST: Visites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visites = await _context.Visites.FindAsync(id);
            _context.Visites.Remove(visites);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitesExists(int id)
        {
            return _context.Visites.Any(e => e.VisiteId == id);
        }
    }
}
