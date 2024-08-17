using BlagoevgradArt.Core.Models.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlagoevgradArt.ModelBinders
{
    public class ManageUserRolesModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(ManageUserRolesModel))
            {
                return new ManageUserRolesModelBinder();
            }

            return null;
        }
    }
}
