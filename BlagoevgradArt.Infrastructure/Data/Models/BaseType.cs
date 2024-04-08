using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    /// <summary>
    /// The base type entity class.
    /// </summary>
    public class BaseType
    {
        /// <summary>
        /// Base type's unique identifier.
        /// </summary>
        [Key]
        [Comment("Base type's unique identifier. | Уникален идентификатор на основата.")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the base type.
        /// </summary>
        [Required]
        [MaxLength(BaseTypeNameMaxLength)]
        [Comment("Base type's name. | Име на основата.")]
        public string Name { get; set; } = string.Empty;
    }
}