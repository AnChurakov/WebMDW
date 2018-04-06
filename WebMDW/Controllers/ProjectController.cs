using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMDW.Models;
using WebMDW.Models.Stage;
using WebMDW.Models.Project;
using WebMDW.Models.Status;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WebMDW.Controllers
{
    public class ProjectController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        [Authorize]
        public ActionResult MyProjects()
        {
            var SelectProjectUser = _context.Projects.Include(t => t.User).ToList();

            return View(SelectProjectUser);
        }

        [Authorize]
        public ActionResult AddUserInProject(Guid Id)
        {
            ViewBag.ProjectId = Id;

            return View(_context.Users.ToList());
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> SaveUserInProject(Guid ProjectId, List<ApplicationUser> UsersId)
        {
            var _project = _context.Projects.FirstOrDefault(a => a.Id == ProjectId);

            foreach (var user in UsersId)
            {
                var _selectUser = _context.Users.FirstOrDefault(a => a.Id == user.Id);

                _project.User.Add(_selectUser);
                _context.SaveChanges();
            };

            return RedirectToAction("AddUserInProject", new { id = _project.Id});
        }

        [Authorize]
        public ActionResult AddProject()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetAllProject()
        {
            var Projects = _context.Projects.ToList();

            return View(Projects);
        }


        [Authorize]
        public ActionResult SelectProject(Guid Id)
        {
            var GetProject = _context.Projects.FirstOrDefault(a => a.Id == Id);

            return View(GetProject);
        }

        [Authorize]
        public StageModel GetStage(string NameStage)
        {
            var SelectStage = _context.Stages.FirstOrDefault(a => a.Name == NameStage);

            return SelectStage;
        }

        [Authorize]
        public StatusModel GetStatus(string NameStatus)
        {
            var SelectStatus = _context.Status.FirstOrDefault(a => a.Name == NameStatus);

            return SelectStatus;
        }

        [Authorize]
        public ProjectModel GetProject(Guid Id)
        {
            return _context.Projects.FirstOrDefault(a => a.Id == Id);
        }

        [HttpPost]
        [Authorize]
        public RedirectToRouteResult CreateNewProject(ProjectModel model)
        { 
            var stage = GetStage("Анализ требований");
            var status = GetStatus("В работе");
            var user = _context.Users.FirstOrDefault(a => a.UserName == User.Identity.Name);
            var s = model.Name;
            var f = model.UrlProjectDemo;

            ProjectModel project = new ProjectModel
                {
                    Id = Guid.NewGuid(),
                    Name = s,
                    ProcentComplete = 0,
                    Price = model.Price,
                    DateBegin = DateTime.Now,
                    DateEnd = null,
                    UrlProjectDemo = f,
                    Stages = stage,
                    Status = status,
                    User = new List<ApplicationUser>() { user },
                  
                };

             _context.Projects.Add(project);
             _context.SaveChanges();

            return RedirectToAction("GetAllProject");
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Delete(Guid ProjectId)
        {
            var project = GetProject(ProjectId);

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return RedirectToAction("GetAllProject", "Project");
        }

    }
}