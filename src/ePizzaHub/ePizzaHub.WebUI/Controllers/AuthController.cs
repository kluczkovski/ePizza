using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ePizzaHub.Entities;
using ePizzaHub.Services.Interfaces;
using ePizzaHub.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ePizzaHub.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Login()
        {
            return View();

        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                };

                var result = await _authenticationService.CreateUser(user, model.Password);
                if (result)
                {
                    RedirectToAction("Login");
                }
            }

            return View();
        }
    }
}

