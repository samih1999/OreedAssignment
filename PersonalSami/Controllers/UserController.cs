using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalSami.Entity;
using PersonalSami.Models;
using PersonalSami.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PersonalSami.Controllers
{
    public class UserController : Controller
    {
        private readonly IRegisterService _Register;
        private readonly INotyfService _notyf;

        public UserController(IRegisterService register, INotyfService notyf)
        {
            _Register = register;
            _notyf = notyf;
        }

        public IActionResult Index()
        {
            ViewBag.usernae_secc = HttpContext.Session.GetString("usernae_secc");

            return View();
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel reg)
        {

            if (ModelState.IsValid)
            {
                using var hmac = new HMACSHA512();

                var reu = new UserInfo
                {

                    FirstName = reg.FirstName,
                    LastName = reg.LastName,
                    Email = reg.Email,
                    Address=reg.Address,
                   CurrentJob=reg.CurrentJob,
                   DOB=reg.DOB,
                   CurrentJobDesc=reg.CurrentJobDesc,
                   Phone=reg.Phone,
                   Speialization=reg.Speialization,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(reg.Password)),
                    PasswordSalt = hmac.Key,
                    Role = "User"
                };

                await _Register.CreateAsync(reu);
                _notyf.Success("Registered Successfully");
                return RedirectToAction(nameof(Login));
            }
            return View();

        }




        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel log)
        {
            if (ModelState.IsValid)
            {


                const string id = "id";
                const string usernae_secc = "usernae_secc";



                var check = _Register.logcheck(log.Email,log.Password);

                //var auth = _userContext.User.Where(x => x.UerName == UserName && x.Password == Password).SingleOrDefault();
                if (check != null)
                {

                    HttpContext.Session.SetString(usernae_secc, check.Email.ToString());
                    HttpContext.Session.SetString(id, Convert.ToString(check.Id.ToString()));
                    if (_Register.GetRole(log.Email) == "Admin") return RedirectToAction("Content", "Home");
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    ModelState.AddModelError("message", "Invalid login attempt");
                    return View();
                }
            }
            return View();
        }


        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("usernae_secc") != null)
            {
                HttpContext.Session.Clear();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //public IActionResult Login(LoginViewmodel log)
        //{
        //  if(_loginService.CheckEmail(log.Username) && _loginService.CheckPass(log.Password))
        //   return View();
        //    return View();

    }
}
