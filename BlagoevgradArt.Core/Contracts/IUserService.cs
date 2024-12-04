using BlagoevgradArt.Core.Models.Account;
using BlagoevgradArt.Core.Models.User;

namespace BlagoevgradArt.Core.Contracts;

public interface IUserService
{
    Task<ICollection<UserBasicInfoModel>> GetAllUsersBasicInfoAsync();
    Task AssignRolesToSelectedUsersAsync(ManageUserRolesModel model);
    Task RemoveUserFromRoleAsync(string email, string inRoles);

    Task<List<string>> RegisterUserAsync(RegisterAuthorModel model);
}
