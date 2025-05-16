using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers.Abstractions
{
    public abstract class GetController : BaseController
    {
        public abstract Task<IActionResult> Index();

        public abstract Task<IActionResult> Details(int id);
    }
}
