namespace BlagoevgradArt.Core.Models.Painting
{
    public class AllPersonalPaintingsQueryModel
    {
        public int CountPerPage { get; } = 4;

        public int CurrentPage { get; set; } = 1;

        public string? PaintingTitle { get; set; }

        public PaintingQueryServiceModel Thumbnails { get; set; } = null!;
    }
}
