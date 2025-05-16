using BusinessLogicLayer.Commons;
using BusinessLogicLayer.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using System.Diagnostics;
using System.Text;

namespace PresentationLayer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppConfiguration _config;

        public HomeController(ILogger<HomeController> logger, AppConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile != null)
            {
                var fileName = await ImageUtil.SaveImageAsync(_config, typeof(HomeController), imageFile);
                if (fileName != null)
                {
                    var imageBytes = await ImageUtil.GetImageAsync(_config, typeof(HomeController), fileName);
                    if (imageBytes != null)
                    {
                        ViewBag.ImageData = Convert.ToBase64String(imageBytes);
                        ViewBag.Message = $"Image uploaded and retrieved: {fileName}";
                    }
                }
                else
                {
                    ViewBag.Message = "Image upload failed.";
                }
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteImage(string fileName)
        {
            var result = await ImageUtil.DeleteImageAsync(_config, typeof(HomeController), fileName);
            ViewBag.Message = result ? $"Image {fileName} deleted successfully." : $"Failed to delete {fileName}.";
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
