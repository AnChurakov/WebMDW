using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMDW.Models;

namespace WebMDW.Models
{
    public class RoleViewModel
    {
        public virtual IEnumerable<ApplicationUser> Users { get; set; }
        public virtual IEnumerable<IdentityRole> Role { get; set; }
    }
}