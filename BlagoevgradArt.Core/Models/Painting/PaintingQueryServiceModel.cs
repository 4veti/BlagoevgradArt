namespace BlagoevgradArt.Core.Models.Painting
{
    public class PaintingQueryServiceModel
    {
        public IEnumerable<PaintingThumbnailModel> Thumbnails { get; set; } = new List<PaintingThumbnailModel>();

        public int TotalThumbnailsCount { get; set; }
    }
}
