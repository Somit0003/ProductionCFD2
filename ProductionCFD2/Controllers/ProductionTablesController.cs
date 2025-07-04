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
    public class ProductionTablesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductionTablesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductionTables
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductionTables.Include(p => p.Material).Include(p => p.Shift).Include(p => p.ShiftIncharge);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductionTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionTable = await _context.ProductionTables
                .Include(p => p.Material)
                .Include(p => p.Shift)
                .Include(p => p.ShiftIncharge)
                .FirstOrDefaultAsync(m => m.Production_Id == id);
            if (productionTable == null)
            {
                return NotFound();
            }

            return View(productionTable);
        }

        // GET: ProductionTables/Create
        public IActionResult Create()
        {
            ViewData["Material_Id"] = new SelectList(_context.Materials, "Material_Id", "Material_Number");
            ViewData["Shift_Id"] = new SelectList(_context.Shifts, "Shift_Id", "Shift_Name");
            ViewData["ShiftIncharge_Id"] = new SelectList(_context.ShiftIncharges, "ShiftIncharge_Id", "ShiftIncharge_Name");
            return View();
        }

        // POST: ProductionTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Production_Id,Production_Date,Shift_Id,Material_Id,Material_Number,Input_Batch,Total_Weight,Total_Input,Rolling_Plan_Size,Grinding_Loss,Grinding_Wheel,EndCut,Sample_Loss,Finish_Weight,Yield,ShiftIncharge_Id")] ProductionTable productionTable)
        {
            if (ModelState.IsValid)
            {
                productionTable.Finish_Weight = productionTable.Total_Weight - productionTable.Grinding_Loss - productionTable.EndCut - productionTable.Sample_Loss;
                productionTable.Yield = productionTable.Finish_Weight / productionTable.Total_Weight * 100;
                _context.Add(productionTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Material_Id"] = new SelectList(_context.Materials, "Material_Id", "Material_Number", productionTable.Material_Id);
            ViewData["Shift_Id"] = new SelectList(_context.Shifts, "Shift_Id", "Shift_Id", productionTable.Shift_Id);
            ViewData["ShiftIncharge_Id"] = new SelectList(_context.ShiftIncharges, "ShiftIncharge_Id", "ShiftIncharge_", productionTable.ShiftIncharge_Id);
            return View(productionTable);
        }

        // GET: ProductionTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionTable = await _context.ProductionTables.FindAsync(id);
            if (productionTable == null)
            {
                return NotFound();
            }
            ViewData["Material_Id"] = new SelectList(_context.Materials, "Material_Id", "Material_Number", productionTable.Material_Id);
            ViewData["Shift_Id"] = new SelectList(_context.Shifts, "Shift_Id", "Shift_Name", productionTable.Shift_Id);
            ViewData["ShiftIncharge_Id"] = new SelectList(_context.ShiftIncharges, "ShiftIncharge_Id", "ShiftIncharge_Name", productionTable.ShiftIncharge_Id);
            return View(productionTable);
        }

        // POST: ProductionTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Production_Id,Production_Date,Shift_Id,Material_Id,Material_Number,Input_Batch,Total_Weight,Total_Input,Rolling_Plan_Size,Grinding_Loss,Grinding_Wheel,EndCut,Sample_Loss,Finish_Weight,Yield,ShiftIncharge_Id")] ProductionTable productionTable)
        {
            if (id != productionTable.Production_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    productionTable.Finish_Weight = productionTable.Total_Weight - productionTable.Grinding_Loss - productionTable.EndCut - productionTable.Sample_Loss;
                    decimal n = (productionTable.Finish_Weight * 100)/ productionTable.Total_Weight;
                    productionTable.Yield = productionTable.Finish_Weight / productionTable.Total_Weight * 100;
                    _context.Update(productionTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductionTableExists(productionTable.Production_Id))
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
            ViewData["Material_Id"] = new SelectList(_context.Materials, "Material_Id", "Material_Number", productionTable.Material_Id);
            ViewData["Shift_Id"] = new SelectList(_context.Shifts, "Shift_Id", "Shift_Id", productionTable.Shift_Id);
            ViewData["ShiftIncharge_Id"] = new SelectList(_context.ShiftIncharges, "ShiftIncharge_Id", "ShiftIncharge_Id", productionTable.ShiftIncharge_Id);
            return View(productionTable);
        }

        // GET: ProductionTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productionTable = await _context.ProductionTables
                .Include(p => p.Material)
                .Include(p => p.Shift)
                .Include(p => p.ShiftIncharge)
                .FirstOrDefaultAsync(m => m.Production_Id == id);
            if (productionTable == null)
            {
                return NotFound();
            }

            return View(productionTable);
        }

        // POST: ProductionTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productionTable = await _context.ProductionTables.FindAsync(id);
            if (productionTable != null)
            {
                _context.ProductionTables.Remove(productionTable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductionTableExists(int id)
        {
            return _context.ProductionTables.Any(e => e.Production_Id == id);
        }
    }
}
