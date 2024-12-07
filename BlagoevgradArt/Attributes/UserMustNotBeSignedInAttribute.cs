using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlagoevgradArt.Attributes;

public class UserMustNotBeSignedInAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.User?.Identity?.IsAuthenticated ?? false)
        {
            context.Result = new LocalRedirectResult("~/Identity/Account/Logout");
        }

        base.OnActionExecuting(context);
    }
}
