using BlagoevgradArt.Infrastructure.Data.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ISpecialUser User { get; init; } = null!;
    }
}
