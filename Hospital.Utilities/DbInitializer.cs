using Hospital.Model;
using Hospital.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Hospital.Utilities
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        public void Initialize()
        {
            try
            {
                // Apply pending migrations
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database migration failed.", ex);
            }

            // Seed roles and admin user
            if (!_roleManager.RoleExistsAsync(WebsiteRoles.WebSite_Admin).GetAwaiter().GetResult())
            {
                // Add roles
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebSite_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebSite_Patient)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new IdentityRole(WebsiteRoles.WebSite_Doctor)).GetAwaiter().GetResult();

                // Add admin user
                var adminUser = new ApplicationUser
                {
                    UserName = "Hamza",
                    Email = "abide@xyz.com"
                };

                _userManager.CreateAsync(adminUser, "Hamza@123").GetAwaiter().GetResult();
                var appUser = _context.Users.FirstOrDefault(u => u.Email == "abide@xyz.com");
                if (appUser != null)
                {
                    _userManager.AddToRoleAsync(appUser, WebsiteRoles.WebSite_Admin).GetAwaiter().GetResult();
                }
            }
        }
    }
}
