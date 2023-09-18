using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Dtos.Comments;
using SpeakHub.Service.Dtos.Tweets;
using SpeakHub.Service.Interfaces.Comments;

namespace SpeakHub.Web.Controllers.Comments
{
    [Route("comments")]
    //[Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(int tweetId, CommentDto commentDto)
        {
            try
            {
                bool result = await _commentService.CreateCommentAsync(tweetId, commentDto);
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

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync(int id)
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
