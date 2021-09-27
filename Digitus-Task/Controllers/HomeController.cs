using Digitus_Task_.Data;
using Digitus_Task_.Models;
using Digitus_Task_.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Digitus_Task_.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;
        //private readonly User _user;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
            //_user = user;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult OnlineUser()
        {

            return View();
        }
        [HttpPost]
        public IActionResult OnlineUser(OnlineUserViewModel online)
        {
            var onlineUsers = _db.Users.Where(x => x.IsLoggedIn == true).ToList();
            return View(onlineUsers);
        }
      
        [HttpPost]
        [Authorize(Policy = "RequireAdminRole")]
        public IActionResult UserWaitForVierfy()
        {
           var users = _db.Users.Where(x => x.IsSend == true).Where(y => y.EmailConfirmed == false);
            return View(users.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
