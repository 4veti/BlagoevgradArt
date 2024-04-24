using BlagoevgradArt.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlagoevgradArt.Attributes
{
    public class MustBeExistingAuthorAttribute : ActionFilterAttribute
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
        }
    }
}
