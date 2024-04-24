using System.ComponentModel.DataAnnotations;

namespace BlagoevgradArt.Core.Models.Painting
{
    public class AllPaintingsQueryModel
    {
        public int CountPerPage { get; } = 3;

        public int CurrentPage { get; set; } = 1;

        [Display(Name = "Search by Author first name:")]
        public string? AuthorFirstName { get; set; }

        public string? ArtType { get; set; }

        public IEnumerable<ArtTypeViewModel> ArtTypes { get; set; } = new List<ArtTypeViewModel>();

        public PaintingQueryServiceModel Thumbnails { get; set; } = null!;
    }
}
