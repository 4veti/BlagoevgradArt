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

        public ExhibitionController(IExhibitionService exhibitionService)
        {
            _exhibitionService = exhibitionService;
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
        public async Task<IActionResult> Add()
        {
            if (!await _exhibitionService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExhibitionFormModel model)
        {
            int galleryId = await _exhibitionService.GetIdAsync(User.Id());

            if (!await _exhibitionService.ExistsByIdAsync(User.Id()))
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
