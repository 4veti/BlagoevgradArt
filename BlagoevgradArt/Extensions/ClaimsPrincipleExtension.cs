using System.Security.Claims;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Extensions
{
    public static class ClaimsPrincipleExtension
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsAdministrator(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdministratorRole);
        }
    }
}
