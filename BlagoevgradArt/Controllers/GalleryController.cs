using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Controllers
{
    [Authorize(Roles = GalleryRole)]
    public class GalleryController : BaseController
    {
        private readonly IGalleryService _galleryService;
        private readonly IExhibitionService _exhibitionService;
        private readonly IAuthorService _authorService;
        private readonly IPaintingService _paintingService;

        public GalleryController(IGalleryService galleryService,
            IExhibitionService exhibitionService,
            IAuthorService authorService,
            IPaintingService paintingService)
        {
            _galleryService = galleryService;
            _exhibitionService = exhibitionService;
            _authorService = authorService;
            _paintingService = paintingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PendingPaintingsForApproval(int id, int authorId)
        {
            try
            {
                if (await _exhibitionService.ExistsByIdAsync(id) == false ||
                    await _authorService.ExistsByIdAsync(authorId) == false)
                {
                    return BadRequest();
                }

                if (await _exhibitionService.GalleryUserIsOwnerOfExhibitionAsync(User.Id(), id) == false)
                {
                    return Unauthorized();
                }

                List<PaintingThumbnailModel> model = await _paintingService.GetPendingPaintingsForApprovalAsync(id, authorId);
                ViewBag.CountAccepted = await _exhibitionService.GetCountAcceptedPaintingsForAuthorAsync(authorId, id);

                if (model.Any() == false)
                {
                    return RedirectToAction(nameof(ExhibitionController.Details), "Exhibition", new { id });
                }

                return View(model);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApproveOrDisapprovePainting(int id, bool approved)
        {
            try
            {
                int exhibitionId = await _galleryService.ApproveOrDisapprovePaintingAsync(id, User.Id(), approved);

                return RedirectToAction(nameof(ExhibitionController.Details), "Exhibition", new { id = exhibitionId });
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
