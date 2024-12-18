using BlagoevgradArt.Attributes;
using BlagoevgradArt.Controllers;
using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllerst;

public class MyAccountController : BaseController
{
    private readonly IUserService _userService;
    private readonly SignInManager<IdentityUser> _signInManager;

    public MyAccountController(SignInManager<IdentityUser> signInManager,
        IUserService userServire)
    {
        _signInManager = signInManager;
        _userService = userServire;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Login(string? returnUrl)
    {
        try
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View(new LoginModel() { ReturnUrl = returnUrl ?? "~/" });
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginModel model)
    {
        try
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return LocalRedirect(model.ReturnUrl);
            }

            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
            }

            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [AllowAnonymous]
    [UserMustNotBeSignedIn]
    public IActionResult Register()
    {
        return View(new RegisterAuthorModel());
    }

    [HttpGet]
    [AllowAnonymous]
    [UserMustNotBeSignedIn]
    public IActionResult RegisterAuthor()
    {
        return View(new RegisterAuthorModel());
    }

    [HttpPost]
    [AllowAnonymous]
    [UserMustNotBeSignedIn]
    public async Task<IActionResult> RegisterAuthor(RegisterAuthorModel model)
    {
        try
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            List<string> errors = await _userService.RegisterUserAsync(model);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return View(model);
            }

            return LocalRedirect("~/");
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }

    [HttpGet]
    [AllowAnonymous]
    [UserMustNotBeSignedIn]
    public IActionResult RegisterGallery()
    {
        return View(new RegisterGalleryModel());
    }

    [HttpPost]
    [AllowAnonymous]
    [UserMustNotBeSignedIn]
    public async Task<IActionResult> RegisterGallery(RegisterGalleryModel model)
    {
        try
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            List<string> errors = await _userService.RegisterUserAsync(model);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
                return View(model);
            }

            return LocalRedirect("~/");
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
