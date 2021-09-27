using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Digitus_Task_.ViewModels
{
    public class RegisterViewModel
    {
     

        [Required, StringLength(100)]
        public string SurName { get; set; }

        [Required, StringLength(50)]
        public string UserName { get; set; }

        [Required, StringLength(120)]
        public string Email { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        public bool IsSend { get; set; }
    }
}
