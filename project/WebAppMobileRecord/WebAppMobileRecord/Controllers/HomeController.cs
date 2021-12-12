using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WebAppMobileRecord.Data;
using WebAppMobileRecord.Models;

namespace WebAppMobileRecord.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;
        RoleManager<IdentityRole> _roleManager;

        public HomeController(ILogger<HomeController> logger, RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult Description()
        {
            return View();
        }


        public async Task<IActionResult> CreateData()
        {
            await Initialize();

            return Ok();
        }

        public async Task Initialize()
        {

            string[] roles = new string[] { "Администратор", "Пользователь" };

            foreach (string role in roles)
            {

                if (!_context.Roles.Any(r => r.Name == role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }


            var user = new AppUser
            {
                Email = "admin@admin.com",
                UserName = "admin@admin.com",
                FullName = "Администратор",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<AppUser>();
                var hashed = password.HashPassword(user, "1Admin!");
                user.PasswordHash = hashed;

                var result = await _userManager.CreateAsync(user);

                await _userManager.AddToRolesAsync(user, roles);

            }
            

            await _context.SaveChangesAsync();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
