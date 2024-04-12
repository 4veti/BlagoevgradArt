using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
    public class GalleryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
