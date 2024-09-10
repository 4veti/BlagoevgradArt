using BlagoevgradArt.Attributes;
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
        IAuthorService _authorService;

        public ExhibitionController(IExhibitionService exhibitionService
            , IGalleryService galleryService
            , IAuthorService authorService)
        {
            _exhibitionService = exhibitionService;
            _galleryService = galleryService;
            _authorService = authorService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All([FromQuery] ExhibitionAllModel model)
        {
            model.Exhibitions = await _exhibitionService.GetAllAsync(model.CurrentPage, model.CountPerPage);

            return View(model);
        }

        [HttpGet]
        [MustBeExistingGallery]
        [ExhibitionMustExist]
        public async Task<IActionResult> Edit(int id)
        {
            ExhibitionFormModel model = await _exhibitionService.GetFormDataByIdAsync(id);
            ViewBag.IsNewExhibition = false;

            return View(model);
        }

        [HttpPost]
        [MustBeExistingGallery]
        [ExhibitionMustExist]
        public async Task<IActionResult> Edit(int id, ExhibitionFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(id);
            }

            await _exhibitionService.EditExhibitionAsync(id, model);

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        [AllowAnonymous]
        [ExhibitionMustExist]
        public async Task<IActionResult> Details(int id)
        {
            ExhibitionDetailsModel model = await _exhibitionService.GetInfoAsync(id);

            if (await _exhibitionService.GalleryUserIsOwnerOfExhibition(User.Id(), id))
            {
                model.AuthorSmallThumbnails = await _exhibitionService.GetAuthorThumbnails(id);
            }

            return View(model);
        }

        [HttpGet]
        [MustBeExistingGallery]
        public IActionResult Add()
        {
            ViewBag.IsNewExhibition = true;
            return View(new ExhibitionFormModel());
        }

        [HttpPost]
        [MustBeExistingGallery]
        public async Task<IActionResult> Add(ExhibitionFormModel model)
        {
            int galleryId = await _galleryService.GetIdAsync(User.Id());

            if (ModelState.IsValid == false)
            {
                return View();
            }

            int exhibitionId = await _exhibitionService.SaveExhibitionAsync(galleryId, model);

            return RedirectToAction(nameof(Details), new { id = exhibitionId });
        }

        [HttpPost]
        [MustBeExistingGallery]
        [ExhibitionMustExist]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _exhibitionService.DeleteExhibitionAsync(id) == false)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(All));
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [MustBeExistingGallery]
        public async Task<IActionResult> AddAuthor(int id, int authorId)
        {
            if (await _authorService.ExistsByIdAsync(authorId) == false)
            {
                return NotFound();
            }

            await _exhibitionService.AddAuthorToExhibitionAsync(id, authorId);

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
