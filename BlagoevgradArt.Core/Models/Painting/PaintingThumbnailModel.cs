namespace BlagoevgradArt.Core.Models.Painting
{
    public class PaintingThumbnailModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string AuthorName { get; set; } = string.Empty;

        public int Height { get; set; }

        public int Width { get; set; }

        public string ImagePath { get; set; } = string.Empty;
    }
}
