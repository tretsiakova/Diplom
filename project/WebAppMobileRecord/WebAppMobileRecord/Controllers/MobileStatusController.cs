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
    public class MobileStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MobileStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MobileStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.MobileStatuses.ToListAsync());
        }

        // GET: MobileStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileStatus = await _context.MobileStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobileStatus == null)
            {
                return NotFound();
            }

            return View(mobileStatus);
        }

        // GET: MobileStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MobileStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StatusName")] MobileStatus mobileStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobileStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobileStatus);
        }

        // GET: MobileStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileStatus = await _context.MobileStatuses.FindAsync(id);
            if (mobileStatus == null)
            {
                return NotFound();
            }
            return View(mobileStatus);
        }

        // POST: MobileStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StatusName")] MobileStatus mobileStatus)
        {
            if (id != mobileStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobileStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileStatusExists(mobileStatus.Id))
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
            return View(mobileStatus);
        }

        // GET: MobileStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileStatus = await _context.MobileStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobileStatus == null)
            {
                return NotFound();
            }

            return View(mobileStatus);
        }

        // POST: MobileStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobileStatus = await _context.MobileStatuses.FindAsync(id);
            _context.MobileStatuses.Remove(mobileStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobileStatusExists(int id)
        {
            return _context.MobileStatuses.Any(e => e.Id == id);
        }
    }
}
