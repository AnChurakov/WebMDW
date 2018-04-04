using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebMDW.Models;
using WebMDW.Models.Stage;
using WebMDW.Models.Status;
using System.ComponentModel.DataAnnotations;

namespace WebMDW.Models.Project
{
    public class ProjectModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Название проекта")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Дата начала проекта")]
        public DateTime? DateBegin { get; set; }

        [Display(Name = "Дата завершения проекта")]
        public DateTime? DateEnd { get; set; }

        [Display(Name = "Ссылка на проект")]
        public string UrlProjectDemo { get; set; }

        [Display(Name = "Процент завершенности проекта")]
        public int ProcentComplete { get; set; }

        [Display(Name = "Этап проекта")]
        public virtual StageModel Stages { get; set; }

        [Display(Name = "Статус проекта")]
        public virtual StatusModel Status { get; set; }

        public virtual ICollection<ApplicationUser> User { get; set; }

        public virtual ICollection<Task.TaskModel> Tasks { get; set; }

    }
}