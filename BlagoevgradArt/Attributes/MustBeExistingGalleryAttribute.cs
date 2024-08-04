﻿using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlagoevgradArt.Attributes
{
    public class MustBeExistingGalleryAttribute : ActionFilterAttribute
    {
        public override async void OnActionExecuting(ActionExecutingContext context)
        {
            IGalleryService? _galleryService = context.HttpContext.RequestServices.GetService<IGalleryService>();

            if (_galleryService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (_galleryService != null &&
                await _galleryService.ExistsByIdAsync(context.HttpContext.User.Id()) == false)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }

            base.OnActionExecuting(context);
        }
    }
}
