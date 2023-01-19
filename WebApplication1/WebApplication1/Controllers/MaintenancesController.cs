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
    public class MaintenancesController : Controller
    {
        private readonly BusStationSystemContext _context;

        public MaintenancesController(BusStationSystemContext context)
        {
            _context = context;
        }

        // GET: Maintenances
        public async Task<IActionResult> Index()
        {
            var busStationSystemContext = _context.Maintenance.Include(m => m.MaintenanceType).Include(m => m.Visite);
            return View(await busStationSystemContext.ToListAsync());
        }

        // GET: Maintenances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance = await _context.Maintenance
                .Include(m => m.MaintenanceType)
                .Include(m => m.Visite)
                .FirstOrDefaultAsync(m => m.MaintenanceProcessId == id);
            if (maintenance == null)
            {
                return NotFound();
            }

            return View(maintenance);
        }

        // GET: Maintenances/Create
        public IActionResult Create()
        {
            ViewData["MaintenanceTypeId"] = new SelectList(_context.MaintenanceType, "MaintenanceTypeId", "MaintenanceName");
            ViewData["VisiteId"] = new SelectList(_context.Visites, "VisiteId", "VisitStatuse");
            return View();
        }

        // POST: Maintenances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaintenanceProcessId,MaintenanceTypeId,KioskCode,VisiteId,SuperviserId,MaintenanceStatus,Details,Note,MaintenanceDate,CreatedBy,UpdateDate")] Maintenance maintenance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maintenance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaintenanceTypeId"] = new SelectList(_context.MaintenanceType, "MaintenanceTypeId", "MaintenanceName", maintenance.MaintenanceTypeId);
            ViewData["VisiteId"] = new SelectList(_context.Visites, "VisiteId", "VisitStatuse", maintenance.VisiteId);
            return View(maintenance);
        }

        // GET: Maintenances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance = await _context.Maintenance.FindAsync(id);
            if (maintenance == null)
            {
                return NotFound();
            }
            ViewData["MaintenanceTypeId"] = new SelectList(_context.MaintenanceType, "MaintenanceTypeId", "MaintenanceName", maintenance.MaintenanceTypeId);
            ViewData["VisiteId"] = new SelectList(_context.Visites, "VisiteId", "VisitStatuse", maintenance.VisiteId);
            return View(maintenance);
        }

        // POST: Maintenances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaintenanceProcessId,MaintenanceTypeId,KioskCode,VisiteId,SuperviserId,MaintenanceStatus,Details,Note,MaintenanceDate,CreatedBy,UpdateDate")] Maintenance maintenance)
        {
            if (id != maintenance.MaintenanceProcessId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maintenance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaintenanceExists(maintenance.MaintenanceProcessId))
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
            ViewData["MaintenanceTypeId"] = new SelectList(_context.MaintenanceType, "MaintenanceTypeId", "MaintenanceName", maintenance.MaintenanceTypeId);
            ViewData["VisiteId"] = new SelectList(_context.Visites, "VisiteId", "VisitStatuse", maintenance.VisiteId);
            return View(maintenance);
        }

        // GET: Maintenances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var maintenance = await _context.Maintenance
                .Include(m => m.MaintenanceType)
                .Include(m => m.Visite)
                .FirstOrDefaultAsync(m => m.MaintenanceProcessId == id);
            if (maintenance == null)
            {
                return NotFound();
            }

            return View(maintenance);
        }

        // POST: Maintenances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maintenance = await _context.Maintenance.FindAsync(id);
            _context.Maintenance.Remove(maintenance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaintenanceExists(int id)
        {
            return _context.Maintenance.Any(e => e.MaintenanceProcessId == id);
        }
    }
}
