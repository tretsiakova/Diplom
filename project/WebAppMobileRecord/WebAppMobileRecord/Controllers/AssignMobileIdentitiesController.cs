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
    public class AssignMobileIdentitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssignMobileIdentitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AssignMobileIdentities
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.AssignMobileIdentities.Include(a => a.Identity).Include(a => a.Mobile);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AssignMobileIdentities/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignMobileIdentity = await _context.AssignMobileIdentities
                .Include(a => a.Identity)
                .Include(a => a.Mobile)
                .FirstOrDefaultAsync(m => m.IdentityId == id);
            if (assignMobileIdentity == null)
            {
                return NotFound();
            }

            return View(assignMobileIdentity);
        }

        // GET: AssignMobileIdentities/Create
        public IActionResult Create()
        {
            ViewData["IdentityId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "Id", "Id");
            return View();
        }

        // POST: AssignMobileIdentities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssignDate,UnAssignDate,IdentityId,MobileId")] AssignMobileIdentity assignMobileIdentity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignMobileIdentity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityId"] = new SelectList(_context.Users, "Id", "Id", assignMobileIdentity.IdentityId);
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "Id", "Id", assignMobileIdentity.MobileId);
            return View(assignMobileIdentity);
        }

        // GET: AssignMobileIdentities/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignMobileIdentity = await _context.AssignMobileIdentities.FindAsync(id);
            if (assignMobileIdentity == null)
            {
                return NotFound();
            }
            ViewData["IdentityId"] = new SelectList(_context.Users, "Id", "Id", assignMobileIdentity.IdentityId);
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "Id", "Id", assignMobileIdentity.MobileId);
            return View(assignMobileIdentity);
        }

        // POST: AssignMobileIdentities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssignDate,UnAssignDate,IdentityId,MobileId")] AssignMobileIdentity assignMobileIdentity)
        {
            if (id != assignMobileIdentity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignMobileIdentity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignMobileIdentityExists(assignMobileIdentity.Id))
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
            ViewData["IdentityId"] = new SelectList(_context.Users, "Id", "Id", assignMobileIdentity.IdentityId);
            ViewData["MobileId"] = new SelectList(_context.Mobiles, "Id", "Id", assignMobileIdentity.MobileId);
            return View(assignMobileIdentity);
        }

        // GET: AssignMobileIdentities/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignMobileIdentity = await _context.AssignMobileIdentities
                .Include(a => a.Identity)
                .Include(a => a.Mobile)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignMobileIdentity == null)
            {
                return NotFound();
            }

            return View(assignMobileIdentity);
        }

        // POST: AssignMobileIdentities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignMobileIdentity = await _context.AssignMobileIdentities.FindAsync(id);
            _context.AssignMobileIdentities.Remove(assignMobileIdentity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignMobileIdentityExists(int id)
        {
            return _context.AssignMobileIdentities.Any(e => e.Id == id);
        }
    }
}
