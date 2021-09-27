using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digitus_Task_.ViewModels
{
    public class OnlineUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsLoggedIn { get; set; }
        public string Status { get; set; }
    }
}
