using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    public class ErrorPageController : Controller
    {
        [Route("ErrorPage/Error")]
        public IActionResult Error(int statusCode)
        {
            ViewBag.StatusCode = statusCode;
            return View();
        }
    }
}