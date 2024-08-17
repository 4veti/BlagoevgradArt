using BlagoevgradArt.Core.Contracts;

namespace BlagoevgradArt.Core.Models.Painting
{
    public class PaintingThumbnailModel : IPaintingInformationModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public int HeightCm { get; set; }

        public int WidthCm { get; set; }

        public string ImagePath { get; set; } = string.Empty;
    }
}
