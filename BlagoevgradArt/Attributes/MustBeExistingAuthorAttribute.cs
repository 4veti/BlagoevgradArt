﻿using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlagoevgradArt.Attributes
{
    public class MustBeExistingAuthorAttribute : ActionFilterAttribute
    {
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            IAuthorService? _authorService = context.HttpContext.RequestServices.GetService<IAuthorService>();

            if (_authorService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (_authorService != null &&
                await _authorService.ExistsByIdAsync(context.HttpContext.User.Id()) == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            base.OnActionExecuting(context);
        }
    }
}
