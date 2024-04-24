using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
    public class AuthorController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllMyPaintings()
        {
            return View();
        }
    }
}
