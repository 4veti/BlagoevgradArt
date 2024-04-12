using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Infrastructure.Data.Common;

namespace BlagoevgradArt.Core.Services
{
    public class ExhibitionService : IExhibitionService
    {
        private readonly IRepository _repository;

        public ExhibitionService(IRepository repository)
        {
            _repository = repository;
        }
    }
}
