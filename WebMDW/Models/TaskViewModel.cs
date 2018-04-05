using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMDW.Models.Priority;
using WebMDW.Models.Task;

namespace WebMDW.Models
{
    public class TaskViewModel
    {
        public TaskModel Tasks { get; set; }
        public virtual IEnumerable<PriorityModel> Prioritys { get; set; }
    }
}