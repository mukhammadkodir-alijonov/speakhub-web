using Microsoft.AspNetCore.Mvc;
using SpeakHub.Service.Interfaces.Comments;

namespace SpeakHub.Web.Areas.Administrator.Controllers
{
    [Route("adminComments")]
    public class CommentController : BaseController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            this._commentService = commentService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
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
