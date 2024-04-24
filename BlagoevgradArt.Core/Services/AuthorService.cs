using BlagoevgradArt.Core.Contracts;
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
    }
}
