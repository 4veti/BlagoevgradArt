using BlagoevgradArt.Attributes;
using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Exceptions;
using BlagoevgradArt.Core.Extensions;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BlagoevgradArt.Core.Constants.ErrorMessages;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Controllers
{
    [Authorize(Roles = $"{AdministratorRole}, {AuthorRole}")]
    public class PaintingController : BaseController
    {
        private readonly IPaintingService _paintingService;
        private readonly IPaintingHelperService _paintingHelperService;
        private readonly IAuthorService _authorService;
        private readonly IWebHostEnvironment _hostingEnv;

        public PaintingController(IPaintingHelperService paintingHelperService,
            IAuthorService authorService,
            IPaintingService paintingService,
            IWebHostEnvironment hostingEnv)
        {
            _paintingService = paintingService;
            _paintingHelperService = paintingHelperService;
            _authorService = authorService;
            _hostingEnv = hostingEnv;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllPaintingsQueryModel model)
        {
            try
            {
                model.ArtTypes = await _paintingHelperService.GetArtTypesAsync();

                model.Thumbnails = await _paintingService.AllAsync(model.CurrentPage,
                    model.CountPerPage,
                    model.AuthorFirstName,
                    model.ArtType);

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize(Roles = AuthorRole)]
        public async Task<IActionResult> AllPersonal([FromQuery] AllPersonalPaintingsQueryModel model, int id = -1)
        {
            try
            {
                bool onlyNotInExhibition = id >= 0;

                model.Thumbnails = await _paintingService.AllPersonalAsync(User.Id(),
                    model.CurrentPage,
                    model.CountPerPage,
                    model.PaintingTitle,
                    onlyNotInExhibition);

                if (id >= 0)
                {
                    ViewBag.ExhibitionId = id;
                    ViewBag.IsSelectingForExhibition = true;
                }

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, string information)
        {
            try
            {
                PaintingFormModel? model = await _paintingService.GetPaintingFormModelAsync(id);
                string? correctInformation = model?.GetInformation();

                if (model == null || information != correctInformation)
                {
                    return NotFound();
                }

                model.Genres = await _paintingHelperService.GetGenresAsync();
                model.ArtTypes = await _paintingHelperService.GetArtTypesAsync();
                model.BaseTypes = await _paintingHelperService.GetBaseTypesAsync();
                model.Materials = await _paintingHelperService.GetMaterialsAsync();

                ViewBag.IsNewPainting = false;

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, PaintingFormModel? model)
        {
            try
            {
                if (model == null || await _paintingService.ExistsByIdAsync(id) == false)
                {
                    return NotFound();
                }

                string information = string.Empty;
                await ValidateImageAttributes(model);

                if (ModelState.IsValid == false)
                {
                    model.Genres = await _paintingHelperService.GetGenresAsync();
                    model.ArtTypes = await _paintingHelperService.GetArtTypesAsync();
                    model.BaseTypes = await _paintingHelperService.GetBaseTypesAsync();
                    model.Materials = await _paintingHelperService.GetMaterialsAsync();
                    ViewBag.IsNewPainting = false;

                    return View(model);
                }

                await _paintingService.EditPaintingAsync(model, id, _hostingEnv.WebRootPath);

                information = model.GetInformation();
                return RedirectToAction(nameof(Details), new { id, information });
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500, ErrorWhileSavingImage);
            }
            catch (ArgumentNullException)
            {
                return BadRequest(ImageFileWasNotReceived);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            try
            {
                PaintingDetailsModel? model = await _paintingService.GetPaintingDetailsAsync(id);
                string? correctInformation = model?.GetInformation();

                if (model == null || correctInformation != information)
                {
                    return NotFound();
                }

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize(Roles = AuthorRole)]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add()
        {
            try
            {
                PaintingFormModel model = new(await _paintingHelperService.GetGenresAsync(),
                    await _paintingHelperService.GetArtTypesAsync(),
                    await _paintingHelperService.GetBaseTypesAsync(),
                    await _paintingHelperService.GetMaterialsAsync());
                model.AuthorName = await _authorService.GetFullNameAsync(User.Id());

                ViewBag.IsNewPainting = true;

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Authorize(Roles = AuthorRole)]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Add(PaintingFormModel model)
        {
            try
            {
                await ValidateImageAttributes(model);

                if (ModelState.IsValid == false)
                {
                    model.Genres = await _paintingHelperService.GetGenresAsync();
                    model.ArtTypes = await _paintingHelperService.GetArtTypesAsync();
                    model.BaseTypes = await _paintingHelperService.GetBaseTypesAsync();
                    model.Materials = await _paintingHelperService.GetMaterialsAsync();

                    return View(model);
                }

                int id = -1;

                id = await _paintingService.AddPaintingAsync(model, User.Id(), _hostingEnv.WebRootPath);

                string information = model.GetInformation();

                return RedirectToAction(nameof(Details), new { id, information });
            }
            catch (ErrorWhileSavingImageToDiskException)
            {
                return StatusCode(500, ErrorWhileSavingImage);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, string information)
        {
            try
            {
                string? correctInformation = await _paintingService.GetInformationByIdAsync(id);

                if (await _paintingService.ExistsByIdAsync(id) == false ||
                    correctInformation == null ||
                    information != correctInformation)
                {
                    return NotFound();
                }

                await _paintingService.DeleteImageAsync(id, _hostingEnv.WebRootPath);

                return RedirectToAction(nameof(All), new { id });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        private async Task ValidateImageAttributes(PaintingFormModel model)
        {
            if (await _paintingHelperService.GenreExistsAsync(model.GenreId) == false)
            {
                ModelState.AddModelError(nameof(PaintingFormModel.GenreId), string.Format(InvalidGenreId, model.GenreId));
            }

            if (await _paintingHelperService.ArtTypeExistsAsync(model.ArtTypeId) == false)
            {
                ModelState.AddModelError(nameof(PaintingFormModel.ArtTypeId), string.Format(InvalidArtTypeId, model.ArtTypeId));
            }

            if (await _paintingHelperService.BaseTypeExistsAsync(model.BaseTypeId) == false)
            {
                ModelState.AddModelError(nameof(PaintingFormModel.BaseTypeId), string.Format(InvalidBaseTypeId, model.BaseTypeId));
            }

            if (model.Materials.Any(m => _paintingHelperService.MaterialExistsAsync(m.Id).Result == false))
            {
                ModelState.AddModelError(nameof(PaintingFormModel.Materials), string.Format(InvalidMaterialId, model.MaterialId));
            }
        }
    }
}
