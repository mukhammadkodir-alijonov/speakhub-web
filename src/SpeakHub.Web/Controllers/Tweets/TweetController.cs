using DocumentFormat.OpenXml.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Dtos.Tweets;
using SpeakHub.Service.Interfaces.Tweets;

namespace SpeakHub.Web.Controllers
{
    [Route("tweets")]
    [Authorize]
    public class TweetController : Controller
    {
        private readonly ITweetService _tweetService;

        public TweetController(ITweetService tweetService)
        {
            _tweetService = tweetService;
        }
        [HttpGet("getId")]
        public async Task<IActionResult> Index(int userId)
        {
            try
            {
                var tweets = await _tweetService.GetAllByIdAsync(userId);
                return View(tweets);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while fetching tweets: {ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Home"); // Redirect to the home page with an error message
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(int tweetId, TweetDto tweetDto)
        {
            try
            {
                bool result = await _tweetService.CreateTweetAsync(tweetId, tweetDto);
                SetTempMessage(result, "Tweet created successfully.", "Failed to create tweet.");
                return RedirectToAction("Index", new { userId = tweetDto.Id }); // Redirect to the tweet index page for the user
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while creating the tweet: {ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Home"); // Redirect to the home page with an error message
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(int id, EditTweetDto editTweetDto)
        {
            try
            {
                bool result = await _tweetService.UpdateTweetAsync(id, editTweetDto);
                SetTempMessage(result, "Tweet updated successfully.", "Failed to update tweet.");
                return RedirectToAction("Index", new { userId = editTweetDto.Id }); // Redirect to the tweet index page for the user
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while updating the tweet: {ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Home"); // Redirect to the home page with an error message
            }
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                bool result = await _tweetService.DeleteTweetAsync(id);
                SetTempMessage(result, "Tweet deleted successfully.", "Failed to delete tweet.");
                return RedirectToAction("Index", "Home"); // Redirect to the home page
            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the tweet: {ex.Message}";
                // Log the exception
            }
            return RedirectToAction("Index", "Home"); // Redirect to the home page with an error message
        }
        [HttpPost("save")]
        public async Task<IActionResult> SaveAsync(int id, SaveTweetDto saveTweetDto)
        {
            try
            {
                bool result = await _tweetService.SaveTweetAsync(id, saveTweetDto);
                SetTempMessage(result, "Tweet saved successfully.", "Failed to update tweet.");
                return RedirectToAction("Index", new { userId = saveTweetDto.Id }); // Redirect to the tweet index page for the user
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while saving the tweet: {ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Home"); // Redirect to the home page with an error message
            }
        }

        [HttpGet("like")]
        public async Task<IActionResult> LikesAsync(int tweetId)
        {
            try
            {
                var likes = await _tweetService.GetAllLikeByTweetAsync(tweetId);
                return View(likes);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while fetching likes: {ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Home"); // Redirect to the home page with an error message
            }
        }

        private void SetTempMessage(bool success, string successMessage, string errorMessage)
        {
            TempData[success ? "SuccessMessage" : "ErrorMessage"] = success ? successMessage : errorMessage;
        }
    }
}
