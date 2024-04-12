using BlagoevgradArt.Core.Models.Painting;

namespace BlagoevgradArt.Core.Contracts
{
    public interface IPaintingHelperService
    {
        Task<IEnumerable<GenreViewModel>> GetGenresAsync();
        Task<IEnumerable<ArtTypeViewModel>> GetArtTypesAsync();
        Task<IEnumerable<BaseTypeViewModel>> GetBaseTypesAsync();
        Task<IEnumerable<MaterialViewModel>> GetMaterialsAsync();

        Task<bool> GenreExistsAsync(int id);
        Task<bool> ArtTypeExistsAsync(int id);
        Task<bool> BaseTypeExistsAsync(int id);
        Task<bool> MaterialExistsAsync(int id);
    }
}
