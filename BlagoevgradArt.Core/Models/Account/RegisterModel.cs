using System.ComponentModel.DataAnnotations;

namespace BlagoevgradArt.Core.Models.Account;

public class RegisterModel
{
    public string ReturnUrl { get; set; } = "~/";

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [Required]
    [StringLength(100,
        MinimumLength = 6,
        ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}
