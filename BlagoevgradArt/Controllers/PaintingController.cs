﻿using BlagoevgradArt.Attributes;
using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Extensions;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BlagoevgradArt.Core.Constants.ErrorMessages;

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
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] AllPaintingsQueryModel model)
        {
            model.ArtTypes = await _paintingHelperService.GetArtTypesAsync();

            model.Thumbnails = await _paintingService.AllAsync(model.CurrentPage,
                model.CountPerPage,
                model.AuthorFirstName,
                model.ArtType);

            return View(model);
        }

        [HttpGet]
        [MustBeExistingAuthor]
        public async Task<IActionResult> Edit(int id, string information)
        {
            PaintingFormModel? model = await _paintingService.GetPaintingFormModel(id);
            string? correctInformation = model?.GetInformation();

            if (model == null || information != correctInformation)
            {
                return NotFound();
            }

            ViewBag.IsNewPainting = false;

            return View(model);
        }

        [HttpPost]
        [MustBeExistingAuthor]
        public async Task<IActionResult> Edit(int id, PaintingFormModel? model)
        {
            if (model == null || await _paintingService.ExistsByIdAsync(id) == false)
            {
                return NotFound();
            }

            string information = string.Empty;

            // The model binder doesn't bind the lists of materials, bases, etc. so I just redirect to the
            // HttpPost Action.
            //
            // TODO: Implement a helper method that repopulates the FormModel so I can do Return(View)
            // and display the validation error messages.
            if (ModelState.IsValid == false)
            {
                information = await _paintingService.GetInformationById(id) ?? string.Empty;
                return RedirectToAction(nameof(Edit), new { id, information });
            }

            try
            {
                await _paintingService.EditPaintingAsync(model, id, _hostingEnv.WebRootPath);
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

            information = model.GetInformation();
            return RedirectToAction(nameof(Details), new { id, information });

        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id, string information)
        {
            PaintingDetailsModel? model = await _paintingService.GetPaintingDetailsAsync(id);
            string? correctInformation = model?.GetInformation();

            if (model == null || correctInformation != information)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        [MustBeExistingAuthor]
        public async Task<IActionResult> Add()
        {
            PaintingFormModel model = new(await _paintingHelperService.GetGenresAsync(),
                await _paintingHelperService.GetArtTypesAsync(),
                await _paintingHelperService.GetBaseTypesAsync(),
                await _paintingHelperService.GetMaterialsAsync());
            model.AuthorName = await _authorService.GetFullNameAsync(User.Id());

            ViewBag.IsNewPainting = true;

            return View(model);
        }

        [HttpPost]
        [MustBeExistingAuthor]
        public async Task<IActionResult> Add(PaintingFormModel model)
        {
            ValidateImageAttributes(model);

            if (ModelState.IsValid == false)
            {
                return RedirectToAction(nameof(Add));
            }

            int id = -1;

            try
            {
                id = await _paintingService.AddPaintingAsync(model, User.Id(), _hostingEnv.WebRootPath);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(500, ErrorWhileSavingImage);
            }
            catch
            {
                return StatusCode(500);
            }

            string information = model.GetInformation();

            return RedirectToAction(nameof(Details), new { id, information });
        }

        [HttpPost]
        [MustBeExistingAuthor]
        public async Task<IActionResult> Delete(int id, string information)
        {
            string? correctInformation = await _paintingService.GetInformationById(id);

            if (await _paintingService.ExistsByIdAsync(id) == false ||
                correctInformation == null ||
                information != correctInformation)
            {
                return NotFound();
            }

            await _paintingService.DeleteImageAsync(id, _hostingEnv.WebRootPath);

            return RedirectToAction(nameof(All), new { id });
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
