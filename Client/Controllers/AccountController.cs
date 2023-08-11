using API.DTOs.Account;
using API.DTOs.Employee;
using Client.Contracts;
using Client.Models;
using Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Client.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository repository;

        public AccountController(IAccountRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto login)
        {
            var result = await repository.Login(login);
            if (result is null)
            {
                return RedirectToAction("Error", "Home");
            }
            else if (result.Code == 409)
            {
                ModelState.AddModelError(string.Empty, result.Message);
                return View();
            }
            else if (result.Code == 200)
            {
                HttpContext.Session.SetString("JWToken", result.Data);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

    }
}