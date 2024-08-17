using BlagoevgradArt.Core.Models.User;

namespace BlagoevgradArt.Core.Contracts;

public interface IUserService
{
    Task<ICollection<UserBasicInfoModel>> GetAllUsersBasicInfoAsync();
    Task AssignRolesToSelectedUsersAsync(ManageUserRolesModel model);
}
