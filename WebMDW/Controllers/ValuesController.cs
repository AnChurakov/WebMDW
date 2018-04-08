using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using WebMDW.Models;
using WebMDW.Models.Project;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace WebMDW.Controllers
{
    public class ValuesController : ApiController
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<ProjectModel> GetProjects()
        {
            var allproject = _context.Projects.ToList();

            List<ProjectModel> list = new List<ProjectModel>();

            foreach (var s in allproject)
            {
                var project = new ProjectModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    UrlProjectDemo = s.UrlProjectDemo,
                    DateBegin = s.DateBegin,
                    DateEnd = s.DateEnd,
                    Price = s.Price,
                    ProcentComplete = s.ProcentComplete,
                    Status = s.Status
                };

                //var json = JsonConvert.SerializeObject(project);
                list.Add(project);
            }

            return list;
        }

        public ProjectModel Get(string id)
        {
            var project = _context.Projects.FirstOrDefault(a => a.Name == id);

            return project;
        }
    }
}
