using BlagoevgradArt.Core.Models.Statistics;

namespace BlagoevgradArt.Core.Contracts;

public interface IStatisticsService
{
    Task<GeneralStatisticsInfoModel> GetGeneralStatisticsInfoAsync();
}
