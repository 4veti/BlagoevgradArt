using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Core.Constants.ErrorMessages;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Core.Models.Account;

public class RegisterAuthorModel
{
    public string ReturnUrl { get; set; } = "~/";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100,
        MinimumLength = 6,
        ErrorMessage = InvalidLength)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Име")]
    [StringLength(FirstNameMaxLength,
            MinimumLength = FirstNameMinLength,
            ErrorMessage = InvalidLength)]
    public string FirstName { get; set; } = string.Empty;

    [Display(Name = "Фамилия")]
    [StringLength(LastNameMaxLength,
        MinimumLength = LastNameMinLength,
        ErrorMessage = InvalidLength)]
    public string? LastName { get; set; }

    [Required]
    [Display(Name = "Тел. номер")]
    [StringLength(PhoneNumberMaxLength,
        MinimumLength = PhoneNumberMinLength,
        ErrorMessage = InvalidLength)]
    public string PhoneNumber { get; set; } = string.Empty;
}
