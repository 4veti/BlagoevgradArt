using BlagoevgradArt.Core.Models.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlagoevgradArt.ModelBinders
{
    public class ManageUserRolesModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !string.IsNullOrWhiteSpace(valueResult.FirstValue))
            {
                bool success = false;
                var usersBasicInfoCount = Convert.ToInt32(valueResult.FirstValue);
                var usersBasicInfo = new List<UserBasicInfoModel>(usersBasicInfoCount);

                try
                {
                    for (int i = 0; i < usersBasicInfoCount; i++)
                    {
                        var isCheckedResult = bindingContext.ValueProvider.GetValue($"UsersBasicInfo[{i}].IsSelected");
                        if (isCheckedResult != ValueProviderResult.None && isCheckedResult.FirstValue == "true")
                        {
                            usersBasicInfo.Add(new UserBasicInfoModel { IsSelected = true });
                        }
                        else
                        {
                            usersBasicInfo.Add(new UserBasicInfoModel { IsSelected = false });
                        }

                        var emailResult = bindingContext.ValueProvider.GetValue($"UsersBasicInfo[{i}].Email");

                        if (emailResult != ValueProviderResult.None)
                        {
                            usersBasicInfo[i].Email = emailResult.FirstValue;
                        }

                        success = true;
                    }
                }

                catch (Exception ex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex, bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(usersBasicInfo);
                }
            }

            return Task.CompletedTask;
        }
    }
}
