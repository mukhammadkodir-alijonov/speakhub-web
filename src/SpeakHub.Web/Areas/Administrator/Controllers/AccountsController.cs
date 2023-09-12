using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Common.Exceptions;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Dtos.Accounts;
using SpeakHub.Service.Dtos.Admins;
using SpeakHub.Service.Interfaces.Accounts;

namespace SpeakHub.Web.Areas.Administrator.Controllers;
[Route("admin/accounts")]
public class AccountsController : Controller
{
    private readonly IAccountService _service;

    public AccountsController(IAccountService accountService)
    {
        _service = accountService;
    }

    [HttpGet("register")]
    public ViewResult Register() => View("Register");

    [HttpPost("register")]
    public async Task<IActionResult> AdminRegisterAsync(AdminRegisterDto adminRegisterDto)
    {
        if (ModelState.IsValid)
        {
            bool result = await _service.AdminRegisterAsync(adminRegisterDto);
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
