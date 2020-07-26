using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        IuserService _userService;
        public AccountController(IuserService userService)
        {
            _userService = userService;
        }
          [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);
            CheckUser checkUser = _userService.CheckUser(register.UserName, register.Email);
            if(checkUser != CheckUser.Ok)
            {
                ViewBag.Check = checkUser;
                return View(register);
            }
            Domain.Models.User user = new Domain.Models.User()
            {
                Email = register.Email.Trim().ToLower(),
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                UserName = register.UserName
            };
            _userService.RegisterUser(user);
            return View("SuccessRegister",register);
        }
    }
}