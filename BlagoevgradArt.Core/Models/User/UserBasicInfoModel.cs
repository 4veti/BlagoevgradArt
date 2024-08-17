using static BlagoevgradArt.Core.Constants.RoleConstants;

namespace BlagoevgradArt.Core.Models.User;

public class UserBasicInfoModel
{
    public bool IsSelected { get; set; }

    public string Email { get; set; } = string.Empty;

    public string InRoles { get; set; } = NoRoleText;
}
