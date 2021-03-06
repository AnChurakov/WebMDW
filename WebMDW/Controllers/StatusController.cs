﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMDW.Models.Status;
using WebMDW.Models;
using System.Threading.Tasks;

namespace WebMDW.Controllers
{
    public class StatusController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Status
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateNewStatus(StatusModel model)
        {

            if (ModelState.IsValid)
            {
                StatusModel status = new StatusModel
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name
                };

                _context.Status.Add(status);

                _context.SaveChanges();
            }

            return View("Index");
        }

        [Authorize]
        public StatusModel GetStatus(string Name)
        {
            var _status = _context.Status.FirstOrDefault(a => a.Name == Name);

            return _status;
        }

        [Authorize]
        public ActionResult Update(Guid Id)
        {
            ViewBag.ProjectId = Id;

            return View(_context.Status.ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UpdateStatusProject(Guid Id, Guid ProjectId)
        {
            var _project = _context.Projects.FirstOrDefault(a => a.Id == ProjectId);

            var _status = _context.Status.FirstOrDefault(t => t.Id == Id);

            _project.Status = _status;

            _context.SaveChanges();

            return RedirectToAction("SelectProject", "Project", new { id = ProjectId});
        }
    }
}