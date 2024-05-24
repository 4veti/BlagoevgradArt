using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Exhibition;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly IRepository _repository;

        public ExhibitionService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ExhibitionDetailsModel?> GetInfoAsync(int id)
        {
            Exhibition? exhibition = await _repository
                .AllAsReadOnly<Exhibition>()
                .Include(e => e.AuthorExhibitions)
                    .ThenInclude(ae => ae.Author)
                .Include(e => e.Gallery)
                .Where(e => e.Id ==  id)
                .FirstOrDefaultAsync();

            if (exhibition == null)
            {
                return null;
            }

            ExhibitionDetailsModel infoModel = new ExhibitionDetailsModel()
            {
                Name = exhibition.Name,
                OpeningDate = exhibition.OpeningDate,
                Description = exhibition.Description,
                HostGalleryName = exhibition.Gallery.Name,
                Participants = exhibition.AuthorExhibitions
                    .Select(ae => (ae.Author.FirstName + " " + ae.Author.LastName ?? "")
                    .Trim())
                    .ToList()
            };

            return infoModel;
        }

        public async Task<int> SaveExhibitionAsync(int galleryId, ExhibitionFormModel model)
        {
            Exhibition exhibition = new Exhibition
            {
                Name = model.Name,
                OpeningDate = model.OpeningDate,
                Description = model.Description,
                GalleryId = galleryId
            };

            await _repository.AddAsync<Exhibition>(exhibition);
            await _repository.SaveChangesAsync();

            return exhibition.Id;
        }
    }
}
