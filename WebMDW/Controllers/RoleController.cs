using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebMDW.Models;

namespace WebMDW.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Role
        [Authorize]
        public ActionResult AddRole()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetAllRoles()
        {
            return View(_context.Roles.ToList());
        }        

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateNewRole(string NameRole)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            if (NameRole != string.Empty && NameRole != null)
            {
                var role = new IdentityRole {Name = NameRole };

                roleManager.Create(role);
            }

            return RedirectToAction("AddRole");
        }
    }
}