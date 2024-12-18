using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace BlagoevgradArt.Controllers;

[Route("api/statistics")]
[ApiController]
public class StatisticsApiController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsApiController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            GeneralStatisticsInfoModel model = await _statisticsService.GetGeneralStatisticsInfoAsync();

            return Ok(model);
        }
        catch (Exception)
        {
            return StatusCode(500);
        }
    }
}
