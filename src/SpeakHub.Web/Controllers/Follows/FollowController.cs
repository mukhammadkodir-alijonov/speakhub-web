using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Interfaces.Follows;

namespace SpeakHub.Web.Controllers.Follows
{
    //[Route("follows")]
    //[Authorize]
    public class FollowController : Controller
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }
        [HttpGet("get")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("follow")]
        public async Task<IActionResult> FollowAync(int userId1, int userId2)
        {
            bool isFollowed = await _followService.FollowAsync(userId1, userId2);

            if (isFollowed)
            {
                TempData["Message"] = "Followed successfully.";
            }
            else
            {
                TempData["Message"] = "Failed to follow. Check the provided user IDs.";
            }

            return RedirectToAction("Index");
        }

        [HttpPost("unfollow")]
        public async Task<IActionResult> UnfollowAsync(int userId1, int userId2)
        {
            bool isUnfollowed = await _followService.UnFollowAsync(userId1, userId2);

            if (isUnfollowed)
            {
                TempData["Message"] = "Unfollowed successfully.";
            }
            else
            {
                TempData["Message"] = "Failed to unfollow. Check the provided user IDs.";
            }

            return RedirectToAction("Index");
        }
    }
}
