using System.ComponentModel.DataAnnotations;
using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Core.Models.User;

public class ManageUserRolesModel
{
    public IEnumerable<UserBasicInfoModel> UsersBasicInfo { get; set; } = new List<UserBasicInfoModel>();

    public IEnumerable<string> RolesNames { get; set; } = new List<string>() { AuthorRole, GalleryRole };

    [Required]
    public string SelectedRoleName { get; set; } = string.Empty;
}
