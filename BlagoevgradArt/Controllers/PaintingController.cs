using BlagoevgradArt.Attributes;
using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
    public class PaintingController : BaseController
    {
        private readonly IPaintingService _paintingService;
        private readonly IPaintingHelperService _paintingHelperService;
        private readonly IAuthorService _authorService;

        public PaintingController(IPaintingHelperService paintingHelperService,
            IAuthorService authorService,
            IPaintingService paintingService)
        {
            _paintingService = paintingService;
            _paintingHelperService = paintingHelperService;
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return RedirectToAction(nameof(Add));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {


            return View();
        }

        [HttpGet]
        [MustBeAuthor]
        public async Task<IActionResult> Add()
        {
            PaintingFormModel model = new(await _paintingHelperService.GetGenresAsync(),
                await _paintingHelperService.GetArtTypesAsync(),
                await _paintingHelperService.GetBaseTypesAsync(),
                await _paintingHelperService.GetMaterialsAsync());

            return View(model);
        }

        [HttpPost]
        [MustBeAuthor]
        public async Task<IActionResult> Add(PaintingFormModel model)
        {
            if (await _paintingHelperService.GenreExistsAsync(model.GenreId) == false)
            {
                ModelState.AddModelError(nameof(PaintingFormModel.GenreId), "Genre does not exist.");
            }

            if (await _paintingHelperService.ArtTypeExistsAsync(model.ArtTypeId) == false)
            {
                ModelState.AddModelError(nameof(PaintingFormModel.ArtTypeId), "Art type does not exist.");
            }

            if (await _paintingHelperService.BaseTypeExistsAsync(model.BaseTypeId) == false)
            {
                ModelState.AddModelError(nameof(PaintingFormModel.BaseTypeId), "Base type does not exist.");
            }

            if (model.Materials.Any(m => _paintingHelperService.MaterialExistsAsync(m.Id).Result == false))
            {
                ModelState.AddModelError(nameof(PaintingFormModel.Materials), "One or more material types do not exist.");
            }

            if (ModelState.IsValid == false)
            {
                return RedirectToAction(nameof(Add));                // See if this behaves as expected and keeps error messages displayed.
            }

            int authorId = await _authorService.GetIdAsync(User.Id());

            int id = await _paintingService.AddPaintingAsync(model, authorId);

            return RedirectToAction(nameof(Details), new { id, model });
        }
    }
}
