using BlagoevgradArt.Core.Models.User;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlagoevgradArt.ModelBinders
{
    public class ManageUserRolesModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            bool success = false;
            int usersBasicInfoCount = Convert.ToInt32(bindingContext.ValueProvider.GetValue("count").FirstValue);
            List<UserBasicInfoModel> usersBasicInfo = new (usersBasicInfoCount);
            ManageUserRolesModel manageUserRolesModel = new ();

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

                    var emailResult = bindingContext.ValueProvider.GetValue($"UserBasicInfo[{i}].Email");

                    if (emailResult != ValueProviderResult.None)
                    {
                        usersBasicInfo[i].Email = emailResult.FirstValue;
                    }
                }

                var selectedRoleValue = bindingContext.ValueProvider.GetValue("SelectedRoleName");

                if (selectedRoleValue != ValueProviderResult.None && selectedRoleValue.FirstValue != null)
                {
                    manageUserRolesModel.SelectedRoleName = selectedRoleValue.FirstValue;
                    manageUserRolesModel.UsersBasicInfo = usersBasicInfo;
                    success = true;
                }
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex, bindingContext.ModelMetadata);
            }

            if (success)
            {
                bindingContext.Result = ModelBindingResult.Success(manageUserRolesModel);
            }

            return Task.CompletedTask;
        }
    }
}
