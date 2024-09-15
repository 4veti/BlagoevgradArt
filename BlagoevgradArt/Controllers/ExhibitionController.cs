using BlagoevgradArt.Attributes;
using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Exhibition;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Controllers
{
    [Authorize(Roles = $"{GalleryRole}, {AdministratorRole}")]
    public class ExhibitionController : BaseController
    {
        private readonly IExhibitionService _exhibitionService;
        private readonly IGalleryService _galleryService;
        private readonly IAuthorService _authorService;

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
            try
            {
                model.Exhibitions = await _exhibitionService.GetAllAsync(model.CurrentPage, model.CountPerPage);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return View(model);
        }

        [HttpGet]
        [ExhibitionOwnerOrAdministrator]
        public async Task<IActionResult> Edit(int id)
        {
            ExhibitionFormModel? model = await _exhibitionService.GetFormDataByIdAsync(id);

            if (model == null)
            {
                return NotFound();
            }

            ViewBag.IsNewExhibition = false;

            return View(model);
        }

        [HttpPost]
        [ExhibitionOwnerOrAdministrator]
        public async Task<IActionResult> Edit(int id, ExhibitionFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(id);
            }

            try
            {
                bool editedSuccessfully = await _exhibitionService.EditExhibitionAsync(id, model);

                if (editedSuccessfully == false)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

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

            bool isGalleryOwnerOfExhibition = await _exhibitionService.GalleryUserIsOwnerOfExhibitionAsync(User.Id(), id);
            ViewBag.GalleryIsOwnerOfExhibition = isGalleryOwnerOfExhibition;

            ViewBag.CurrentAuthorId = await _authorService.GetIdAsync(User.Id());
            ViewBag.IsAuthorPartOfExhibition = await _exhibitionService.IsAuthorPartOfExhibitionAsync(User.Id(), id);

            ViewBag.IsAuthorRequestedToJoin = await _exhibitionService.IsAuthorRequestedToJoinExhibitionAsync(User.Id(), id);

            if (isGalleryOwnerOfExhibition)
            {
                model.NotAcceptedAuthors = await _authorService.GetAuthorThumbnailsAsync(id, false);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = GalleryRole)]
        public IActionResult Add()
        {
            ViewBag.IsNewExhibition = true;
            return View(new ExhibitionFormModel());
        }

        [HttpPost]
        [Authorize(Roles = GalleryRole)]
        public async Task<IActionResult> Add(ExhibitionFormModel model)
        {
            int galleryId = await _galleryService.GetIdAsync(User.Id());

            if (ModelState.IsValid == false)
            {
                return View();
            }

            try
            {
                int exhibitionId = await _exhibitionService.SaveExhibitionAsync(galleryId, model);
                return RedirectToAction(nameof(Details), new { id = exhibitionId });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ExhibitionOwnerOrAdministrator]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isDeletedSuccessfully = await _exhibitionService.DeleteExhibitionAsync(id);

                if (isDeletedSuccessfully)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(All));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [ExhibitionOwnerOrAdministrator]
        [Authorize(Roles = GalleryRole)]
        public async Task<IActionResult> AddAuthor(int id, int authorId)
        {
            try
            {
                bool addAuthorResult = await _exhibitionService.AddAuthorToExhibitionAsync(id, authorId);

                if (addAuthorResult == false)
                {
                    return NotFound();
                }
            }
            catch (InvalidOperationException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpPost]
        [ExhibitionOwnerOrAdministrator]
        public async Task<IActionResult> RemoveAuthor(int id, int authorId)
        {
            try
            {
                bool isRemovedSuccessfully = await _exhibitionService.RemoveAuthorFromExhibitionAsync(id, authorId);

                if (isRemovedSuccessfully == false)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
