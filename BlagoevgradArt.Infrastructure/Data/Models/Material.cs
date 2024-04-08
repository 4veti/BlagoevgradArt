using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The material entity class.
    /// </summary>
    public class Material
    {
        /// <summary>
        /// Material's unique identifier.
        /// </summary>
        [Key]
        [Comment("Material's unique identifier. | Уникален идентификатор на материала.")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the material.
        /// </summary>
        [Required]
        [MaxLength(MaterialNameMaxLength)]
        [Comment("Name of the material. | Име на материала.")]
        public string Name { get; set; } = string.Empty;
    }
}