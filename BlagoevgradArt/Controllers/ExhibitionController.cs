﻿using BlagoevgradArt.Attributes;
using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Exhibition;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers
{
    public class ExhibitionController : BaseController
    {
        IExhibitionService _exhibitionService;
        IGalleryService _galleryService;

        public ExhibitionController(IExhibitionService exhibitionService
            ,IGalleryService galleryService)
        {
            _exhibitionService = exhibitionService;
            _galleryService = galleryService;
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery]ExhibitionAllModel model)
        {
            model.Exhibitions = await _exhibitionService.GetAllAsync(model.CurrentPage, model.CountPerPage);

            return View(model);
        }

        [HttpGet]
        [MustBeExistingGallery]
        public async Task<IActionResult> Edit(int id)
        {
            ExhibitionFormModel model = await _exhibitionService.GetFormDataByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        [MustBeExistingGallery]
        public async Task<IActionResult> Edit(int id, ExhibitionFormModel model)
        {
            await _exhibitionService.EditExhibitionAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            ExhibitionDetailsModel? model = await _exhibitionService.GetInfoAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpGet]
        [MustBeExistingGallery]
        public async Task<IActionResult> Add()
        {
            if (!await _galleryService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }

            return View();
        }

        [HttpPost]
        [MustBeExistingGallery]
        public async Task<IActionResult> Add(ExhibitionFormModel model)
        {
            int galleryId = await _galleryService.GetIdAsync(User.Id());

            if (!await _galleryService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }

            if (ModelState.IsValid == false)
            {
                return View();
            }

            int exhibitionId = await _exhibitionService.SaveExhibitionAsync(galleryId, model);

            return RedirectToAction(nameof(Details), new { id = exhibitionId });
        }
    }
}
