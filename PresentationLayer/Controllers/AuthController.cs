using BusinessLogicLayer.Interfaces.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Controllers.Abstractions;

namespace PresentationLayer.Controllers
{
    public class AuthController(IAuthService authService) : BaseController
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User loginUserDTO)
        {
            try
            {
                var user = await authService.LoginAsync(loginUserDTO);
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetInt32("UserId", user.Id);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Login", loginUserDTO);
            }
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }


        [HttpPost]
        public async Task<IActionResult> Register(User registerUserDTO)
        {
            await authService.RegisterAsync(registerUserDTO);
            return Ok("Register successfully");
        }
    }
}
