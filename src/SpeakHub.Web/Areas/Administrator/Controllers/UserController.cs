using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Common.Utils;
using SpeakHub.Service.Dtos.Users;
using SpeakHub.Service.Interfaces.Users;

namespace SpeakHub.Web.Areas.Administrator.Controllers;
[Route("adminUsers")]
public class UserController : BaseController
{
    private readonly IUserService _userService;
    private readonly int pageSize = 20;
    public UserController(IUserService userService)
    {
        this._userService = userService;
    }
    [HttpGet("getall")]
    public async Task<ViewResult> Index(int page = 1)
    {
        var users = await _userService.GetAllAysnc(new PaginationParams(page, pageSize));
        return View("Index", users);
    }
    [HttpGet("update")]
    public async Task<IActionResult> UpdateRedirectAsync(int userid)
    {
        var user = await _userService.GetAsync(userid);
        user.Id = userid;
        var upuser = new UserUpdateDto()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
        };
        ViewBag.userid = userid;
        ViewBag.HomeTitle = "user / Get / Update";
        return View("UserUpdate", upuser);
    }
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteAsync(int userid)
    {
        var res = await _userService.DeleteAsync(userid);
        if (res)
        {
            return RedirectToAction("Index", "users", new { area = "Adminstrator" });
        }
        return RedirectToAction("Index", "users", new { area = "Adminstrator" });
    }
    [HttpPatch("update-image")]
    public async Task<IActionResult> UpdateImageAsync(int id, IFormFile file)
    => Ok(await _userService.ImageUpdateAsync(id, file));
    [HttpPatch("delete-image")]
    public async Task<IActionResult> DeleteImageAsync(int id)
    => Ok(await _userService.DeleteImageAsync(id));
}
