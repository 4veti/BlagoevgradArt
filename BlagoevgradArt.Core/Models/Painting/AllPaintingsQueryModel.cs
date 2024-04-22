namespace BlagoevgradArt.Core.Models.Painting
{
    public class AllPaintingsQueryModel
    {
        public int CountPerPage { get; } = 3;

        public int TotalPaintingsCount { get; set; }

        public int CurrentPage { get; set; } = 1;

        public PaintingQueryServiceModel Thumbnails { get; set; } = null!;
    }
}
