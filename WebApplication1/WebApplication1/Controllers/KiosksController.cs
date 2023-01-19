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
    public class KiosksController : Controller
    {
        private readonly BusStationSystemContext _context;

        public KiosksController(BusStationSystemContext context)
        {
            _context = context;
        }

        // GET: Kiosks
        public async Task<IActionResult> Index()
        {
            var busStationSystemContext = _context.Kiosks.Include(k => k.CreatedByNavigation).Include(k => k.KioskStatus).Include(k => k.KioskType).Include(k => k.Operator).Include(k => k.Supervioser).Include(k => k.UpdatedByNavigation);
            return View(await busStationSystemContext.ToListAsync());
        }

        // GET: Kiosks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiosks = await _context.Kiosks
                .Include(k => k.CreatedByNavigation)
                .Include(k => k.KioskStatus)
                .Include(k => k.KioskType)
                .Include(k => k.Operator)
                .Include(k => k.Supervioser)
                .Include(k => k.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.KioskId == id);
            if (kiosks == null)
            {
                return NotFound();
            }

            return View(kiosks);
        }

        // GET: Kiosks/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Name");
            ViewData["KioskStatusId"] = new SelectList(_context.KisokStatus, "StatusId", "StatusCode");
            ViewData["KioskTypeId"] = new SelectList(_context.KioskTypes, "KioskTypeId", "KioskTypeName");
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorId", "Address");
            ViewData["SupervioserId"] = new SelectList(_context.Supervisers, "SuperviserId", "SuperviserName");
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Name");
            return View();
        }

        // POST: Kiosks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KioskId,KioskCode,StreetId,OperatorId,SupervioserId,KioskTypeId,KioskStatusId,CoolerStatus,LockDoor,LockWindow,Electricity,CreatedBy,UpdatedBy,CreateDate,UpdateDate")] Kiosks kiosks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kiosks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Name", kiosks.CreatedBy);
            ViewData["KioskStatusId"] = new SelectList(_context.KisokStatus, "StatusId", "StatusCode", kiosks.KioskStatusId);
            ViewData["KioskTypeId"] = new SelectList(_context.KioskTypes, "KioskTypeId", "KioskTypeName", kiosks.KioskTypeId);
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorId", "Address", kiosks.OperatorId);
            ViewData["SupervioserId"] = new SelectList(_context.Supervisers, "SuperviserId", "SuperviserName", kiosks.SuperviserId);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Name", kiosks.UpdatedBy);
            return View(kiosks);
        }

        // GET: Kiosks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiosks = await _context.Kiosks.FindAsync(id);
            if (kiosks == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Name", kiosks.CreatedBy);
            ViewData["KioskStatusId"] = new SelectList(_context.KisokStatus, "StatusId", "StatusCode", kiosks.KioskStatusId);
            ViewData["KioskTypeId"] = new SelectList(_context.KioskTypes, "KioskTypeId", "KioskTypeName", kiosks.KioskTypeId);
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorId", "Address", kiosks.OperatorId);
            ViewData["SupervioserId"] = new SelectList(_context.Supervisers, "SuperviserId", "SuperviserName", kiosks.SuperviserId);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Name", kiosks.UpdatedBy);
            return View(kiosks);
        }

        // POST: Kiosks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KioskId,KioskCode,StreetId,OperatorId,SupervioserId,KioskTypeId,KioskStatusId,CoolerStatus,LockDoor,LockWindow,Electricity,CreatedBy,UpdatedBy,CreateDate,UpdateDate")] Kiosks kiosks)
        {
            if (id != kiosks.KioskId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kiosks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KiosksExists(kiosks.KioskId))
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
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "Name", kiosks.CreatedBy);
            ViewData["KioskStatusId"] = new SelectList(_context.KisokStatus, "StatusId", "StatusCode", kiosks.KioskStatusId);
            ViewData["KioskTypeId"] = new SelectList(_context.KioskTypes, "KioskTypeId", "KioskTypeName", kiosks.KioskTypeId);
            ViewData["OperatorId"] = new SelectList(_context.Operators, "OperatorId", "Address", kiosks.OperatorId);
            ViewData["SupervioserId"] = new SelectList(_context.Supervisers, "SuperviserId", "SuperviserName", kiosks.SuperviserId);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "Name", kiosks.UpdatedBy);
            return View(kiosks);
        }

        // GET: Kiosks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kiosks = await _context.Kiosks
                .Include(k => k.CreatedByNavigation)
                .Include(k => k.KioskStatus)
                .Include(k => k.KioskType)
                .Include(k => k.Operator)
                .Include(k => k.Supervioser)
                .Include(k => k.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.KioskId == id);
            if (kiosks == null)
            {
                return NotFound();
            }

            return View(kiosks);
        }

        // POST: Kiosks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kiosks = await _context.Kiosks.FindAsync(id);
            _context.Kiosks.Remove(kiosks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KiosksExists(int id)
        {
            return _context.Kiosks.Any(e => e.KioskId == id);
        }
    }
}
