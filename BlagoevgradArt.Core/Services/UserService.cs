using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.User;
using BlagoevgradArt.Infrastructure.Data.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services;

public class UserService : IUserService
{
    private readonly IRepository _repository;
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(IRepository repository,
        UserManager<IdentityUser> userManager)
    {
        _repository = repository;
        _userManager = userManager;
    }

    public async Task AssignRolesToSelectedUsersAsync(ManageUserRolesModel model)
    {
        foreach (UserBasicInfoModel user in model.UsersBasicInfo
            .Where(u => u.IsSelected
                && u.Email != "admin@mail.com"
                && u.InRoles.Contains(model.SelectedRoleName) == false))
        {
            IdentityUser iUser = await _userManager.FindByEmailAsync(user.Email);
            await _userManager.AddToRoleAsync(iUser, model.SelectedRoleName);
        }
    }

    public async Task<ICollection<UserBasicInfoModel>> GetAllUsersBasicInfoAsync()
    {
        var authors = await _repository.AllAsReadOnly<IdentityUser>()
            .Select(u => new UserBasicInfoModel()
            {
                Email = u.Email
            })
            .Where(u => u.Email != "admin@mail.com")
            .ToListAsync();

        foreach (UserBasicInfoModel user in authors)
        {
            IdentityUser iUser = await _userManager.FindByEmailAsync(user.Email);

            string roles = string.Join(", ", await _userManager.GetRolesAsync(iUser));

            user.InRoles = roles;
        }

        return authors;
    }
}
