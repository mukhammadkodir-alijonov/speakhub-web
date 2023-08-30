using Microsoft.AspNetCore.Mvc;
using SpeakHub.Exceptions;
using SpeakHub.Service.Common.Utils;
using SpeakHub.Service.Dtos.Accounts;
using SpeakHub.Service.Dtos.Admins;
using SpeakHub.Service.Dtos.Users;
using SpeakHub.Service.Interfaces.Accounts;
using SpeakHub.Service.Interfaces.Common;
using SpeakHub.Service.Interfaces.Users;
using SpeakHub.Service.ViewModels.UserViewModels;

namespace YourApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;
        private readonly IIdentityService _identityService;

        public UserController(IUserService userService,IAccountService accountService, IIdentityService identityService)
        {
            this._userService = userService;
            this._accountService = accountService;
            this._identityService = identityService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<ViewResult> Get(int userId)
        {
            var user = await _userService.GetAsync(userId);
            ViewBag.UserId = userId;
            ViewBag.HomeTitle = "My account";
            var userView = new UserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Image = user.Image
            };
            return View("../Users/Index", user);
        }
        [HttpGet]
        public async Task<ViewResult> Update()
        {
            var userId = _identityService.Id!.Value;
            var user = await _userService.GetAsync(userId);
            ViewBag.userId = userId;
            ViewBag.HomeTitle = "User update";
            var userUpdate = new UserUpdateDto()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };
            return View("../Users/Update", userUpdate);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromForm] UserUpdateDto userUpdateDto, int userId)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.UpdateAsync(userId, userUpdateDto);
                if (user) return RedirectToAction("Index", "Home", new { area = "" });
                else return RedirectToAction("Update", "Users", new { area = "" });
            }
            else return RedirectToAction("Update", "Users", new { area = "" });
        }
        // Update when you know the password of views that have not been recorded -->
        [HttpGet]
        public async Task<ViewResult> UpdatePasswordAsync()
        {
            return View("UpdatePassword");
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(PasswordUpdateDto passwordUpdateDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.PasswordUpdateAsync(passwordUpdateDto);
                if (result) return RedirectToAction("Index", "settings");
                else return await UpdatePasswordAsync();
            }
            else return await UpdatePasswordAsync();
        }
        // Send code to email without views
        [HttpGet]
        public async Task<ViewResult> SendEmailAsync()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync(SendToEmailDto sendToEmailDto)
        {
            if (ModelState.IsValid)
            {
                await _accountService.SendCodeAsync(sendToEmailDto);
                return RedirectToAction("ForgetPassword", "Users");
            }
            else return await SendEmailAsync();
        }
        [HttpGet]
        public async Task<ViewResult> ForgetPasswordAsync()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPasswordAsync(UserResetPasswordDto resetPasswordDto)
        {
            if (ModelState.IsValid)
            {
                var res = await _accountService.VerifyPasswordAsync(resetPasswordDto);
                if (res) return RedirectToAction("Index", "settings");

                else return await ForgetPasswordAsync();
            }
            else return await ForgetPasswordAsync();
        }
        [HttpGet()]
        public async Task<ViewResult> UserDeleteAsync()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserDeleteAsync(UserDeleteDto userDeleteDto)
        {
            if (ModelState.IsValid)
            {
                var userId = _identityService.Id!.Value;
                var res = await _accountService.DeleteByPasswordAsync(userDeleteDto);
                if (res)
                {
                    var result = await _userService.DeleteAsync(userId);
                    if (result) return RedirectToAction("Index", "Home", new { area = "" });
                    else return await UserDeleteAsync();
                }
                else return await UserDeleteAsync();
            }
            else return await UserDeleteAsync();
        }
    }
}
