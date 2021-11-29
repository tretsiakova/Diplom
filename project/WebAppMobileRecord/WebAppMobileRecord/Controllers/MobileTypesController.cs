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
    public class MobileTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MobileTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MobileTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.MobileTypes.ToListAsync());
        }

        // GET: MobileTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileType = await _context.MobileTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobileType == null)
            {
                return NotFound();
            }

            return View(mobileType);
        }

        // GET: MobileTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MobileTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName")] MobileType mobileType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobileType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobileType);
        }

        // GET: MobileTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileType = await _context.MobileTypes.FindAsync(id);
            if (mobileType == null)
            {
                return NotFound();
            }
            return View(mobileType);
        }

        // POST: MobileTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeName")] MobileType mobileType)
        {
            if (id != mobileType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobileType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileTypeExists(mobileType.Id))
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
            return View(mobileType);
        }

        // GET: MobileTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobileType = await _context.MobileTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobileType == null)
            {
                return NotFound();
            }

            return View(mobileType);
        }

        // POST: MobileTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobileType = await _context.MobileTypes.FindAsync(id);
            _context.MobileTypes.Remove(mobileType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobileTypeExists(int id)
        {
            return _context.MobileTypes.Any(e => e.Id == id);
        }
    }
}
