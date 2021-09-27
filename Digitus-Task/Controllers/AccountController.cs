using Digitus_Task_.Data;
using Digitus_Task_.Models;
using Digitus_Task_.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Digitus_Task_.Controllers
{
    public class AccountController : Controller
    {
       
            private readonly UserManager<User> _userManager;
            private readonly SignInManager<User> _signInManager;
            private readonly IEmailService _emailService;
            private readonly AppDbContext _db;
            

            public AccountController(
                UserManager<User> userManager,
                SignInManager<User> signInManager,
                IEmailService emailService, AppDbContext db)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _emailService = emailService;
            _db = db;
           
            }

            public IActionResult Login()
            {
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Login(LoginViewModel login)
            {
                //login functionality
                var user = await _userManager.FindByNameAsync(login.UserName);
               var roles = await _userManager.GetRolesAsync(user);


            if (user != null)
                {
                    //sign in
                    var signInResult = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

                    if (signInResult.Succeeded)
                    {
                    login.IsLoggedIn = true;
                    await _db.SaveChangesAsync();
                        return RedirectToAction("Index", "Home");
                    }
                }

            return Unauthorized(new { LoginError = "Plz Check The Login Cerdential - Invaild UserName Or password " });
        }

            public IActionResult Register()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Register(RegisterViewModel register)
            {
            //register functionality

            var user = new User
            {
                UserName = register.UserName,
                Email = register.Email,
                Surname = register.SurName,
               
            };

                var result = await _userManager.CreateAsync(user, register.Password);

            //await _userManager.AddToRoleAsync(user, "User");

            if (result.Succeeded)
                {
                    //generation of the email token
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var link = Url.Action(nameof(VerifyEmail), "Account", new { userId = user.Id, code }, Request.Scheme, Request.Host.ToString());

                    await _emailService.SendAsync(register.Email, "email verify", $"<a href=\"{link}\">Verify Email</a>", true);

                register.IsSend = true;
                await _db.SaveChangesAsync();

                    return RedirectToAction("EmailVerification");
                }

                return RedirectToAction("Index" , "Home");
            }

            public async Task<IActionResult> VerifyEmail(string userId, string code)
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null) return BadRequest();

                var result = await _userManager.ConfirmEmailAsync(user, code);

                if (result.Succeeded)
                {
                   
                    return View();
                }

                return BadRequest();
            }

            public IActionResult EmailVerification() => View();

            public async Task<IActionResult> LogOut()
            {
                await _signInManager.SignOutAsync();
               
           
                return RedirectToAction("Index", "Home");
            }

        //Add Role Method
      
    }
    }

