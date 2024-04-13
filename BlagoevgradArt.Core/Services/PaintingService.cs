using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;

namespace BlagoevgradArt.Core.Services
{
    public class PaintingService : IPaintingService
    {
        private readonly IRepository _repository;

        public PaintingService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddPaintingAsync(PaintingFormModel model, int authorId, string imagePath)
        {
            Painting painting = new Painting()
            {
                Title = model.Title,
                AuthorId = authorId,
                ImagePath = imagePath,
                Year = model.Year,
                GenreId = model.GenreId,
                ArtTypeId = model.ArtTypeId,
                BaseTypeId = model.BaseTypeId,
                MaterialId = model.MaterialId,
                Description = model.Description,
                HeightCm =  model.HeightCm,
                WidthCm = model.WidthCm,
                IsAvailable = model.IsAvailable
            };

            await _repository.AddAsync(painting);
            await _repository.SaveChangesAsync();

            return painting.Id;
        }
    }
}
