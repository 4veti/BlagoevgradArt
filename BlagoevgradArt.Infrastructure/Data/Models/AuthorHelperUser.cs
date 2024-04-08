using Microsoft.AspNetCore.Identity;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    public class AuthorHelperUser : IdentityUser
    {
        public Author Author { get; init; } = null!;
    }
}
