using BlagoevgradArt.Core.Contracts;
using BlagoevgradArt.Infrastructure.Data.Common;

namespace BlagoevgradArt.Core.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly IRepository _repository;

        public GalleryService(IRepository repository)
        {
            _repository = repository;
        }
    }
}
