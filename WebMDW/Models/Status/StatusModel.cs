using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebMDW.Models.Status
{
    public class StatusModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Название статуса")]
        public string Name { get; set; }

        public ICollection<Project.ProjectModel> Projects { get; set; }
    }
}