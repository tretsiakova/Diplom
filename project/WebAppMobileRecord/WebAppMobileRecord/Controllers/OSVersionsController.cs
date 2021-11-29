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
    public class OSVersionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OSVersionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OSVersions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.OSVersions.Include(o => o.OSType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: OSVersions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSVersion = await _context.OSVersions
                .Include(o => o.OSType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oSVersion == null)
            {
                return NotFound();
            }

            return View(oSVersion);
        }

        // GET: OSVersions/Create
        public IActionResult Create()
        {
            ViewData["OSTypeId"] = new SelectList(_context.OSTypes, "Id", "OSTypeName");
            return View();
        }

        // POST: OSVersions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Version,OSTypeId")] OSVersion oSVersion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oSVersion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OSTypeId"] = new SelectList(_context.OSTypes, "Id", "OSTypeName", oSVersion.OSTypeId);
            return View(oSVersion);
        }

        // GET: OSVersions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSVersion = await _context.OSVersions.FindAsync(id);
            if (oSVersion == null)
            {
                return NotFound();
            }
            ViewData["OSTypeId"] = new SelectList(_context.OSTypes, "Id", "OSTypeName", oSVersion.OSTypeId);
            return View(oSVersion);
        }

        // POST: OSVersions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Version,OSTypeId")] OSVersion oSVersion)
        {
            if (id != oSVersion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oSVersion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OSVersionExists(oSVersion.Id))
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
            ViewData["OSTypeId"] = new SelectList(_context.OSTypes, "Id", "OSTypeName", oSVersion.OSTypeId);
            return View(oSVersion);
        }

        // GET: OSVersions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oSVersion = await _context.OSVersions
                .Include(o => o.OSType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oSVersion == null)
            {
                return NotFound();
            }

            return View(oSVersion);
        }

        // POST: OSVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oSVersion = await _context.OSVersions.FindAsync(id);
            _context.OSVersions.Remove(oSVersion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OSVersionExists(int id)
        {
            return _context.OSVersions.Any(e => e.Id == id);
        }
    }
}
