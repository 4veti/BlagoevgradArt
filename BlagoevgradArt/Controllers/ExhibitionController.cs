using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
    public class ExhibitionController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
