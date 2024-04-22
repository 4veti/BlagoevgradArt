using Microsoft.AspNetCore.Http;

namespace BlagoevgradArt.Core.Models.Painting
{
    public class PaintingDetailsModel
    {
        /// <summary>
        /// Unique identifier of the painting.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the painting.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Name of the painting's author.
        /// </summary>
        public string AuthorName { get; set; } = string.Empty;

        /// <summary>
        /// Year of finishing the painting.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// The painting's genre.
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// The painting's art type.
        /// </summary>
        public string ArtType { get; set; } = string.Empty;

        /// <summary>
        /// The painting's base type.
        /// </summary>
        public string BaseType { get; set; } = string.Empty;

        /// <summary>
        /// Material of the painting.
        /// </summary>
        public string Material { get; set; } = string.Empty;

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
        public string ImagePath { get; set; } = string.Empty;
    }
}
