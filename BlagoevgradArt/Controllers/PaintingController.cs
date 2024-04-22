using BlagoevgradArt.Attributes;
using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
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
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Add));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery]AllPaintingsQueryModel model)
        {
            model.Thumbnails = await _paintingService.AllAsync(model.CurrentPage, model.CountPerPage);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            PaintingFormModel model = await _paintingService.GetPaintingFormModel(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PaintingFormModel model)
        {
            await _paintingService.EditPaintingAsync(model, id, _hostingEnv.WebRootPath);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            PaintingDetailsModel? model = await _paintingService.GetPaintingDetailsAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
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
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(PaintingFormModel model)
        {
            ValidateImageAttributes(model);

            if (ModelState.IsValid == false)
            {
                return RedirectToAction(nameof(Add));
            }

            string filePath = Path.Combine(_hostingEnv.WebRootPath, "Images\\Paintings");
            filePath = Path.Combine(filePath, model.ImageFile.FileName);
            
            using (FileStream stream = System.IO.File.Create(filePath))
            {
                await model.ImageFile.CopyToAsync(stream);
            }

            int authorId = await _authorService.GetIdAsync(User.Id());

            int id = await _paintingService.AddPaintingAsync(model, authorId, $"~/Images/Paintings/{model.ImageFile.FileName}");

            return RedirectToAction(nameof(Details), new { id });
        }

        private async void ValidateImageAttributes(PaintingFormModel model)
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
        }
    }
}
