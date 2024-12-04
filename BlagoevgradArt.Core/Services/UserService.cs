using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Account;
using BlagoevgradArt.Core.Models.User;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static BlagoevgradArt.Core.Constants.RoleConstants;


namespace BlagoevgradArt.Core.Services;

public class UserService : IUserService
{
    private readonly IRepository _repository;
    private readonly IUserStore<IdentityUser> _userStore;
    private readonly IUserEmailStore<IdentityUser> _emailStore;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public UserService(IRepository repository,
        IUserStore<IdentityUser> userStore,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
    {
        _repository = repository;
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = GetEmailStore();
        _signInManager = signInManager;
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

    public async Task RemoveUserFromRoleAsync(string email, string inRoles)
    {
        IdentityUser iUser = await _userManager.FindByEmailAsync(email);

        string[] roles = inRoles.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
        await _userManager.RemoveFromRolesAsync(iUser, roles);
    }

    public async Task<List<string>> RegisterUserAsync(RegisterAuthorModel model)
    {
        List<string> errors = new List<string>();

        try
        {
            IdentityUser? user = CreateUser();

            await _userStore.SetUserNameAsync(user, model.Email, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, model.Email, CancellationToken.None);
            IdentityResult? result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded == false)
            {
                foreach (var error in result.Errors)
                {
                    errors.Add(error.Description);
                }

                return errors;
            }

            await _userManager.AddToRoleAsync(user, AuthorRole);
            await _signInManager.SignInAsync(user, isPersistent: false);

            Author author = new Author()
            {
                UserId = user.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
            };

            await _repository.AddAsync(author);
            await _repository.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            errors.Add(ex.Message);
        }

        return errors;
    }

    private IdentityUser CreateUser()
    {
        try
        {
            return Activator.CreateInstance<IdentityUser>();
        }
        catch
        {
            throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'. " +
                $"Ensure that '{nameof(IdentityUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
        }
    }

    private IUserEmailStore<IdentityUser> GetEmailStore()
    {
        if (!_userManager.SupportsUserEmail)
        {
            throw new NotSupportedException("The default UI requires a user store with email support.");
        }
        return (IUserEmailStore<IdentityUser>)_userStore;
    }
}
