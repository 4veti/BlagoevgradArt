using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Controllers
{
    [Authorize(Roles = GalleryRole)]
    public class GalleryController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
