using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Author;
using BlagoevgradArt.Core.Models.Painting;
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
            .AnyAsync(a => a.UserId == userId);

        public async Task<bool> ExistsByIdAsync(int id)
            => await _repository.AllAsReadOnly<Author>()
            .AnyAsync(a => a.Id == id);

        public async Task<int> GetIdAsync(string userId)
        {
            Author? author = await _repository
                .AllAsReadOnly<Author>()
                .FirstOrDefaultAsync(a => a.UserId == userId);

            return author != null ? author.Id : -1;
        }

        public async Task<AuthorProfileInfoModel> GetAuthorProfileInfoAsync(int id)
        {
            Author author = await _repository
                .AllAsReadOnly<Author>()
                .Include(a => a.User)
                .FirstAsync(a => a.Id == id);

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

        public async Task SetAuthorProfileInfoAsync(AuthorFormModel pInfo, string userId)
        {
            Author author = await _repository
                .All<Author>()
                .FirstAsync(a => a.UserId == userId);

            author.FirstName = pInfo.FirstName;
            author.LastName = pInfo.LastName;
            author.PhoneNumber = pInfo.PhoneNumber;

            await _repository.SaveChangesAsync();
        }

        public async Task<string> GetFullNameAsync(string userId)
        {
            Author author = await _repository.AllAsReadOnly<Author>()
                .FirstAsync(a => a.UserId == userId);

            return string.Join(" ", new string[] { author.FirstName, author.LastName ?? string.Empty });
        }

        public async Task<List<AuthorSmallThumbnailModel>> GetAuthorThumbnailsAsync(int id, bool isAuthorAccepted)
        {
            var authorsFiltered = _repository.AllAsReadOnly<Author>()
                .Where(a => a.AuthorExhibitions.Any(ae => ae.ExhibitionId == id))
                .Where(a => a.AuthorExhibitions.Any(ae => ae.IsAccepted == isAuthorAccepted));

            List<AuthorSmallThumbnailModel> authors = await authorsFiltered
                .Select(a => new AuthorSmallThumbnailModel()
                {
                    Id = a.Id,
                    FullName = (a.FirstName + " " + a.LastName ?? string.Empty).Trim(),
                }).ToListAsync();

            return authors;
        }

        public async Task<bool> SubmitRequestToJoinExhibitionAsync(string userId, int exhibitionId)
        {
            Exhibition exhibition = await _repository
                .AllAsReadOnly<Exhibition>()
                .FirstAsync(e => e.Id == exhibitionId);

            bool moreThanThreeDaysRemain = exhibition.OpeningDate.Day - DateTime.Today.Day >= 3;

            if (moreThanThreeDaysRemain == false)
            {
                return false;
            }

            AuthorExhibition? existingAuthorExhibition = await _repository
                .AllAsReadOnly<AuthorExhibition>()
                .Where(ae => ae.Author.UserId == userId && ae.ExhibitionId == exhibitionId)
                .FirstOrDefaultAsync();

            if (existingAuthorExhibition == null)
            {
                existingAuthorExhibition = new AuthorExhibition()
                {
                    AuthorId = await GetIdAsync(userId),
                    ExhibitionId = exhibitionId
                };

                await _repository.AddAsync(existingAuthorExhibition);
                await _repository.SaveChangesAsync();
            }

            return true;
        }
    }
}
