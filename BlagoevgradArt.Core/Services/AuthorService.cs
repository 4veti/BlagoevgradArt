using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Author;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository _repository;

        public AuthorService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
            => await _repository.AllAsReadOnly<Author>()
            .AnyAsync(a => a.UserId ==  userId);

        public async Task<int> GetIdAsync(string userId)
        {
            Author author = await _repository.AllAsReadOnly<Author>().FirstAsync(a => a.UserId == userId);

            return author.Id;
        }

        public async Task<AuthorProfileInfoModel> GetAuthorProfileInfo(string userId)
        {
            Author author = await _repository
                .AllAsReadOnly<Author>()
                .Include(a => a.User)
                .FirstAsync(a => a.UserId == userId);

            AuthorProfileInfoModel model = new AuthorProfileInfoModel()
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                PhoneNumber = author.PhoneNumber,
                Email = author.User.Email,
                ProfilePicturePath = author.ProfilePicturePath
            };

            return model;
        }
    }
}
