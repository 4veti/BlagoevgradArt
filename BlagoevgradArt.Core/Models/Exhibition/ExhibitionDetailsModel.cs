namespace BlagoevgradArt.Core.Models.Exhibition
{
    public class ExhibitionDetailsModel
    {
        public string Name { get; set; } = string.Empty;

        public DateTime OpeningDate { get; set; }

        public string Description { get; set; } = string.Empty;

        public string HostGalleryName { get; set; } = string.Empty;

        public ICollection<string> Participants { get; set;} = new List<string>();
    }
}
