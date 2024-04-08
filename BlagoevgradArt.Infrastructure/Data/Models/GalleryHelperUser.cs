using Microsoft.AspNetCore.Identity;

namespace BlagoevgradArt.Infrastructure.Data.Models
{
    public class GalleryHelperUser : IdentityUser
    {
        public Gallery Gallery { get; set; } = null!;
    }
}
