using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_4_asp.Models
{
    public class User : IdentityUser
    {
        public DateTime LastLoginDate { get; set; }

        public DateTime RegistrationDate { get; set; }

        public Boolean IsBlocked { get; set; }
    }
}
