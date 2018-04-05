using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMDW.Models;
using WebMDW.Models.Task;
using WebMDW.Models.Priority;
using System.Data.Entity;
using System.Threading.Tasks;
using WebMDW.Controllers;

namespace WebMDW.Controllers
{
    public class TaskController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        PriorityController _prior = new PriorityController();

        [Authorize]
        public ActionResult AddTask(Guid Id)
        {
            ViewBag.ProjectId = Id;

            TaskViewModel task = new TaskViewModel
            {
                Prioritys = _context.Priorirtys.ToList()
            };

            return View(task);
        }

        [Authorize]
        public PriorityModel GetPriority(Guid Id)
        {
            var SelectPriorityFromDb = _context.Priorirtys.FirstOrDefault(a => a.Id == Id);

            return SelectPriorityFromDb;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateNewTask(Guid PriorId, string NameTask, Guid ProjectId)
        {
            if (NameTask != null && PriorId != null && ProjectId != null)
            {
                var project = _context.Projects.FirstOrDefault(a => a.Id == ProjectId);
                var prior = GetPriority(PriorId);

                TaskModel task = new TaskModel
                {
                   Id = Guid.NewGuid(),
                   Name = NameTask,
                   DateBegin = DateTime.Now,
                   Priority = prior,
                   Projects = new List<Models.Project.ProjectModel>() { project}
                };

                _context.Tasks.Add(task);
                _context.SaveChanges();
            }

            return RedirectToRoute("Project/MyProjects");
        }
    }
}