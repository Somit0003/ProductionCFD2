using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductionCFD2.Data;
using ProductionCFD2.Models;

namespace ProductionCFD2.Controllers
{
    public class ShiftInchargesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShiftInchargesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ShiftIncharges
        public async Task<IActionResult> Index()
        {
            return View(await _context.ShiftIncharges.ToListAsync());
        }

        // GET: ShiftIncharges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftIncharge = await _context.ShiftIncharges
                .FirstOrDefaultAsync(m => m.ShiftIncharge_Id == id);
            if (shiftIncharge == null)
            {
                return NotFound();
            }

            return View(shiftIncharge);
        }

        // GET: ShiftIncharges/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ShiftIncharges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShiftIncharge_Id,ShiftIncharge_Name")] ShiftIncharge shiftIncharge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shiftIncharge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shiftIncharge);
        }

        // GET: ShiftIncharges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftIncharge = await _context.ShiftIncharges.FindAsync(id);
            if (shiftIncharge == null)
            {
                return NotFound();
            }
            return View(shiftIncharge);
        }

        // POST: ShiftIncharges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShiftIncharge_Id,ShiftIncharge_Name")] ShiftIncharge shiftIncharge)
        {
            if (id != shiftIncharge.ShiftIncharge_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shiftIncharge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShiftInchargeExists(shiftIncharge.ShiftIncharge_Id))
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
            return View(shiftIncharge);
        }

        // GET: ShiftIncharges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shiftIncharge = await _context.ShiftIncharges
                .FirstOrDefaultAsync(m => m.ShiftIncharge_Id == id);
            if (shiftIncharge == null)
            {
                return NotFound();
            }

            return View(shiftIncharge);
        }

        // POST: ShiftIncharges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shiftIncharge = await _context.ShiftIncharges.FindAsync(id);
            if (shiftIncharge != null)
            {
                _context.ShiftIncharges.Remove(shiftIncharge);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShiftInchargeExists(int id)
        {
            return _context.ShiftIncharges.Any(e => e.ShiftIncharge_Id == id);
        }
    }
}
