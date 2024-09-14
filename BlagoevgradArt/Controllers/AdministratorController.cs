using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Controllers
{
    [Authorize(Roles = AdministratorRole)]
    public class AdministratorController : BaseController
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministratorController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
