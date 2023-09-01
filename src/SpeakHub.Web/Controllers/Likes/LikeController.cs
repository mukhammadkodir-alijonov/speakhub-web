using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Interfaces.Likes;

namespace SpeakHub.Web.Controllers
{
    [Route("likes")]
    public class LikeController : Controller
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost("like")]
        public async Task<IActionResult> LikeAsync(int userId, int tweetId)
        {
            try
            {
                bool result = await _likeService.LikeAsync(userId, tweetId);
                if (result)
                {
                    return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to like the tweet.";
                    return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while liking the tweet: {ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
            }
        }

        [HttpPost("unlike")]
        public async Task<IActionResult> UnlikeAsync(int userId, int tweetId)
        {
            try
            {
                bool result = await _likeService.UnlikeAsync(userId, tweetId);
                if (result)
                {
                    return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to unlike the tweet.";
                    return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while unliking the tweet: {ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
            }
        }
    }
}
