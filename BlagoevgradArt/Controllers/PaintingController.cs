using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
    public class PaintingController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
