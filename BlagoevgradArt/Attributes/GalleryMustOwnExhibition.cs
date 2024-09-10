using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlagoevgradArt.Attributes
{
    public class GalleryMustOwnExhibitionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            IExhibitionService? _exhibitionService = context.HttpContext.RequestServices.GetService<IExhibitionService>();

            if (_exhibitionService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            else
            {
                if (int.TryParse((context.ActionArguments["id"] ?? "-1").ToString(), out int exhibitionId))
                {
                    bool galleryIsOwnerOfExhibition = _exhibitionService.GalleryUserIsOwnerOfExhibitionAsync(context.HttpContext.User.Id(), exhibitionId).Result;

                    if (galleryIsOwnerOfExhibition == false)
                    {
                        context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                    }
                }
                else
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
