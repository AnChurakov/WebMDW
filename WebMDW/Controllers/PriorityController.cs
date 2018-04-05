using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMDW.Models.Priority;
using WebMDW.Models;
using System.Threading.Tasks;

namespace WebMDW.Controllers
{
    public class PriorityController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [Authorize]
        public ActionResult AddPriority()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateNewPriority(PriorityModel model)
        {
            if (model.Name != null)
            {
                PriorityModel priority = new PriorityModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name
                };

                _context.Priorirtys.Add(priority);
                _context.SaveChanges();
            }

            return RedirectToAction("AddPriority");
        }

        [Authorize]
        public PriorityModel GetPriority(Guid Id)
        {
            var SelectPriorityFromDb = _context.Priorirtys.FirstOrDefault(a => a.Id == Id);

            return SelectPriorityFromDb;
        }
    }
}