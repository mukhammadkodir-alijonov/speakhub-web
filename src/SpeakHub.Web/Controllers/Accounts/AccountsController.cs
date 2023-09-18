using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using SpeakHub.Domain.Entities.Users;
using SpeakHub.Domain.Enums;
using SpeakHub.Service.Common.Exceptions;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Common.Utils;
using SpeakHub.Service.Dtos.Accounts;
using SpeakHub.Service.Dtos.Admins;
using SpeakHub.Service.Interfaces.Accounts;
using SpeakHub.Service.Interfaces.Admins;
using SpeakHub.Service.Interfaces.Users;

namespace SpeakHub.Web.Controllers.Accounts
{
    [Route("accounts")]
    public class AccountsController : Controller
    {
        private readonly IAccountService _service;

        public AccountsController(IAccountService accountService)
        {
            this._service = accountService;
        }
        [HttpGet("register")]
        public ViewResult Register() => View("Register");

        [HttpPost("register")]
        public async Task<IActionResult> UserRegisterAsync(AdminRegisterDto adminRegisterDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _service.RegisterAsync(adminRegisterDto);
                if (result)
                {
                    return RedirectToAction("login", "accounts", new { area = "" });
                }
                else
                {
                    return Register();
                }
            }
            else return Register();
        }
        [HttpGet("login")]
        public ViewResult Login() => View("Login");

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(AccountLoginDto accountLoginDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string token = await _service.LoginAsync(accountLoginDto);
                    HttpContext.Response.Cookies.Append("X-Access-Token", token, new CookieOptions()
                    {
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict
                    });
                    var role = await _service.RoleCheckerAsync(accountLoginDto.Email);
                    if (role == "User")
                    {
                            return RedirectToAction("Index", "Home", new { area = "" });
                    }
                    if(role == "Admin")
                    {
                        return RedirectToAction("Index", "Home", new { area = "administrator" });
                    }
                    else
                    {
                        // Foydalanuvchi aniqlanmadi, xatolikni ko'rsatish
                        ModelState.AddModelError("Email", "Foydalanuvchi topilmadi");
                        return Login();
                    }
                }
                catch (ModelErrorException modelError)
                {
                    ModelState.AddModelError(modelError.Property, modelError.Message);
                    return Login();
                }
                catch
                {
                    return Login();
                }
            }
            else return Login();
        }

        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Response.Cookies.Append("X-Access-Token", "", new CookieOptions()
            {
                Expires = TimeHelper.GetCurrentServerTime().AddDays(-1)
            });
            return RedirectToAction("login", "accounts", new { area = "" });
        }
    }
}


