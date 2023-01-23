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
    public class OperatorsController : Controller
    {
        private readonly BusStationSystemContext _context;

        public OperatorsController(BusStationSystemContext context)
        {
            _context = context;
        }

        // GET: Operators
        public async Task<IActionResult> Index()
        {
            var busStationSystemContext = _context.Operators.Include(o => o.CreatedByNavigation).Include(o => o.UpdatedByNavigation);
            return View(await busStationSystemContext.ToListAsync());
        }

        // GET: Operators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operators = await _context.Operators
                .Include(o => o.CreatedByNavigation)
                .Include(o => o.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.OperatorId == id);
            if (operators == null)
            {
                return NotFound();
            }

            return View(operators);
        }

        // GET: Operators/Create
        public IActionResult Create()
        {
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserName");
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserName");
            return View();
        }

        // POST: Operators/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperatorId,OperatorName,Address,OperatorStatus,Disablity,CreatedBy,UpdatedBy,CreateDate,UpdateDate")] Operators operators)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operators);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserName", operators.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserName", operators.UpdatedBy);
            return View(operators);
        }

        // GET: Operators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operators = await _context.Operators.FindAsync(id);
            if (operators == null)
            {
                return NotFound();
            }
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserName", operators.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserName", operators.UpdatedBy);
            return View(operators);
        }

        // POST: Operators/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperatorId,OperatorName,Address,OperatorStatus,Disablity,CreatedBy,UpdatedBy,CreateDate,UpdateDate")] Operators operators)
        {
            if (id != operators.OperatorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operators);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperatorsExists(operators.OperatorId))
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
            ViewData["CreatedBy"] = new SelectList(_context.Users, "UserId", "UserName", operators.CreatedBy);
            ViewData["UpdatedBy"] = new SelectList(_context.Users, "UserId", "UserName", operators.UpdatedBy);
            return View(operators);
        }

        // GET: Operators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operators = await _context.Operators
                .Include(o => o.CreatedByNavigation)
                .Include(o => o.UpdatedByNavigation)
                .FirstOrDefaultAsync(m => m.OperatorId == id);
            if (operators == null)
            {
                return NotFound();
            }

            return View(operators);
        }

        // POST: Operators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operators = await _context.Operators.FindAsync(id);
            _context.Operators.Remove(operators);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperatorsExists(int id)
        {
            return _context.Operators.Any(e => e.OperatorId == id);
        }
    }
}
