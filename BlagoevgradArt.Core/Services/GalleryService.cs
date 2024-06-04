using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IRepository _repository;

        public GalleryService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            Gallery? gallery = await _repository.AllAsReadOnly<Gallery>().FirstOrDefaultAsync(g => g.UserId == userId);

            if (gallery == null)
            {
                return false;
            }

            return true;
        }

        public async Task<int> GetIdAsync(string userId)
        {
            Gallery gallery = await _repository.AllAsReadOnly<Gallery>().FirstAsync(g => g.UserId == userId);

            return gallery.Id;
        }
    }
}
