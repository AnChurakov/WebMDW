using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebMDW.Models;
using WebMDW.Models.Stage;

namespace WebMDW.Controllers
{
    public class StageController : Controller
    {
        // GET: Stage
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewStage(StageModel model)
        {
            ApplicationDbContext _context = new ApplicationDbContext();

            if (ModelState.IsValid)
            {
                StageModel st = new StageModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name
                };

                _context.Stages.Add(st);
                _context.SaveChanges();
            }

            return View("Index");
        }
    }
}