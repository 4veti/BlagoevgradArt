using BlagoevgradArt.Core.Contracts;
using System.Text.RegularExpressions;

namespace BlagoevgradArt.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this IPaintingInformationModel model)
        {
            string descriptionPart = model.Description ?? "Beautiful-Art-Piece";
            string authorName = model.AuthorName.TransliterateCyrillicToLatin();
            string title = model.Title.TransliterateCyrillicToLatin();

            if (string.IsNullOrWhiteSpace(model.Description) == false)
            {
                descriptionPart = string.Join('-', descriptionPart
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Take(3))
                    .TransliterateCyrillicToLatin();
            }

            string info = $"{authorName}-{title}-{descriptionPart}-{model.HeightCm}x{model.WidthCm}".Replace(" ", "-");
            info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

            return info;
        }
    }
}
