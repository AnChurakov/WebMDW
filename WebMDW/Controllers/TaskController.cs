using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMDW.Models;
using WebMDW.Models.Task;
using WebMDW.Models.Priority;
using WebMDW.Models.Status;
using System.Data.Entity;
using System.Threading.Tasks;
using WebMDW.Controllers;

namespace WebMDW.Controllers
{
    public class TaskController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

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
                var status = GetStatus("В работе");

                TaskModel task = new TaskModel
                {
                   Id = Guid.NewGuid(),
                   Name = NameTask,
                   DateBegin = DateTime.Now,
                   Priority = prior,
                   Projects = new List<Models.Project.ProjectModel>() { project},
                   Status = status
                };

                _context.Tasks.Add(task);
                _context.SaveChanges();
            }

            return RedirectToAction("SelectProject", "Project", new { id = ProjectId});
        }

        [Authorize]
        public StatusModel GetStatus(string Name)
        {
            var _status = _context.Status.FirstOrDefault(a => a.Name == Name);

            return _status;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> UpdateStatus(Guid Id, Guid ProjectId)
        {
            var _task = GetTask(Id);

            var _status = GetStatus("Завершен");

            _task.Status = _status;

            _task.DateEnd = DateTime.Now;

            _context.SaveChanges();

            return RedirectToAction("SelectProject", "Project", new { id = ProjectId});
        }

        [Authorize]
        public TaskModel GetTask(Guid Id)
        {
            var _task = _context.Tasks.FirstOrDefault(a => a.Id == Id);

            return _task;
        }

        [HttpGet]
        [Authorize]
        public RedirectToRouteResult Delete(Guid Id, Guid ProjectId)
        {
            var _task = _context.Tasks.FirstOrDefault(a => a.Id == Id);

            if (_task != null)
            {
                _context.Tasks.Remove(_task);
                _context.SaveChanges();
            }

            return RedirectToAction("SelectProject", "Project", new { id = ProjectId});
        }
    }
}