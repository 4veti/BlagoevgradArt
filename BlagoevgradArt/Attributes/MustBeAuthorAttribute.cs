using BlagoevgradArt.Controllers;
using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlagoevgradArt.Attributes
{
    public class MustBeAuthorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            IAuthorService? _authorService = context.HttpContext.RequestServices.GetService<IAuthorService>();

            if (_authorService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                return;
            }

            if (_authorService.ExistsByIdAsync(context.HttpContext.User.Id()).Result == false)
            {
                context.Result = new RedirectToActionResult(nameof(AuthorController.Become), "Author", null);
            }
        }
    }
}
