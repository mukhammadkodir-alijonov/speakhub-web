﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Common.Exceptions;
using SpeakHub.Service.Common.Helpers;
using SpeakHub.Service.Dtos.Accounts;
using SpeakHub.Service.Dtos.Admins;
using SpeakHub.Service.Interfaces.Accounts;

namespace SpeakHub.Web.Controllers.Accounts;
[Route("accounts")]
public class AccountsController : Controller
{
    private readonly IAccountService _service;

    public AccountsController(IAccountService accountService)
    {
        _service = accountService;
    }

    [HttpGet("register")]
    [Authorize(Roles = "admin")]
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
                return RedirectToAction("Index", "Home", new { area = "" });
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
