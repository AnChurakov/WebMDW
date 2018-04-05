using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMDW.Controllers;
using WebMDW.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebMDW.Controllers
{
    public class ControlUserController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [Authorize]
        public ActionResult GetAllUsers()
        {
           var AllUsers = _context.Users.ToList();

           return View(AllUsers);
        }

        [Authorize]
        public ActionResult SetRoleUser()
        {
            RoleViewModel roles = new RoleViewModel
            {
                Users = _context.Users.ToList(),
                Role = _context.Roles.ToList()
            };

            return View(roles);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetRole(string UserId, string RoleId)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));

            if (UserId != null && RoleId != null)
            {
                var user = _context.Users.FirstOrDefault(a => a.Id == UserId);
                var role = _context.Roles.FirstOrDefault(a => a.Id == RoleId);

                userManager.AddToRole(user.Id, role.Name);
            }

            return RedirectToAction("SetRoleUser");
        }
    }
}