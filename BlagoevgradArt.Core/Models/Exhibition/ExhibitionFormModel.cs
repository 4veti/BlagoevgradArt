using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Core.Models.Exhibition
{
    public class ExhibitionFormModel
    {
        [Required]
        [StringLength(ExhibitionNameMaxLength,
            MinimumLength = ExhibitionNameMinLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public DateTime OpeningDate { get; set; }

        [Required]
        [StringLength(ExhibitionDescriptionMaxLength,
            MinimumLength = ExhibitionDescriptionMinLength)]
        public string Description { get; set; } = string.Empty;
    }
}
