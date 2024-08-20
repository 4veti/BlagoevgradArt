using BlagoevgradArt.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlagoevgradArt.Attributes;

public class ExhibitionMustExistAttribute : ActionFilterAttribute
{
    public override  void OnActionExecuting(ActionExecutingContext context)
    {
        IExhibitionService? _exhibitionService = context.HttpContext.RequestServices.GetService<IExhibitionService>();

        if (_exhibitionService == null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
        else if (context.HttpContext.GetRouteData().Values.TryGetValue("id", out var inputId))
        {
            if (int.TryParse(inputId?.ToString(), out int id))
            {
                if (_exhibitionService.ExistsByIdAsync(id).Result == false)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status404NotFound);
                }
            }
        }

        base.OnActionExecuting(context);
    }
}
