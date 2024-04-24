using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Painting;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services
{
    public class PaintingHelperService : IPaintingHelperService
    {
        private readonly IRepository _repository;

        public PaintingHelperService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ArtTypeExistsAsync(int id)
            => await _repository.AllAsReadOnly<ArtType>().AnyAsync(a => a.Id == id);

        public async Task<bool> BaseTypeExistsAsync(int id)
            => await _repository.AllAsReadOnly<BaseType>().AnyAsync(b => b.Id == id);

        public async Task<bool> GenreExistsAsync(int id)
            => await _repository.AllAsReadOnly<Genre>().AnyAsync(g => g.Id == id);

        public async Task<bool> MaterialExistsAsync(int id)
            => await _repository.AllAsReadOnly<Material>().AnyAsync(m => m.Id == id);

        public async Task<IEnumerable<ArtTypeViewModel>> GetArtTypesAsync()
            => await _repository.AllAsReadOnly<ArtType>()
                .Select(g => new ArtTypeViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();

        public async Task<IEnumerable<BaseTypeViewModel>> GetBaseTypesAsync()
            => await _repository.AllAsReadOnly<BaseType>()
                .Select(g => new BaseTypeViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();

        public async Task<IEnumerable<GenreViewModel>> GetGenresAsync()
            => await _repository.AllAsReadOnly<Genre>()
                .Select(g => new GenreViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();

        public async Task<IEnumerable<MaterialViewModel>> GetMaterialsAsync()
            => await _repository.AllAsReadOnly<Material>()
                .Select(g => new MaterialViewModel()
                {
                    Id = g.Id,
                    Name = g.Name
                }).ToListAsync();
    }
}
