namespace BlagoevgradArt.Core.Models.Exhibition
{
    public class ExhibitionThumbnailModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public DateTime OpeningDate { get; set; }

        public string HostGalleryName { get; set; } = string.Empty;

        public int CountArtworks { get; set; }
    }
}
