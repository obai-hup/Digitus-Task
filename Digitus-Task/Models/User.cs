using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digitus_Task_.Models
{
    public class User : IdentityUser
    {
        public bool IsLoggedIn { get; set; }
        public DateTime LoginTime { get; set; } 
        public string Surname { get; set; }
        public bool IsSend { get; set; }
    }
}
