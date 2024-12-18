using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Author;
using BlagoevgradArt.Extensions;
using BlagoevgradArt.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Controllers
{
    [Authorize(Roles = AuthorRole)]
    public class AuthorController : BaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IExhibitionService _exhibitionService;

        public AuthorController(IAuthorService authorService,
            IExhibitionService exhibitionService)
        {
            _authorService = authorService;
            _exhibitionService = exhibitionService;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(Profile));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Profile(int id = -1)
        {
            try
            {
                ViewBag.IsOwnerProfile = false;

                if (id == -1)
                {
                    id = await _authorService.GetIdAsync(User.Id());
                    ViewBag.IsOwnerProfile = true;
                }

                AuthorProfileInfoModel? model = await _authorService
                    .GetAuthorProfileInfoAsync(id);

                if (model is null)
                {
                    return NotFound();
                }

                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            try
            {
                AuthorProfileInfoModel? model = await _authorService
                    .GetAuthorProfileInfoAsync(await _authorService.GetIdAsync(User.Id()));

                if (model is null)
                {
                    return NotFound();
                }

                return View(new AuthorFormModel()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber
                });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(AuthorFormModel model)
        {
            try
            {
                if (await _authorService.ExistsByIdAsync(User.Id()) == false)
                {
                    return LocalRedirect("~/");
                }

                if (ModelState.IsValid == false)
                {
                    return RedirectToAction(nameof(EditProfile));
                }

                await _authorService.SetAuthorProfileInfoAsync(model, User.Id());

                return RedirectToAction(nameof(Profile));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> RequestToJoinExhibition(int id)
        {
            try
            {
                bool isSuccessfulRequest = await _authorService.SubmitRequestToJoinExhibitionAsync(User.Id(), id);

                if (isSuccessfulRequest == false)
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(ExhibitionController.Details), "Exhibition", new { id });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPaintingsRequest(int exhibitionId,
            [ModelBinder(BinderType = typeof(MapSelectedPaintingsModelBinder))] List<int> models)
        {
            try
            {
                bool successfullySubmittedAll = await _exhibitionService.SubmitPaintingsRequestAsync(models, exhibitionId);

                if (successfullySubmittedAll == false)
                {
                    return BadRequest();
                }

                return RedirectToAction(nameof(ExhibitionController.Details), "Exhibition", new { id = exhibitionId });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
