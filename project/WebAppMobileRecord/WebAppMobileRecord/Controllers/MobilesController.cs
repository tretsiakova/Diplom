using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMobileRecord.Data;

namespace WebAppMobileRecord.Controllers
{
    [Authorize]
    public class MobilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public MobilesController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Mobiles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mobiles
                .Include(m => m.AssignMobileIdentities)
                .ThenInclude(x => x.Identity).Include(m => m.MobileStatus).Include(m => m.MobileType)
                .Include(m => m.OSVersion).ThenInclude(m => m.OSType).Include(m => m.Vendor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mobiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles
                .Include(m => m.MobileStatus)
                .Include(m => m.MobileType)
                .Include(m => m.OSVersion).ThenInclude(x => x.OSType)
                .Include(m => m.Vendor)
                .Include(m => m.AssignMobileIdentities)
                .ThenInclude(x => x.Identity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // GET: Mobiles/Create
        public IActionResult Create()
        {
            ViewData["MobileStatusId"] = new SelectList(_context.MobileStatuses, "Id", "StatusName");
            ViewData["MobileTypeId"] = new SelectList(_context.MobileTypes, "Id", "TypeName");
            ViewData["OSVersionId"] = new SelectList(_context.OSVersions, "Id", "Version");
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "VendorName");
            return View();
        }

        // POST: Mobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Number,AddedDate,DeactivatedDate,OSVersionId,MobileStatusId,MobileTypeId,VendorId,Comment")]
            Mobile mobile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MobileStatusId"] =
                new SelectList(_context.MobileStatuses, "Id", "StatusName", mobile.MobileStatusId);
            ViewData["MobileTypeId"] = new SelectList(_context.MobileTypes, "Id", "TypeName", mobile.MobileTypeId);
            ViewData["OSVersionId"] = new SelectList(_context.OSVersions, "Id", "Version", mobile.OSVersionId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "VendorName", mobile.VendorId);
            return View(mobile);
        }

        // GET: Mobiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles.Include(m => m.MobileStatus)
                .Include(m => m.MobileType)
                .Include(m => m.OSVersion).ThenInclude(x => x.OSType)
                .Include(m => m.Vendor)
                .Include(m => m.AssignMobileIdentities)
                .ThenInclude(x => x.Identity).FirstOrDefaultAsync(x => x.Id == id);
            if (mobile == null)
            {
                return NotFound();
            }

            ViewData["MobileStatusId"] =
                new SelectList(_context.MobileStatuses, "Id", "StatusName", mobile.MobileStatusId);
            ViewData["MobileTypeId"] = new SelectList(_context.MobileTypes, "Id", "TypeName", mobile.MobileTypeId);
            ViewData["OSVersionId"] = new SelectList(_context.OSVersions, "Id", "Version", mobile.OSVersionId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "VendorName", mobile.VendorId);
            ViewData["Users"] = new SelectList(_context.Users, "Id", "Email", mobile.AssignMobileIdentities?.FirstOrDefault()?.IdentityId);
            return View(mobile);
        }

        // POST: Mobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Number,AddedDate,DeactivatedDate,OSVersionId,MobileStatusId,MobileTypeId,VendorId,Comment")]
            Mobile mobile,
            [Bind("UserId")]
            string userId)
        {
            if (id != mobile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobile);
                    if (string.IsNullOrEmpty(userId))
                    {
                        userId = _userManager.Users.FirstOrDefault(x => x.Email == User.Identity.Name)?.Id;
                    }
                    var mobileStatus = await _context.MobileStatuses.FirstOrDefaultAsync(x=>x.Id == mobile.MobileStatusId);
                    if (mobileStatus.StatusName == "Взят")
                    {
                        var assigments = _context.AssignMobileIdentities.Where(x => x.MobileId == id && x.UnAssignDate == null);
                        foreach (var assigment in assigments)
                        {
                            assigment.UnAssignDate = DateTime.Now;
                        }

                        var newAssigment = new AssignMobileIdentity()
                        {
                            AssignDate = DateTime.Now,
                            IdentityId = userId,
                            MobileId = id,
                        };

                         _context.AssignMobileIdentities.Add(newAssigment);
                    }
                    else
                    {
                        var assigments = _context.AssignMobileIdentities.Where(x => x.MobileId == id && x.UnAssignDate == null);
                        foreach (var assigment in assigments)
                        {
                            assigment.UnAssignDate = DateTime.Now;
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MobileExists(mobile.Id))
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

            ViewData["MobileStatusId"] =
                new SelectList(_context.MobileStatuses, "Id", "StatusName", mobile.MobileStatusId);
            ViewData["MobileTypeId"] = new SelectList(_context.MobileTypes, "Id", "TypeName", mobile.MobileTypeId);
            ViewData["OSVersionId"] = new SelectList(_context.OSVersions, "Id", "Version", mobile.OSVersionId);
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "VendorName", mobile.VendorId);
            return View(mobile);
        }

        // GET: Mobiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mobile = await _context.Mobiles
                .Include(m => m.MobileStatus)
                .Include(m => m.MobileType)
                .Include(m => m.OSVersion).ThenInclude(x => x.OSType)
                .Include(m => m.Vendor)
                .Include(m => m.AssignMobileIdentities)
                .ThenInclude(x => x.Identity)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // POST: Mobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mobile = await _context.Mobiles.FindAsync(id);
            _context.Mobiles.Remove(mobile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MobileExists(int id)
        {
            return _context.Mobiles.Any(e => e.Id == id);
        }
    }
}