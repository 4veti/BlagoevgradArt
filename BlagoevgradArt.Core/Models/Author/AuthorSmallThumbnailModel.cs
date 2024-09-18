namespace BlagoevgradArt.Core.Models.Author;

public class AuthorSmallThumbnailModel
{
    public int Id { get; set; }

    public string FullName { get; set; } = string.Empty;

    public bool HasPendingPaintings { get; set; }
}
