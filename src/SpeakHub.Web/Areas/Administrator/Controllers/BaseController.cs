using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SpeakHub.Web.Areas.Administrator.Controllers
{
    [Area("administrator")]
    //[Authorize(Roles = "Admin")]
    public class BaseController : Controller
    {

    }
}
