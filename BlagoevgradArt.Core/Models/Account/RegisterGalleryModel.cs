using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Core.Constants.ErrorMessages;
using static BlagoevgradArt.Infrastructure.Constants.DataConstants;

namespace BlagoevgradArt.Core.Models.Account;

public class RegisterGalleryModel
{
    [Required]
    [EmailAddress]
    [Display(Name = "Имейл")]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(100,
        MinimumLength = 6,
        ErrorMessage = InvalidLength)]
    [DataType(DataType.Password)]
    [Display(Name = "Парола")]
    public string Password { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    [Display(Name = "Потвърди паролата")]
    [Compare(nameof(Password), ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;

    [Required]
    [StringLength(GalleryNameMaxLength,
            MinimumLength = GalleryNameMinLength,
            ErrorMessage = InvalidLength)]
    [Display(Name = "Име")]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(GalleryAddressMaxLength,
        MinimumLength = GalleryAddressMinLength,
        ErrorMessage = InvalidLength)]
    [Display(Name = "Адрес")]
    public string Address { get; set; } = string.Empty;

    [Required]
    [StringLength(GalleryWorkingTimeMaxLength,
        MinimumLength = GalleryWorkingTimeMinLength,
        ErrorMessage = InvalidLength)]
    [Display(Name = "Работно време")]
    public string WorkingTime { get; set; } = string.Empty;

    [Required]
    [StringLength(PhoneNumberMaxLength,
        MinimumLength = PhoneNumberMinLength,
        ErrorMessage = InvalidLength)]
    [Display(Name = "Тел. номер")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(GalleryDescriptionMaxLength,
        MinimumLength = GalleryDescriptionMinLength,
        ErrorMessage = InvalidLength)]
    [Display(Name = "Описание")]
    public string Description { get; set; } = string.Empty;
}
