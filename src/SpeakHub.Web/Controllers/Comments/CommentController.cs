using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Interfaces.Comments;
using SpeakHub.Service.Dtos.Tweets;
using Microsoft.AspNetCore.Authorization;

namespace SpeakHub.Web.Controllers.Comments
{
    [Route("comments")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create(int tweetId, TweetDto tweetDto)
        {
            try
            {
                bool result = await _commentService.CreateCommentAsync(tweetId, tweetDto);
                if (result)
                {
                    return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to create comment.";
                    return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
                }
            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while creating the comment.{ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
            }
        }

        [HttpPost("delete")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool result = await _commentService.DeleteCommentAsync(id);
                if (result)
                {
                    return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete comment.";
                    return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
                }
            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"An error occurred while deleting the comment.{ex.Message}";
                // Log the exception
                return RedirectToAction("Index", "Tweet"); // Redirect to tweet details page with error message
            }
        }
    }
}
