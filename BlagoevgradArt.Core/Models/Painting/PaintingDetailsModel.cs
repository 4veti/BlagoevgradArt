using Microsoft.AspNetCore.Http;

namespace BlagoevgradArt.Core.Models.Painting
{
    public class PaintingDetailsModel
    {
        /// <summary>
        /// Title of the painting.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Name of the painting's author.
        /// </summary>
        public int AuthorName { get; set; }

        /// <summary>
        /// Year of finishing the painting.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// The painting's genre.
        /// </summary>
        public int Genre { get; set; }

        /// <summary>
        /// The painting's art type.
        /// </summary>
        public int ArtType { get; set; }

        /// <summary>
        /// The painting's base type.
        /// </summary>
        public int BaseType { get; set; }

        /// <summary>
        /// Material of the painting.
        /// </summary>
        public int Material { get; set; }

        /// <summary>
        /// Description of the painting.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Height of the painting in centimeters.
        /// </summary>
        public int HeightCm { get; set; }

        /// <summary>
        /// Width of the painting in centimeters;
        /// </summary>
        public int WidthCm { get; set; }

        /// <summary>
        /// Physical availability of the painting.
        /// </summary>
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Painting's file.
        /// </summary>
        public IFormFile ImageFile { get; set; } = null!;
    }
}
