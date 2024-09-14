using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Controllers
{
    [Authorize(Roles = AdministratorRole)]
    public class RolesController : BaseController
    {
        private IUserService _userService;

        public RolesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> AssignRoles()
        {
            ManageUserRolesModel model = new ManageUserRolesModel()
            {
                UsersBasicInfo = await _userService.GetAllUsersBasicInfoAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoles(ManageUserRolesModel model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction(nameof(AssignRoles));
            }

            await _userService.AssignRolesToSelectedUsersAsync(model);

            return RedirectToAction(nameof(AssignRoles));
        }
    }
}
