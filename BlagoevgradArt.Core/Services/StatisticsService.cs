using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Core.Models.Statistics;
using BlagoevgradArt.Infrastructure.Data.Common;
using BlagoevgradArt.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Core.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IRepository _repository;

    public StatisticsService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<GeneralStatisticsInfoModel> GetGeneralStatisticsInfoAsync()
    {
        int countPaintings = await _repository.AllAsReadOnly<Painting>().CountAsync();
        int countAuthors = await _repository.AllAsReadOnly<Author>().CountAsync();
        int countGalleries = await _repository.AllAsReadOnly<Gallery>().CountAsync();

        return new GeneralStatisticsInfoModel
        {
            PaintingsCount = countPaintings,
            AuthorsCount = countAuthors,
            GalleriesCount = countGalleries
        };
    }
}
