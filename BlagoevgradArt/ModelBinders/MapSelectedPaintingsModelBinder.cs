using BlagoevgradArt.Core.Models.Painting;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BlagoevgradArt.ModelBinders
{
    public class MapSelectedPaintingsModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            bool success = false;
            var countResult = bindingContext.ValueProvider.GetValue("CountSelectedPaintings");

            if (int.TryParse(countResult.FirstValue, out int countPaintings) == false)
            {
                success = false;
            }

            List<int> selectedPaintings = new(countPaintings);

            try
            {
                for (int i = 0; i < countPaintings; i++)
                {
                    var isCheckedResult = bindingContext.ValueProvider.GetValue($"Painting[{i}].IsSelected");
                    if (isCheckedResult != ValueProviderResult.None && isCheckedResult.FirstValue != "true")
                    {
                        continue;
                    }

                    var idResult = bindingContext.ValueProvider.GetValue($"Painting[{i}].Id");
                    if (idResult == ValueProviderResult.None || int.TryParse(idResult.FirstValue, out int paintingId) == false)
                    {
                        continue;
                    }

                    selectedPaintings.Add(paintingId);
                }

                success = true;
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex, bindingContext.ModelMetadata);
            }

            if (success)
            {
                bindingContext.Result = ModelBindingResult.Success(selectedPaintings);
            }

            return Task.CompletedTask;
        }
    }
}
