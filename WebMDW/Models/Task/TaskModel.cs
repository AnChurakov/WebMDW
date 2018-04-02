using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebMDW.Models;

namespace WebMDW.Models.Task
{
    public class TaskModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Название задачи")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Дата создания задачи")]
        public DateTime DateBegin { get; set; }

        [Display(Name = "Дата завершения задачи")]
        public DateTime DateEnd { get; set; }

        public Priority.PriorityModel Priority { get; set; }
    }
}