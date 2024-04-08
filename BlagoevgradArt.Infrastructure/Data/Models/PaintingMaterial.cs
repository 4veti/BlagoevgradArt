using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The many-to-many entity class between paintings and materials.
    /// </summary>
    public class PaintingMaterial
    {
        /// <summary>
        /// Painting unique identifier.
        /// </summary>
        [Comment("Painting unique identifier. | Уникален идентификатор на картината.")]
        public int PaintingId { get; set; }

        /// <summary>
        /// Painting navigation property.
        /// </summary>
        [ForeignKey(nameof(PaintingId))]
        public Painting Painting { get; set; } = null!;

        /// <summary>
        /// Material unique identifier.
        /// </summary>
        [Comment("Material unique identifier. | Уникален идентификатор на материала.")]
        public int MaterialId { get; set; }

        /// <summary>
        /// Material navigation property.
        /// </summary>
        [ForeignKey(nameof(MaterialId))]
        public Material Material { get; set; } = null!;
    }
}
