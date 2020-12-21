using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_4_asp.ViewModels
{
    public class UserViewModel
    {
        public String Id { get; set; }

        public String UserName { get; set; }

        public String Email { get; set; }

        public DateTime LastLoginDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Boolean IsBlocked { get; set; }  

        public SelectListItem Users { get; set; }
    }
}
