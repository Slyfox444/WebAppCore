using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using WebAppCore.Data;
using WebAppCore.Models;


namespace WebAppCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false) ;

                ApplicationDbContext context = new ApplicationDbContext();

                if (context.Login.Any(m => m.Email == model.Email && m.Password == model.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong details");
                }
            }

            return View(model);
        }
    }
}
