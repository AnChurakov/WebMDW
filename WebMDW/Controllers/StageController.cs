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
        ApplicationDbContext _context = new ApplicationDbContext();

       // GET: Stage
       [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewStage(StageModel model)
        {
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

        [Authorize]
        public ActionResult Update(Guid Id)
        {
            ViewBag.ProjectId = Id;

            return View(_context.Stages.ToList());
        }

        [HttpPost]
        [Authorize]
        public RedirectToRouteResult UpdateStageProject(Guid Id, Guid ProjectId)
        {
            var _stage = _context.Stages.FirstOrDefault(a => a.Id == Id);

            var _project = _context.Projects.FirstOrDefault(t => t.Id == ProjectId);

            _project.Stages = _stage;

            _context.SaveChanges();

            return RedirectToAction("SelectProject", "Project", new { id = ProjectId});
        }
    }
}