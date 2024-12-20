﻿using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Controllers
{
    [Authorize(Roles = AdministratorRole)]
    public class RolesController : BaseController
    {
        private readonly IUserService _userService;

        public RolesController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> AssignRoles()
        {
            try
            {
                ManageUserRolesModel model = new ManageUserRolesModel()
                {
                    UsersBasicInfo = await _userService.GetAllUsersBasicInfoAsync()
                };

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AssignRoles(ManageUserRolesModel model)
        {
            try
            {
                if (ModelState.IsValid == false)
                {
                    return RedirectToAction(nameof(AssignRoles));
                }

                await _userService.AssignRolesToSelectedUsersAsync(model);

                return RedirectToAction(nameof(AssignRoles));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromRole(string email, string inRoles)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(inRoles) == false)
                {
                    await _userService.RemoveUserFromRoleAsync(email, inRoles);
                }

                return RedirectToAction(nameof(AssignRoles));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
