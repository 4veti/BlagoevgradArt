namespace BlagoevgradArt.Core.Models.Exhibition
{
    public class ExhibitionAllServiceModel
    {
        public ICollection<ExhibitionThumbnailModel> Thumbnails { get; set; } = new List<ExhibitionThumbnailModel>();

        public int TotalExhibitions { get; set; }
    }
}
