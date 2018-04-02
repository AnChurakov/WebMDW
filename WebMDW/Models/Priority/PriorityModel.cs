using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebMDW.Models;

namespace WebMDW.Models.Priority
{
    public class PriorityModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Название приоритета")]
        public string Name { get; set; }

        public virtual ICollection<Task.TaskModel> Tasks { get; set; }
        
    }
}