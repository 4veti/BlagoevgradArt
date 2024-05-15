using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;
using static BlagoevgradArt.Core.Constants.ErrorMessages;

namespace BlagoevgradArt.Core.Models.Author
{
    public class AuthorFormModel
    {
        /// <summary>
        /// First name of the author.
        /// </summary>
        [Required]
        [Display(Name = "Име")]
        [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength,
            ErrorMessage = InvalidLength)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Lase name of the author.
        /// </summary>
        /// 
        [Display(Name = "Фамилия")]
        [StringLength(LastNameMaxLength,
            MinimumLength = LastNameMinLength,
            ErrorMessage = InvalidLength)]
        public string? LastName { get; set; }

        /// <summary>
        /// Author's phone number.
        /// </summary>
        [Required]
        [Display(Name = "Тел. номер")]
        [StringLength(PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage = InvalidLength)]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
