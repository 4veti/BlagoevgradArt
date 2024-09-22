namespace BlagoevgradArt.Core.Constants
{
    public static class ErrorMessages
    {
        public const string InvalidLength = "Полето {0} трябва да е между {2} и {1} знака.";
        public const string DimensionsInvalidValue = "Полето {0} трябва да е цяло позитивно число между {1} и {2}.";
        public const string InvalidGenreId = "Жанр с идентификатор {0} не съществува.";
        public const string InvalidBaseTypeId = "Основа с идентификатор {0} не съществува.";
        public const string InvalidArtTypeId = "Вид изкуство с идентификатор {0} не съществува.";
        public const string InvalidMaterialId = "Материал с идентификатор {0} не съществува.";

        public const string ErrorWhileSavingImage = "Грешка при записването на файла.";
        public const string ImageFileWasNotReceived = "Файлът на картината от формата не беше получен.";
    }
}
