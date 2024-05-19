using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Exhibition;
using BlagoevgradArt.Core.Services;
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
    }
}
