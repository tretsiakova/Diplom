using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMobileRecord.Data;

namespace WebAppMobileRecord.Controllers
{
    public class OSTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OSTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OSTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.OSTypes.ToListAsync());
        }

        // GET: OSTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSType = await _context.OSTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oSType == null)
            {
                return NotFound();
            }

            return View(oSType);
        }

        // GET: OSTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OSTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OSTypeName")] OSType oSType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oSType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oSType);
        }

        // GET: OSTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSType = await _context.OSTypes.FindAsync(id);
            if (oSType == null)
            {
                return NotFound();
            }
            return View(oSType);
        }

        // POST: OSTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OSTypeName")] OSType oSType)
        {
            if (id != oSType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oSType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OSTypeExists(oSType.Id))
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
            return View(oSType);
        }

        // GET: OSTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSType = await _context.OSTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oSType == null)
            {
                return NotFound();
            }

            return View(oSType);
        }

        // POST: OSTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oSType = await _context.OSTypes.FindAsync(id);
            _context.OSTypes.Remove(oSType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OSTypeExists(int id)
        {
            return _context.OSTypes.Any(e => e.Id == id);
        }
    }
}
