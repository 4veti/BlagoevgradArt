using BlagoevgradArt.Attributes;
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
        public async Task<IActionResult> Profile(int id = -1)
        {
            if (id == -1)
            {
                id = await _authorService.GetIdAsync(User.Id());
            }

            if (await _authorService.ExistsByIdAsync(id) == false)
            {
                return NotFound();
            }

            AuthorProfileInfoModel model = await _authorService
                .GetAuthorProfileInfo(id);

            return View(model);
        }

        [HttpGet]
        [MustBeExistingAuthor]
        public async Task<IActionResult> EditProfile()
        {
            AuthorProfileInfoModel model = await _authorService
                .GetAuthorProfileInfo(await _authorService.GetIdAsync(User.Id()));

            return View(new AuthorFormModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            });
        }

        [HttpPost]
        [MustBeExistingAuthor]
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
