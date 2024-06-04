namespace BlagoevgradArt.Core.Models.Author
{
    public class AuthorProfileInfoModel
    {
        public string FirstName { get; set; } = string.Empty;

        public string? LastName { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? ProfilePicturePath { get; set; }
    }
}
