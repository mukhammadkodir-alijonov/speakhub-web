using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Dtos.Admins;
using SpeakHub.Service.Interfaces.Accounts;

namespace SpeakHub.Web.Areas.Administrator.Controllers;
[Route("adminAccounts")]
public class AccountsController : BaseController
{
    private readonly IAccountService _service;

    public AccountsController(IAccountService accountService)
    {
        _service = accountService;
    }

    [HttpGet("register")]
    public ViewResult Register() => View("Register");

    [HttpPost("register")]
    public async Task<IActionResult> AdminRegisterAsync([FromForm] AdminRegisterDto adminRegisterDto)
    {
        if (ModelState.IsValid)
        {
            bool result = await _service.AdminRegisterAsync(adminRegisterDto);
            if (result)
            {
                return RedirectToAction("login", "adminAccounts", new { area = "administrator" });
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
