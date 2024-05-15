using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Author;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
    public class AuthorController : BaseController
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Profile()
        {
            AuthorProfileInfoModel model = await _authorService
                .GetAuthorProfileInfo(User.Id());

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            AuthorProfileInfoModel model = await _authorService
                .GetAuthorProfileInfo(User.Id());

            return View(new AuthorFormModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            });
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(AuthorFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction(nameof(EditProfile));
            }

            await _authorService.SetAuthorProfileInfo(model, User.Id());

            return RedirectToAction(nameof(Profile));
        }
    }
}
