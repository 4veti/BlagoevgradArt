using BlagoevgradArt.Core.Models.Author;

namespace BlagoevgradArt.Core.Models.Exhibition;

public class ExhibitionDetailsModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime OpeningDate { get; set; }

    public string Description { get; set; } = string.Empty;

    public string HostGalleryName { get; set; } = string.Empty;

    public ICollection<AuthorSmallThumbnailModel> AcceptedAuthors { get; set; } = new List<AuthorSmallThumbnailModel>();

    public ICollection<AuthorSmallThumbnailModel> NotAcceptedAuthors { get; set; } = new List<AuthorSmallThumbnailModel>();
}
